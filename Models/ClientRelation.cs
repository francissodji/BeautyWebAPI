using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class ClientRelation
    {
        public int IDClientRelation { get; set; }
        public int IdClientParent { get; set; }
        public int IdClientRelative { get; set; }
    }
}
