using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace AlviUkraine.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            _localizedizer = localizer;
        }

        private readonly IStringLocalizer _localizedizer;

        public IActionResult Index()
        {
            ViewBag.Title = _localizedizer["MainPageTitle"];

            return View();
        }
    }
}
