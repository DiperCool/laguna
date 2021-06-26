using System;
using System.Threading.Tasks;
using Entities;
using Filters;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [UserHaveSecretFilterAtrribute]
    public class AdminPanelPromocodeController : Controller
    {
        IPromocodeService _promService;

        public AdminPanelPromocodeController(IPromocodeService promService)
        {
            _promService = promService;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePromocode([FromForm] CreatePromocodeModel model)
        {
            if(!ModelState.IsValid) return View(model);
            Promocode promocode = await _promService.CreatePromocode(new Promocode{ Name= model.Name, MaxUseTimes= model.MaxUseTimes, Code= model.Code, Discount= model.Discount, AvailableFrom= model.AvailableFrom, AvailableTo= model.AvailableTo, UsedTimes=0 });
            return View(promocode);
        }
        [HttpGet]
        public IActionResult CreatePromocode()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetPromocodes()
        {
            return View(await _promService.GetPromocodes());
        }
        [HttpPost]
        public async Task<IActionResult> DeletePromocode(int id)
        {
            await _promService.DeletePromocode(id);
            return RedirectToAction("GetPromocodes");
        }
        [HttpGet]
        public IActionResult DeletePromocode(DeletePromocodeModel model)
        {
            return View(model);
        }
        [HttpGet]
        public async  Task<IActionResult> UpdatePromocode(int id)
        {
            return View(await _promService.GetPromocodeById(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePromocode([FromForm] Promocode promocode)
        {
            await _promService.UpdatePromocode(promocode);
            return RedirectToAction("GetPromocodes");
        }

    }
}