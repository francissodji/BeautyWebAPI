using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class AdmCharge
    {
        public int IdAdmcharge { get; set; }
        public int IdPartener { get; set; }
        public decimal CostCharge { get; set; }
        public DateTime DateCharge { get; set; }
        public string DescriptCharge { get; set; }
    }
}
