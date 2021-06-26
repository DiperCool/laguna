using System.Collections.Generic;
using Enums;

namespace Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string DeliveryPlace { get; set; }
        public string Phone { get; set;}
        public string Instructions { get; set; }
        public DeliveryType Delivery { get; set; }
        public List<ProductAmount> Products { get; set; }
        public int? PromocodeId { get; set; }
        public Promocode Promocode { get; set; }
    }
}