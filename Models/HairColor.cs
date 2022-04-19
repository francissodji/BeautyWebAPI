using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class HairColor
    {
        public int IdHairColor { get; set; }
        public int IdHair { get; set; }
        public int IdColor { get; set; }
        public float StockAlert { get; set; }
        public float StockSecurity { get; set; }
    }
}
