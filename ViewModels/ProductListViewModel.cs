using SampleApplication.Models;

namespace SampleApplication.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product>? products;
        public Category? Category { get; set; }
        //public string? param { get; set; }
    }
}
