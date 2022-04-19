using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Discount
    {
        [Key]
        public int IDDiscount { get; set; }

        [Required]
        [MaxLength(100)]
        public string TitleDiscount { get; set; }

        public float RateDiscount { get; set; }

        public double CostDiscount { get; set; }
    }
}
