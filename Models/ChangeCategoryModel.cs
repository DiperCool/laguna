using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Models
{
    public class ChangeCategoryModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Id { get; set; }
        public IFormFile File { get; set; }
    }
}