using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SampleApplication.Controllers
{
    [Authorize(Roles = "Customer")]
    [Authorize(Roles = "Admin")]
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
