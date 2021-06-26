using System;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
    public class CheckoutController: Controller
    {

        IEmailService _emailService;
        ICheckoutService _checkoutService;

        IViewRenderService _viewRenderService;

        IOrderService _orderService;

        IPromocodeService _promocodeService;

        public CheckoutController(IEmailService emailService, ICheckoutService checkoutService, IViewRenderService viewRenderService, IOrderService orderService, IPromocodeService promocodeService)
        {
            _emailService = emailService;
            _checkoutService = checkoutService;
            _viewRenderService = viewRenderService;
            _orderService = orderService;
            _promocodeService = promocodeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendCheckout([FromBody] OrderModel model)
        {
            if(!ModelState.IsValid) return BadRequest();
            var products = await _checkoutService.GetProducts(model);
            
            Promocode promocode = await _promocodeService.GetPromocodeByCode(model.PromocodesCode);
            if(!_promocodeService.IsAvailable(promocode)){
                promocode=null;
            }
            Order order = new Order{ Guid= Guid.NewGuid().ToString(),Products = products.Select(x=>new ProductAmount{ ProductId = x.Product.Id, Amount= x.Amount }).ToList(), Instructions= model.Instructions, Name= model.Name, Phone= model.Phone, DeliveryPlace = model.DeliveryPlace, Delivery= model.Delivery, Promocode= promocode };
            var content = await _viewRenderService.RenderToStringAsync("Checkout/_EmailPartial", new CheckoutInfoModel(){ Products= products, Model= model, Promocode=promocode });
            await _emailService.Send(content,  order.Guid);
            order = await _orderService.CreateOrder(order);


            return Ok();
        }
    }
}