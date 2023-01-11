using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Combine
    {
        [Key]
        public int IdCombine { get; set; }

        [Required]
        public int IdStyle { get; set; }

        public int IdSize { get; set; }

        public int IdLength { get; set; }

        public double? CostStyle { get; set; } = 0; //0 = Default value

        public double? CostTakeDown { get; set; } = 0;

        public double? CostTouchUp { get; set; } = 0;

        public double? CostHairDeduct { get; set; } = 0;

        public double? CostStyleBusyTime { get; set; } = 0;

        public int IdCompany { get; set; }
        //public StyleLibrary? Style { get; set; }
        //public SizeLibrary? Size { get; set; }
        //public LengthLibrary? Length { get; set; }
    }
}
