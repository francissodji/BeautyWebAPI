using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Size
    {
        [Key]
        public int IdSize { get; set; }

        [MaxLength(100)]
        public string? TitleSize { get; set; }

        public bool IsDefault { get; set; }

        public int IdCompany { get; set; }


        //Navigation Property

        //public List<ExtratStyle> ExtratStyles { get; set; }

        //To Appointment
        //public List<Appointment> Appointment { get; set; }
    }
}
