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
        public IEnumerable<Product>? GetAll() 
        {
            return _storedbContext.products.Select(e => e);
        }
        public Product GetOne(string id) 
        {
            Product? product = _storedbContext.products.FirstOrDefault(el => id == el.PId);
            return product is not null ? product : new Product();
        }
    }
}
