using SampleApplication.Models;

namespace SampleApplication.ViewModels
{
    public class CreateProductModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> categories { get; set; }
    }
}
