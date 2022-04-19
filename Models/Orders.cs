using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Orders
    {
        public int IDOrder { get; set; }
        public int IDVendor { get; set; }
        public DateTime DateOrder { get; set; }
        public string CategOrder { get; set; }
    }
}
