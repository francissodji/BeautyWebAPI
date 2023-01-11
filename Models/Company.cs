using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Company
    {
        [Key]
        public int IdComp { get; set; }

        [MaxLength(20)]
        public string AcronymComp { get; set; }

        [MaxLength(200)]
        public string DesignationComp { get; set; }

        [MaxLength(14)]
        public string PhoneOffice { get; set; }

        [MaxLength(14)]
        public string PhoneOwner { get; set; }

        public int IdOwnerBraider { get; set; }
        public float PartPayeBraid { get; set; }

        public decimal CostHairDeduct { get; set; }
        public decimal? CostTakeDow { get; set; }
        public int IdMainRegister { get; set; }
        public float StateTaxOnSale { get; set; }
        public float StateTaxOnBraiding { get; set; }

        [MaxLength(75)]
        public string StreetComp { get; set; }

        [MaxLength(75)]
        public string CountyComp { get; set; }

        [MaxLength(11)]
        public string ZipcodeComp { get; set; }

        [MaxLength(2)]
        public string StateComp { get; set; }

        [MaxLength(100)]
        public string EmailComp { get; set; }

        [MaxLength(100)]
        public string? WebsiteComp { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreationDate { get; set; }

        public bool DateWorkMond { get; set; }
        public bool DateWorkTues { get; set; }
        public bool DateWorkWed { get; set; }
        public bool DateWorkThur { get; set; }
        public bool DateWorkFrid { get; set; }
        public bool DateWorkSatu { get; set; }
        public bool DateWorkSund { get; set; }

        [DataType(DataType.Time)]
        public string TimeWorkBegin { get; set; }

        [DataType(DataType.Time)]
        public string TimeWorkEnd { get; set; }

        public bool AcceptPartialPay { get; set; }

        public float PercentPay { get; set; }

        public decimal AmountPay { get; set; }

        public int MaxBraider { get; set; }

        ///public ICollection<CompanyAccount> CompanyAccounts { get; set; } // Related to Company


    }
}
