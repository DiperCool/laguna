using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class DeleteCategoryModel
    {
        [Required]
        public int Id { get; set; }
    }
}