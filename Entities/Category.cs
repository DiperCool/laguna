using System.Collections.Generic;

namespace Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public List<Product> Products { get ;set; } = new List<Product>();
    }
}