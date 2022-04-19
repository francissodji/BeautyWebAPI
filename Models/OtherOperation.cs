using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class OtherOperation
    {
        public int IdOtherOperat { get; set; }
        public decimal CostOtherOperat { get; set; }
        public DateTime DateOtherOperat { get; set; }
        public int IdRegOtherOperat { get; set; }
        public int IdTypeOperat { get; set; }
        public int IdJobDone { get; set; }
    }
}
