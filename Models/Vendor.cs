using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Vendor
    {
        public int IDVendor { get; set; }
        public string TitleVendor { get; set; }
        public string PhoneOffice { get; set; }
        public string PhoneCell { get; set; }
        public string StreetVendor { get; set; }
        public string CountyVendor { get; set; }
        public string ZipCodeVendor { get; set; }
        public string StateVendor { get; set; }
        public string EmailVendor { get; set; }
        public string WebSiteVendor { get; set; }
    }
}
