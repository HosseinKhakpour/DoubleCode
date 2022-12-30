using Microsoft.AspNetCore.Mvc;

namespace DoubleCode.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
