using FakeUserProject.Data.Context;
using FakeUserProject.Data.Contract;
using FakeUserProject.Infrastructure.Contract;
using Hangfire;
using Microsoft.EntityFrameworkCore;

namespace FakeUserProject.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMemCacheService _memCacheService;
        private readonly string _cacheKey;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public Repository(ApplicationDbContext dbContext, IMemCacheService memCacheService, IBackgroundJobClient backgroundJobClient)
        {
            _dbContext = dbContext;
            _memCacheService = memCacheService;
            _cacheKey = $"{typeof(T)}"; // "User", "Book"
            _backgroundJobClient = backgroundJobClient;
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            int id = await _dbContext.SaveChangesAsync();
            _backgroundJobClient.Enqueue(() => RefreshCache());
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            _backgroundJobClient.Enqueue(() => RefreshCache());
        }

        public async Task<IEnumerable<T>?> RetriveAllAsync()
        {
            if (!_memCacheService.TryGetAll<T>(_cacheKey, out IEnumerable<T>? cachedList))
            {
                cachedList = await _dbContext.Set<T>().AsNoTracking().ToListAsync();
                _memCacheService.AddAll<T>(_cacheKey, cachedList);
            }
            return cachedList;
        }

        public async Task<T?> RetriveAsync(int id)
        {
            if (!_memCacheService.TryGetSingle<T>(_cacheKey, out T? cachedEntity))
            {
                cachedEntity = await _dbContext.Set<T>().FindAsync(id);
                if (cachedEntity != null)
                {
                    _memCacheService.Add<T>(_cacheKey + id, cachedEntity); // we use cache key sample User12 for retrieve
                }
            }
            return cachedEntity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            _backgroundJobClient.Enqueue(() => RefreshCache());
        }

        public async Task RefreshCache()
        {
            _memCacheService.Remove(_cacheKey);
            var cachedList = await _dbContext.Set<T>().ToListAsync();
            _memCacheService.AddAll(_cacheKey, cachedList);
        }
    }
}