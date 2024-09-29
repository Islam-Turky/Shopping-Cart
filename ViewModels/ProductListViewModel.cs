using SampleApplication.Models;

namespace SampleApplication.ViewModels
{
    public class ProductListViewModel
    {
        public List<Product>? products;
        public string? param { get; set; }
    }
}
