namespace SampleApplication.Models
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        IEnumerable<T> GetAll();
        T? GetOne(string id);
        void Edit(string id, T entity);
        void Delete(string id);
        int Save();
    }
}
