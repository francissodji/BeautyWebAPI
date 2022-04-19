using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Partner
    {
        public int IdPartener { get; set; }
        public string TitlePartener { get; set; }
        public string CelPartener { get; set; }
        public string PhonePartener { get; set; }
        public string StreetPartener { get; set; }
        public string CountyPartener { get; set; }
        public string StatePartener { get; set; }
        public string EmailPartener { get; set; }
        public string ZipCodePartener { get; set; }
    }
}
