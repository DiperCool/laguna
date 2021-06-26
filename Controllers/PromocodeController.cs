using System.Threading.Tasks;
using Entities;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    public class PromocodeController : Controller
    {
        IPromocodeService _promService;

        public PromocodeController(IPromocodeService promService)
        {
            _promService = promService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPromocodeByCode(string code)
        {
            if(string.IsNullOrEmpty(code)) return BadRequest();
            Promocode promocode = await _promService.GetPromocodeByCode(code);
           
            GetPromocodeModel model = new GetPromocodeModel{ Code=promocode.Code, Discount= promocode.Discount, IsAvailable = _promService.IsAvailable(promocode)  };
            return Ok(model);
        }
    }
}