using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Models
{
    public class CreateCategoryModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public IFormFile  File{ get; set; }
    }
}