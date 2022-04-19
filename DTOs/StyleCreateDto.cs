using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.DTOs
{
    public class StyleCreateDto
    {
        public string DesigStyle { get; set; }

        public string? DescriptStyle { get; set; }

        public bool? HairProvStyle { get; set; }

        public double? CostStyle { get; set; }

        public double? PriceTakeOffHair { get; set; }

        public double? CostTouchUp { get; set; }

        public string? PictureStyle { get; set; }
    }
}
