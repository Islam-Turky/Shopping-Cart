using Microsoft.AspNetCore.Mvc;
using SampleApplication.Models;
using SampleApplication.ViewModels;

namespace SampleApplication.Controllers
{
    public class StoreController : Controller
    {
        private readonly IRepository<Product> _productRepository;

        public StoreController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Product>? products = _productRepository.GetAll();
            ProductListViewModel model = new ProductListViewModel { products = products };
            return View(model);
        }
    }
}
