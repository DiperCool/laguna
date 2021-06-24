using System.Collections.Generic;
using Entities;

namespace Models
{
    public class ViewOrdersModel
    {
        public PageViewModel Page { get ;set; }
        public List<Order> Orders{ get; set; }
    }
}