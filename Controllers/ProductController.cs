using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Models;
using SampleApplication.ViewModels;

namespace SampleApplication.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _CategoryRepo;
        private readonly IPaymobManager _paymobManager;
        public ProductController(IRepository<Product> productRepository,
            IRepository<Category> categoryRepo,
            IPaymobManager paymobManager
            )
        {
            _productRepository = productRepository;
            _CategoryRepo = categoryRepo;
            _paymobManager = paymobManager;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products =  _productRepository.GetAll();
            return View(products);
        }

        public async Task<IActionResult> Show(string id)
        {
            Product? product = _productRepository.GetOne(id);
            ProductViewModel productViewModel = new ProductViewModel { Product = product, Category = _CategoryRepo.GetAll() };
            bool priceToInt = Int32.TryParse(product.ProductPrice, out int price);
            var paymentToken = await _paymobManager.GetPaymentKey(price, product.Amount,product.ProductName,product.ProductDescription,"islam@gmail.com", "EGP");
            ViewBag.PaymentToken = paymentToken;
            return View(productViewModel);
        }

        [Authorize("Admin,Trader")]
        public IActionResult Delete(string id)
        {
            _productRepository.Delete(id);
            _productRepository.Save();
            return View();
        }

        [Authorize(Roles = "Admin,Trader")]
        public IActionResult Edit(string id)
        {
            ViewBag.Categories = _CategoryRepo.GetAll();
            ViewBag.Product = _productRepository.GetOne(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id,[Bind("ProductName,Amount,Category,ProductDescription,ProductPrice,ProductImg")] Product product)
        {
            ViewBag.Categories = _CategoryRepo.GetAll();
            ViewBag.Product = _productRepository.GetOne(id);
            if (ModelState.IsValid) 
            {
                Category? category = _CategoryRepo.GetAll().FirstOrDefault(e => e.CategoryName == product.Category);
                if(category is not null) 
                {
                    product.PId = id;
                    _productRepository.Edit(id, product);
                    _productRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.message = "Product Exist Already";
            return View(product);
        }

        [Authorize(Roles = "Admin,Trader")]
        public IActionResult Create() 
        {
            ViewBag.Categories = _CategoryRepo.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ProductName,Amount,ProductPrice,Category,ProductImg,ProductDescription")] Product product)
        {
            ViewBag.Categories = _CategoryRepo.GetAll();
            if (ModelState.IsValid)
            {
                Product? check = _productRepository.GetAll().FirstOrDefault(e => e.ProductName == product.ProductName);
                if (check is null)
                {
                    product.PId = Guid.NewGuid().ToString();
                    _productRepository.Create(product);
                    _productRepository.Save();
                    return RedirectToAction("Index", "Store");
                }
            }
            ViewBag.message = "Product Exist Already";
            return View(product);
        }

        [Authorize(Roles = "Admin,Trader")]
        public IActionResult Remove(string id)
        {
            _productRepository.Delete(id);
            _productRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Pay(string id) 
        {
            Product? product = _productRepository.GetOne(id);
            return View(product);
        }
    }
}
