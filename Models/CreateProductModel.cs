using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Models
{
    public class CreateProductModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public string Description { get; set; }
        public double? Excerpt { get; set; }
        public string UrlPhoto { get; set; }
        
        public IFormFile File { get; set; }
        [Required]
        public int IdCategory { get; set; }
    }
}