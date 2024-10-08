namespace SampleApplication.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _storedbContext;

        public ProductRepository(StoreDbContext storedbContext) 
        {
            _storedbContext = storedbContext;
        }
        public void Create(Product product) 
        {
            product.PId = Guid.NewGuid().ToString(); ;
            _storedbContext.products.Add(product);
        }
        public IEnumerable<Product> GetAll() 
        {
            return _storedbContext.products;
        }
        public Product GetOne(string id) 
        {
            Product? product = _storedbContext.products.SingleOrDefault(e => e.PId == id);
            return product is not null ? product : new Product { };
        }
        public void Delete(string id) 
        {
            Product product = GetOne(id);
            _storedbContext.products.Remove(product);
        }
        public void Edit(string id, Product newProduct)
        {
            //Product product = GetOne(id);
            //product.ProductName = newProduct.ProductName;
            //product.Amount = newProduct.Amount;
            //product.ProductPrice = newProduct.ProductPrice;
            //product.ProductDescription = newProduct.ProductDescription;
            //product.ProductImg = newProduct.ProductImg;
        }
        public int Save() 
        {
            return _storedbContext.SaveChanges();
        }
    }
}
