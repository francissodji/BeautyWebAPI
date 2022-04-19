using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class ExtratStyle
    {
        [Key]
        public int IdExtratStyle { get; set; }


        [Required]
        public int IdStyle { get; set; }

        public Style Style { get; set; }


        [Required]
        public int IDExtrat { get; set; }

        public Extrat Extrat { get; set; }


        [Required]
        public int IdSize { get; set; }

        public Size Size { get; set; }

        public double CostExtra { get; set; }
        public double CostTouchUpExtra { get; set; }
        public double CostExtraSize { get; set; }
        public double CostBusyExtra { get; set; }
        public double CostHairDeductExtra { get; set; }
    }
}
