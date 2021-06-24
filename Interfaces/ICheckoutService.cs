using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Services;

namespace Interfaces
{
    public interface ICheckoutService
    {
        Task<List<ProductsCheckoutModel>> GetProducts(CheckoutEmeilSendModel model); 
    }
}