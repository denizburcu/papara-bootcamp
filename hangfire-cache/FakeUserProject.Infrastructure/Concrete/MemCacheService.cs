using FakeUserProject.Infrastructure.Contract;
using Microsoft.Extensions.Caching.Memory;

namespace FakeUserProject.Infrastructure.Concrete
{
    public class MemCacheService : IMemCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _cacheEntryOptions;

        public MemCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _cacheEntryOptions = CacheConfigs();
        }

        private MemoryCacheEntryOptions CacheConfigs()
        {
            return new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(1200))
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                        .SetPriority(CacheItemPriority.Normal)
                        .SetSize(1024);
        }

        public T Add<T>(string key, T value) where T : class
        {
            return _memoryCache.Set(key, value, _cacheEntryOptions);
        }

        public void AddAll<T>(string key, IEnumerable<T> value) where T : class
        {
            _memoryCache.Set(key, value, _cacheEntryOptions);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public bool TryGetAll<T>(string key, out IEnumerable<T>? value) where T : class
        {
            _memoryCache.TryGetValue(key, out value);
            if (value == null)
                return false;
            else
                return true;
        }

        public bool TryGetSingle<T>(string key, out T? value) where T : class
        {
            _memoryCache.TryGetValue(key, out value);
            if (value == null)
                return false;
            else
                return true;
        }
    }
}