using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ProductAmountModel
    {
        [Required]
        public int IdProduct { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}