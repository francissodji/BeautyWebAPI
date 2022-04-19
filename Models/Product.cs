using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Product
    {
        public int IDProd { get; set; }
        public string TitleProd { get; set; }
        public int IDTypeProd { get; set; }
        public string RefProd { get; set; }
        public float QtityStockAlert { get; set; }
        public float QtityStockSecure { get; set; }
        public bool IsPrdtReturnable { get; set; }
    }
}
