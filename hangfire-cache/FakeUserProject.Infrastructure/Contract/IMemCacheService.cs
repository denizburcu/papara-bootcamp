namespace FakeUserProject.Infrastructure.Contract
{
    public interface IMemCacheService
    {
        bool TryGetSingle<T>(string key, out T? value) where T : class;
        bool TryGetAll<T>(string key, out IEnumerable<T>? value) where T : class;
        T Add<T>(string key, T value) where T : class;
        void AddAll<T>(string key, IEnumerable<T> value) where T : class;
        void Remove(string key);
    }
}