using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CreatePromocodeModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public int Discount { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AvailableFrom { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime AvailableTo { get; set; }
        [Required]
        public int MaxUseTimes { get; set; }
    }
}