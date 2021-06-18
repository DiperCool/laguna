using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class DeleteProductModel
    {
        [Required]
        public int Id { get; set; }
    }
}