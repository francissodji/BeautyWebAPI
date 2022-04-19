using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class SaleDetail
    {
        public int IDSaleDetail { get; set; }
        public int IDSale { get; set; }
        public int IDProd { get; set; }
        public decimal UnitPrice { get; set; }
        public float QttySale { get; set; }
    }
}
