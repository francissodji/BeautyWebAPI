using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Delivery
    {
        public int IDDelivery { get; set; }
        public int IDOrder { get; set; }
        public DateTime DateDelivery { get; set; }
    }
}
