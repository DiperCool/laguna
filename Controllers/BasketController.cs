using System;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Laguna.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Controllers
{
    public class BasketController : Controller
    {
        IProductService _service;
        IMemoryCache _cache;

        public BasketController(IProductService service, IMemoryCache cache)
        {
            _service = service;
            _cache = cache;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetCostsProduct(int id)
        {
            var products = await _cache.GetOrCreate(CacheKeys.Products, async(entry) =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(10);
                return await _service.GetProducts();
            });
            return Ok(products.FirstOrDefault(x=>x.Id==id));
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _cache.GetOrCreate(CacheKeys.Products, async(entry) =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(10);
                return await _service.GetProducts();
            });
            return Ok(products);
        }
    }
}