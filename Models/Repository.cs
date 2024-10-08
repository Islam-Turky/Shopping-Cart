using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SampleApplication.Models
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly StoreDbContext _stroeDbContext;
        public Repository(StoreDbContext stroeDbContext) 
        {
            _stroeDbContext = stroeDbContext;
        }

        public void Create(TEntity entity) 
        {
            _stroeDbContext.Set<TEntity>().Add(entity);
        }

        public IEnumerable<TEntity> GetAll() 
        {
            return _stroeDbContext.Set<TEntity>();
        }

        public TEntity? GetOne(string id) 
        {
            return _stroeDbContext.Set<TEntity>().Find(id);
        }

        public void Edit(string id, TEntity newEntity) 
        {
            TEntity? entitiy = GetOne(id);
            if (entitiy != null) 
            {
                _stroeDbContext.Entry(entitiy).CurrentValues.SetValues(newEntity);
            }
        }

        public void Delete(string id) 
        {
            TEntity? entity = _stroeDbContext.Set<TEntity>().Find(id);
            if (entity != null) 
            {
                _stroeDbContext.Set<TEntity>().Remove(entity);
            }
        }

        public int Save() 
        {
            return _stroeDbContext.SaveChanges();
        }
    }
}
