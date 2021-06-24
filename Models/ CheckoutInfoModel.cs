using System.Collections.Generic;

namespace Models
{
    public class  CheckoutInfoModel
    {
        public List<ProductsCheckoutModel> Products { get; set; }
        public CheckoutEmeilSendModel Model { get; set; }
    }
}