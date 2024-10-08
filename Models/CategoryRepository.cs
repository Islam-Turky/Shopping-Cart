namespace SampleApplication.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _storeDbContext;

        public CategoryRepository(StoreDbContext storeDbContext) 
        {
            _storeDbContext = storeDbContext;
        }
        public void Create(Category category) 
        {
            category.CategoryId = Guid.NewGuid().ToString();
            _storeDbContext.categories.Add(category);
        }
        public IEnumerable<Category> GetAll() 
        {
            IEnumerable<Category> result = _storeDbContext.categories.Select(e => e).ToList();
            return result;
        }
        public Category GetOne(string id)
        {
            Category? category = _storeDbContext.categories.FirstOrDefault(e => e.CategoryId == id);
            return category is not null ? category : new Category() { };
        }

        public void Edit( string id,Category newCategory) 
        {
            //Category category = GetOne(id);
            //category.CategoryName = newCategory.CategoryName;
            //category.CategoryDescription = newCategory.CategoryDescription;
        }

        public void Delete(string id)
        {
            Category category = GetOne(id);
            _storeDbContext.categories.Remove(category);
        }
        public int Save()
        {
            return _storeDbContext.SaveChanges();
        }
    }
}
