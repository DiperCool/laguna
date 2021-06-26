using System.Collections.Generic;
using Entities;

namespace Models
{
    public class  CheckoutInfoModel
    {
        public List<ProductsCheckoutModel> Products { get; set; }
        public OrderModel Model { get; set; }
        public Promocode Promocode { get ;set ;}
    }
}