using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
namespace laguna.Controllers
{
    public class MenuController: Controller
    {
        IWebHostEnvironment _appEnvironment;

        public MenuController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title="Лагуна | Меню";
            var files = Directory.GetFiles(_appEnvironment.WebRootPath+"/menus")
                        .ToList()
                        .Select(x=>Path.GetFileName(x))
                        .ToList();
            return View(files);
        }
    }
}