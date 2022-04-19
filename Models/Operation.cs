using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Operation
    {
        public int IDOperat { get; set; }
        public int IDTransact { get; set; }
        public DateTime DateOperat { get; set; }
        public decimal CostOperat { get; set; }
        public int IdTypeOperat { get; set; }
        public int IdRegistOperat { get; set; }
        public string CodModPaie { get; set; }
        public bool CancelOperat { get; set; }
        public int OrderDayOperat { get; set; }
        public string DescripOperat { get; set; }
    }
}
