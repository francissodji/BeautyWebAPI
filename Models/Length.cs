using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Length
    {
        [Key]
        public int IdLength { get; set; }

        [MaxLength(100)]
        public string? TitleLength { get; set; }

        public bool IsDefault { get; set; }

        public int IdCompany { get; set; }



        //Navigation Properties
        //public List<ExtratStyle> ExtratStyles { get; set; }

        //To Appointment
        //public List<Appointment> Appointment { get; set; }
    }
}
