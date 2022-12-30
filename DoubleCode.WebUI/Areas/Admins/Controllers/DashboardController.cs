using Microsoft.AspNetCore.Mvc;
namespace DoubleCode.WebUI.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
