using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class InventoryDetail
    {
        public int IDInventDetail { get; set; }
        public int IDInvent { get; set; }
        public int IDProdInvent { get; set; }
        public int QttyInvent { get; set; }
        public int IDHairInvent { get; set; }
        public int IDColorInvent { get; set; }
    }
}
