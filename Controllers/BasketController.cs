using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class BasketController : Controller
    {
        IProductService _service;

        public BasketController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetCostsProduct(int id)
        {
            return Ok(await _service.GetProductById(id));
        }
    }
}