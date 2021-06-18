using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Filters;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models;

namespace Controllers
{
    [UserHaveSecretFilterAtrribute]
    public class AdminPanelProductController: Controller
    {
        IProductService _service;

        public AdminPanelProductController(IProductService service)
        {
            _service = service;
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
    
            return RedirectToAction("Products");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(DeleteProductModel model)
        {
            await _service.DeleteProduct(model.Id);
            return RedirectToAction("Products");
        }
        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            return View(new DeleteProductModel{Id=id});
        }
    }
}