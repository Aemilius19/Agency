using Agency_Application.Abstractions;
using Agency_Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agency_Presentation.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class PortfolioController : Controller
    {
        IPortfolioService _service;
        private readonly IWebHostEnvironment _environment;

        public PortfolioController(IPortfolioService service,IWebHostEnvironment environment)
        {
            _service = service;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View(_service.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PortfolioVM portfolioVM)
        {
            if (!ModelState.IsValid) { return View(); }
            if (!portfolioVM.ImgFile.ContentType.Contains("image/"))
            {
                return View();
            }
            _service.Create(portfolioVM);
            string path = _environment.WebRootPath + @"\admin\upload\portfolio\";
            string filename = Guid.NewGuid() + portfolioVM.ImgFile.FileName;
            using (FileStream stream = new FileStream(path + filename, FileMode.Create))
            {
                portfolioVM.ImgFile.CopyTo(stream);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if(id == 0) { return View(); }
            _service.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id) 
        {
            return View(_service.Get(id));
        }
        [HttpPost]
        public IActionResult Update(PortfolioVM portfolioVM)
        {
            string path = _environment.WebRootPath + @"\admin\upload\portfolio\";
            string filename =Guid.NewGuid()+ portfolioVM.ImgFile.FileName;
            if (!ModelState.IsValid) { return View(); }
            if (_service.Get(portfolioVM.ID)!=null)
            {
                FileInfo fileinfo = new FileInfo(path + filename);
                if (fileinfo.Exists)
                {
                    fileinfo.Delete();
                }
            }
            using (FileStream stream = new FileStream(path + filename, FileMode.Create))
            {
                portfolioVM.ImgFile.CopyTo(stream);
                _service.Update(portfolioVM);
            }
            return RedirectToAction("Index");
        }
    }
}
