using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Models;
using SampleApplication.ViewModels;

namespace SampleApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepositiory;
        private readonly ICategoryRepository _categoryRepositiory;

        public ProductController(IProductRepository productRepositiory, ICategoryRepository categoryRepositiory)
        {
            _productRepositiory = productRepositiory;
            _categoryRepositiory = categoryRepositiory;
        }

        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<Product>? products =  _productRepositiory.GetAll();
            return View(products is not null ? products : new Product() { Category = null, Amount = 0, PId ="none" });
        }

        [Authorize]
        public IActionResult Show(string id)
        {
            Product? product = _productRepositiory.GetOne(id);
            //Category? category = _categoryRepositiory.GetById(product.Category?.CategoryId);
            Category? category = _categoryRepositiory.GetAll().FirstOrDefault(e => e.CategoryId == product.Category.CategoryId);
            ProductViewModel productViewModel = new ProductViewModel { Product = product, Category = category };
            return View(productViewModel);
        }
    }
}
