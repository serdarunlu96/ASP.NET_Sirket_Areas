using Microsoft.AspNetCore.Mvc;

namespace ANK13Areas.Areas.Muhasebe.Controllers
{

    [Area("Muhasebe")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
