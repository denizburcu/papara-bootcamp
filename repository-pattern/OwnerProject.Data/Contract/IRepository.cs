namespace OwnerProject.Data.Contract
{
    public interface IRepository<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}