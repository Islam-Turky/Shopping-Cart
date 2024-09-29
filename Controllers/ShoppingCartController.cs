using Microsoft.AspNetCore.Mvc;

namespace SampleApplication.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
