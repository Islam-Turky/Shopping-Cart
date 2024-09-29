using Microsoft.AspNetCore.Mvc;
using SampleApplication.Models;
using SampleApplication.ViewModels;

namespace SampleApplication.Controllers
{
    public class StoreController : Controller
    {
        private readonly IProductRepository _productRepository;

        public StoreController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            List<Product>? products = _productRepository.GetAll();
            ProductListViewModel model = new ProductListViewModel { products = products };
            return View(model);
        }

        [HttpGet]
        public IActionResult Index(string? id)
        {
            List<Product>? products = _productRepository.GetAll();
            string? userName = TempData["userName"] as string;
            ProductListViewModel model = new ProductListViewModel { products = products, param = userName };
            return View(model);
        }

        public IActionResult AddProduct() 
        {
            return View();
        }
    }
}
