namespace OwnerProject.Data.Contract
{
    public interface IRepository<T>
    {
        void Create(T entity);
        T Retrive(int Id);
        IEnumerable<T> RetrieveAll();
        void Update(T entity);
        void Delete(int Id);
    }
}