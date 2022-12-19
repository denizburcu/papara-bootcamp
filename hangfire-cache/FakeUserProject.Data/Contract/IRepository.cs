namespace FakeUserProject.Data.Contract
{
    public interface IRepository<T> where T : class
    {
    
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T?> RetriveAsync(int id);
        Task<IEnumerable<T>?> RetriveAllAsync();
    }
}