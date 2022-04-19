using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.DTOs
{
    public class DiscountUpdateDto
    {

        public string TitleDiscount { get; set; }

        public float RateDiscount { get; set; }

        public double CostDiscount { get; set; }
    }
}
