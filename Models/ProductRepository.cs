namespace SampleApplication.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _storedbContext;

        public ProductRepository(StoreDbContext storedbContext) 
        {
            _storedbContext = storedbContext;
        }
        public void Add(Product product) 
        {
            _storedbContext.products.Add(product);
        }
        public List<Product>? GetAll() 
        {
            return _storedbContext.products.Select(e => e).ToList();
        }
        public Product? GetOne(string pId) 
        {
            return _storedbContext.products.FirstOrDefault(e => e.PId == pId);
        }
    }
}
