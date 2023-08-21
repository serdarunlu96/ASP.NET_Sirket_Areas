using Microsoft.AspNetCore.Mvc;

namespace ANK13Areas.Areas.Yonetim.Controllers
{

    [Area("Yonetim")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
