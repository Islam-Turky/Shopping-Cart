using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Models;

namespace SampleApplication.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> _categoriesRepository;
        public CategoryController(IRepository<Category> categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Category>? categories = _categoriesRepository.GetAll();
            return View(categories);
        }

        [Authorize(Roles = "Admin,Trader")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CategoryName,CategoryDescription")] Category category) 
        {
            Category? checkIfExist = _categoriesRepository.GetAll()?.SingleOrDefault(e => e.CategoryName == category.CategoryName);
            if (checkIfExist == null) 
            {
                if (ModelState.IsValid) 
                {
                    category.CategoryId = Guid.NewGuid().ToString();
                    _categoriesRepository.Create(category);
                    _categoriesRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.message = "Category Exist Already";
            return View(category);
        }

        [Authorize(Roles = "Admin,Trader")]
        public IActionResult Remove(string id) 
        {
            _categoriesRepository.Delete(id);
            _categoriesRepository.Save();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Trader")]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("CategoryName,CategoryDescription")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.CategoryId = id;
                _categoriesRepository.Edit(id,category);
                _categoriesRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.message = "Product Exist Already";
            return View(category);
        }
    }
}
