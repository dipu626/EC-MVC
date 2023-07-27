using Microsoft.AspNetCore.Mvc;

namespace EC.WEB.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
