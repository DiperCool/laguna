using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Interfaces;
using Models;

namespace Services
{
    public class CheckoutService : ICheckoutService
    {
        IProductService _productService;

        public CheckoutService(IProductService productService)
        {
            _productService = productService;
        }

        public async  Task<List<ProductsCheckoutModel>> GetProducts(CheckoutEmeilSendModel model)
        {
            List<ProductsCheckoutModel> Products = new List<ProductsCheckoutModel>();
            foreach(var item in model.Products)
            {
                Product product = await _productService.GetProductById(item.IdProduct);
                Products.Add(new ProductsCheckoutModel{Product= product, Amount=item.Amount});
            }
            return Products;
        }

    }
}