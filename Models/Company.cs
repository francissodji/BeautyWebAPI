using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Company
    {
        public int IDComp { get; set; }
        public string AcronymComp { get; set; }
        public string TitleComp { get; set; }
        public string PhoneOffice { get; set; }
        public string PhoneOwner { get; set; }
        public string StreetComp { get; set; }
        public string CountyComp { get; set; }
        public string ZipcodeComp { get; set; }
        public float PartPayeBraid { get; set; }
        public int IDOwnerBraider { get; set; }
        public decimal CostHairDeduct { get; set; }
        public decimal PriceTakeOff { get; set; }
        public int IdMainRegister { get; set; }
        public float StateTaxOnSale { get; set; }
        public float StateTaxOnBraiding { get; set; }
        public string StateCompany { get; set; }
        public string EmailComp { get; set; }
        public string WebsiteComp { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
