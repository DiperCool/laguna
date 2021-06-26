using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Enums;

namespace Models
{
    public class OrderModel
    {
        public string Name { get; set; }
        public string DeliveryPlace { get; set; }
        [Required]
        public string Phone { get; set;}
        public string Instructions { get; set; }
        [Required]
        public DeliveryType Delivery { get; set; }
        [Required]
        public List<ProductAmountModel> Products { get; set; }
        public string PromocodesCode { get; set; }
    }
}