namespace SampleApplication.Models
{
    public interface IProductRepository
    {
        public void Add(Product product);
        public List<Product>? GetAll();
        public Product? GetOne(string pId);
    }
}
