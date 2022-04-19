using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class JobConsumption
    {
        public int IDJobConsump { get; set; }
        public int IDJobDone { get; set; }
        public int IDHair { get; set; }
        public int IDColor { get; set; }
        public float QttyPacks { get; set; }
        public bool HairProvided { get; set; }
    }
}
