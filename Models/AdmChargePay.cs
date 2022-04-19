using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class AdmChargePay
    {
        public int IdAdmchargePay { get; set; }
        public int IdAdmcharge { get; set; }
        public decimal CostChargePay { get; set; }
        public DateTime DatePayment { get; set; }
        public int IdTypeOperat { get; set; }
    }
}
