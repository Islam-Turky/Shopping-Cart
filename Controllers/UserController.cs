using Microsoft.AspNetCore.Mvc;
using SampleApplication.Models;
using SampleApplication.ViewModels;

namespace SampleApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        public UserController(IProductRepository productRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
        }
        public IActionResult Login()
        {
            TempData["name"] = "";
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName , string email, string password)
        {
            User model = _userRepository.Login(userName, email, password);
            if (model.UserName != "NotFound")
            {
                TempData["name"] = model.UserName;
                ViewBag.message = "Success!";
                return RedirectToAction("Index", "Store");
            }
            else
            {
                TempData["name"] = "not exist";
                ViewBag.message = "User Not Exist!";
                return View();
            }
        }
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Register(string name, string email, string password)
        //{
        //    User? user = _storeDbContext.users.FirstOrDefault(e => e.UserEmail == email);
        //    if (user == null)
        //    {
        //        _storeDbContext.users.Add(new User { UserName = name, UserEmail = email, Password = password });
        //        ViewBag.name = name;
        //        ViewBag.email = email;
        //        return View();
        //    }
        //    else
        //    {
        //        ViewBag.message = "User Is Exist!";
        //        return View(user);
        //    }
        //}

        public IActionResult Products(string uname) 
        {
            List<Product>? products = _productRepository.GetAll();
            ProductListViewModel productListViewModel = new ProductListViewModel() { products = products };
            return View(productListViewModel);
        }
    }
}
