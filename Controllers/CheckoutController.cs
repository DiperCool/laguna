using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            ViewBag.Title="Оформления заказа";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendCheckout([FromBody] OrderModel model)
        {
            if (!ModelState.IsValid) return BadRequest();
            var products = await _checkoutService.GetProducts(model);

            Promocode promocode = await _promocodeService.GetPromocodeByCode(model.PromocodesCode);
            if (!_promocodeService.IsAvailable(promocode))
            {
                promocode = null;
            }
            else{
               promocode= await _promocodeService.IncreaseUsedTimes(promocode.Id);
            }
            Order order = new Order { Guid = Guid.NewGuid().ToString(), Products = products.Select(x => new ProductAmount { ProductId = x.Product.Id, Amount = x.Amount }).ToList(), Instructions = model.Instructions, Name = model.Name, Phone = model.Phone, DeliveryPlace = model.DeliveryPlace, Delivery = model.Delivery, Promocode = promocode };
            
            order = await _orderService.CreateOrder(order);
            var content = await _viewRenderService.RenderToStringAsync("Checkout/_EmailPartial", new CheckoutInfoModel() { Products = products, Model = model, Promocode = promocode });

            Thread thread = new Thread(async ()=>await SendEmail(content, _emailService, order));
            thread.Start();
            return Ok();
        }

        private async Task SendEmail(string content, IEmailService email,Order order)
        {
            await email.Send(content, order.Id);
        }
    }
}