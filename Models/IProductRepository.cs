namespace SampleApplication.Models
{
    public interface IProductRepository
    {
        public void Add(Product product);
        public IEnumerable<Product>? GetAll();
        public Product? GetOne(string pId);
    }
}
