namespace SampleApplication.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _storeDbContext;

        public CategoryRepository(StoreDbContext storeDbContext) 
        {
            _storeDbContext = storeDbContext;
        }
        public void Add(Category category) 
        {
            category.CategoryId = Guid.NewGuid().ToString();
            _storeDbContext.categories.Add(category);
        }
        public IEnumerable<Category> GetAll() 
        {
            IEnumerable<Category> result = _storeDbContext.categories.Select(e => e).ToList();
            return result;
        }
        public Category GetById(string cId) 
        {
            Category? category = _storeDbContext.categories.FirstOrDefault(e => e.CategoryId == cId);
            return category is not null ? category : new Category();
        }

        public void Save()
        {
            _storeDbContext.SaveChanges();
        }
    }
}
