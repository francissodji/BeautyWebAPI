using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Souscription
    {
        [Key]
        public int IdSuscript { get; set; }

        public int IdAccountSouscrip { get; set; }

        [MaxLength(20)]
        public String TypeSuscript { get; set; } // FreeTrial, Premium, Gold, Diamond

        public DateTime DateBeginSouscrip { get; set; }

        public DateTime? DateEndSouscrip { get; set; }

        public int PeriodSouscrip { get; set; } // 1= Monthly, 3 = Trimestre, 6 Semestrial; 12 annual

        public CompanyAccount CompanyAccounts { get; set; } // Relation ship with CompanyAccount
    }
}
