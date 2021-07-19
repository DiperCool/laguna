using System.Text.Json.Serialization;
using Enums;
namespace Entities
{
    public class Product
    {
        public int Id { get ;set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Description { get; set; }
        public double? Excerpt { get; set; }
        public string UrlPhoto { get; set; }
        public int CategoryId { get; set; }
        public WrapperType WrapperType { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
    }
}