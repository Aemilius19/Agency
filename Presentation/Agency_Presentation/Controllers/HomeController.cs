
using Agency_Application.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agency_Presentation.Controllers
{
    public class HomeController : Controller
    {
        IPortfolioService _service;

        public HomeController(IPortfolioService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetAll());
        }
    }
}
