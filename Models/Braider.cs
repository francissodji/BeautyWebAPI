using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Braider
    {
        public int IDBraider { get; set; }
        public string FnameBraider { get; set; }
        public string MnameBraider { get; set; }
        public string LnameBraider { get; set; }
        public string PhoneBraider { get; set; }
        public string CelBraider { get; set; }
        public string StreetBraider { get; set; }
        public string CountyBraider { get; set; }
        public string ZipCodeBraider { get; set; }
        public string EmailBraider { get; set; }
        public int IDUserBraider { get; set; }
        public bool OwnerStatus { get; set; }
        public bool IsBraiderUseRegister { get; set; }
        public bool IdRegisterBraider { get; set; }
        public string StateBraider { get; set; }
        public bool DisplayRegister { get; set; }
    }
}
