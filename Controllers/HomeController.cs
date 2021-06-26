using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Laguna.Models;
using Interfaces;
using Entities;

namespace Laguna.Controllers
{
    public class HomeController : Controller
    {
        ILogger<HomeController> _logger;
        ICategoryService _catService;
        IProductService _prodService;

        public HomeController(ILogger<HomeController> logger, ICategoryService catService, IProductService prodService)
        {
            _logger = logger;
            _catService = catService;
            _prodService = prodService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _prodService.GetProducts());
        }
        [Route("/product/{category}")]
        public async Task<IActionResult> Index(string category)
        {
            Category cat =await _catService.GetCategoryByName(category);
            if(cat==null) return RedirectToAction("Error404","Error");
            return View(await _prodService.GetProductsByCategory(cat.Id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
