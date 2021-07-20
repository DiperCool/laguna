using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Filters;
using Interfaces;
using Laguna.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Caching.Memory;
using Models;
using System;
namespace Controllers
{
    [UserHaveSecretFilterAtrribute]
    public class AdminPanelProductController: Controller
    {
        IProductService _service;

        IMemoryCache _memoryCache;

        public AdminPanelProductController(IProductService service, IMemoryCache memoryCache)
        {
            _service = service;
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            if(model.File==null && model.UrlPhoto==null)
            {
                ModelState.AddModelError("","No photo");
                return View(model);
            }
            await _service.CreateProduct(model);
            _memoryCache.Remove(CacheKeys.Products);
            return View();
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Products(ViewProductModel model)
        {
            List<Product> products = await _service.GetProductFilter(model.Name, model.idCategory);
            ProductFilterResult res = new ProductFilterResult{ Products=products, Filter= model };
            return View(res);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var product= await _service.GetProductById(id);
            var productDto = new UpdateProductModel{ Id=product.Id, Name=product.Name, Excerpt= product.Excerpt, Description= product.Description, Cost= product.Cost, IdCategory= product.CategoryId, UrlPhoto= product.UrlPhoto };
            return View(productDto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            if(model.File==null && model.UrlPhoto==null)
            {
                ModelState.AddModelError("","No photo");
                return View(model);
            }
            await _service.UpdateProduct(model);
            _memoryCache.Remove(CacheKeys.Products);
            return RedirectToAction("Products");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(DeleteProductModel model)
        {
            await _service.DeleteProduct(model.Id);
            _memoryCache.Remove(CacheKeys.Products);
            return RedirectToAction("Products");
        }
        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            return View(new DeleteProductModel{Id=id});
        }

        [HttpGet]
        public async Task<IActionResult> PngToJpeg()
        {
            await _service.ImgToJpeg();
            _memoryCache.Remove(CacheKeys.Products);
            return RedirectToAction("Products");



        }
    }
}