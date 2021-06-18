using System.Collections.Generic;
using Entities;

namespace Models
{
    public class ProductFilterResult
    {
        public List<Product> Products { get; set; }
        public ViewProductModel Filter { get; set; }
    }
}