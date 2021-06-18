using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ChangeCategoriesNameModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Id { get; set; }
    }
}