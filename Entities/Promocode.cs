using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Promocode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Discount { get; set; }

        public DateTime AvailableFrom { get; set; }

        public DateTime AvailableTo { get; set; }
        public int MaxUseTimes { get; set; }
        public int UsedTimes { get; set; }
    }
}