using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class CompanyAccount
    {
        [Key]
        public int IdAccount { get; set; }

        public int IdCompany { get; set; }

        public DateTime DateOpened { get; set; }

        public bool AutoRenew { get; set; }

        [MaxLength(20)]
        public string StateUsed { get; set; } // ACTIVE, SUSPENDED, CLOSED

        public Company Company { get; set; } // Relation ship with CompanyAccount

        public ICollection<Subscription> Subscriptions { get; set; } // Relation ship with Souscription

    }
}
