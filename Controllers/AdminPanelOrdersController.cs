using System.Threading.Tasks;
using Filters;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [UserHaveSecretFilterAtrribute]
    public class AdminPanelOrdersController: Controller
    {
        IOrderService _orderService;

        public AdminPanelOrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<IActionResult> Orders(int page = 1)
        {
            return View(await _orderService.GetOrders(page));
        }

        [HttpGet]
        public async Task<IActionResult> Order(int id)
        {
            return View(await _orderService.GetOrderById(id));
        }
    }
}