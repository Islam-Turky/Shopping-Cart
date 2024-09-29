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

        public IActionResult Index()
        {
            List<Product>? products =  _productRepositiory.GetAll();
            return View(products is not null ? products : new Product() { ProductCategory = null, Amount = 0, PId ="none" });
        }

        public IActionResult Show(string id)
        {
            Product? product = _productRepositiory.GetOne(id);
            string? cId = product?.ProductCategory?.ToString();
            Category? category = _categoryRepositiory.GetById(cId);
            ProductViewModel productViewModel = new ProductViewModel { Product = product, Category = category };
            return View(productViewModel);
        }
    }
}
