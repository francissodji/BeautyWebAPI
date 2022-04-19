using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Sale
    {
        public int IDSale { get; set; }
        public string RefSale { get; set; }
        public DateTime DateSale { get; set; }
        public int IdJobDone { get; set; }
    }
}
