using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CreateCategoryModel
    {
        [Required]
        public string Name { get; set; }
    }
}