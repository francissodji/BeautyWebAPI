using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.DTOs
{
    public class ExtratStyleReadDto
    {
        public int IdExtratStyle { get; set; }

        public int IdStyle { get; set; }

        public int IDExtrat { get; set; }

        public int IdSize { get; set; }

        public double CostExtra { get; set; } 

        public double CostTouchUpExtra { get; set; }

        public double CostExtraSize { get; set; }

        public double CostBusyExtra { get; set; }

        public double CostHairDeductExtra { get; set; }

        //public string DesigStyle { get; set; }

        //public string TitleSize { get; set; }

        //public string TitleExtrat { get; set; }
    }
}
