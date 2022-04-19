using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Inventory
    {
        public int IDInvent { get; set; }
        public string RefInvent { get; set; }
        public DateTime DateInvent { get; set; }
        public string DescriptInvent { get; set; }
        public string StateInvent { get; set; }
    }
}
