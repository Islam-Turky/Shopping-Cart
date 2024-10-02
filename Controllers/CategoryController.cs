using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Models;

namespace SampleApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<Category>? categories = _categoryRepository.GetAll();
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
            Category? checkIfExist = _categoryRepository.GetAll()?.SingleOrDefault(e => e.CategoryName == category.CategoryName);
            if (checkIfExist == null) 
            {
                if (ModelState.IsValid) 
                {
                    _categoryRepository.Add(category);
                    _categoryRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.message = "Category Exist Already";
            return View(category);
        }
    }
}
