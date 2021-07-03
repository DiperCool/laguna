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
using Wangkanai.Detection.Services;
using Microsoft.Extensions.Caching.Memory;
using Laguna.Tools;

namespace Laguna.Controllers
{
    public class HomeController : Controller
    {
        ILogger<HomeController> _logger;
        ICategoryService _catService;
        IProductService _prodService;
        IDetectionService _detectionService;
        IMemoryCache _cache;

        public HomeController(ILogger<HomeController> logger, ICategoryService catService, IProductService prodService, IDetectionService detectionService, IMemoryCache cache)
        {
            _logger = logger;
            _catService = catService;
            _prodService = prodService;
            _detectionService = detectionService;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _cache.GetOrCreate(CacheKeys.Products, async(entry) =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(3);
                return await _prodService.GetProducts();
            });
            if(_detectionService.Device.Type==Wangkanai.Detection.Models.Device.Mobile)
            {
                return View("~/Views/Android/Home.cshtml", products);
            }
            return View(products);
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
