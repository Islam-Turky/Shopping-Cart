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
            _storeDbContext.categories.Add(category);
        }
        public List<Category>? GetAll() 
        {
            return _storeDbContext.categories.Select(e => e).ToList();
        }
        public Category? GetById(string cId) 
        {
            return _storeDbContext.categories.FirstOrDefault(e => e.CategoryId == cId);
        }
    }
}
