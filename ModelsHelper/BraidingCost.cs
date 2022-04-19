using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.ModelsHelper
{
    public class BraidingCost
    {
        public int IdStyle { get; set; }

        public int IdSize { get; set; }

        public int IdLength { get; set; }

        public char TypeService { get; set; }

        public bool IsTakeDown { get; set; }

        public double STCostStyle { get; set; }

        public double STCostTouchUp { get; set; }
        public double STPriceTakeOffHair { get; set; }
        
        public double ESCostExtra { get; set; }
        public double ESCostTouchUpExtra { get; set; }
        public double ESCostExtraSize { get; set; }
        public double ESCostBusyExtra { get; set; }

        public double ESCostHairDeductExtra { get; set; }

        public double TotalCost { get; set; }
    }
}
