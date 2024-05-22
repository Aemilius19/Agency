using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agency_Presentation.Areas.admin.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles ="Admin")]
        [Area("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
