using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class ProductPrice
    {
        public int IdProdPrice { get; set; }
        public int IdProd { get; set; }
        public decimal SalePrice { get; set; }
        public float SaleTax { get; set; }
    }
}
