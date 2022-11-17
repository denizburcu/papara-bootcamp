using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace OwnerProject.Data.Contract
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected OwnerDBContext OwnerDBContext { get; set; }
        public Repository(OwnerDBContext ownerDBContext)
        {
            OwnerDBContext = ownerDBContext;
        }

        public IQueryable<T> FindAll() => OwnerDBContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
                    OwnerDBContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => OwnerDBContext.Set<T>().Add(entity);
        public void Update(T entity) => OwnerDBContext.Set<T>().Update(entity);
        public void Delete(T entity) => OwnerDBContext.Set<T>().Remove(entity);

        public void SaveChanges() => OwnerDBContext.SaveChanges();
    }
}