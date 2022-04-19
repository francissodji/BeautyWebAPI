using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Extrat
    {
        [Key]
        public int IdExtrat { get; set; }

        [MaxLength(100)]
        public string? TitleExtrat { get; set; }



        //Navigation Properties
        public List<ExtratStyle> ExtratStyles { get; set; }

        //To Appointment
        public List<Appointment> Appointment { get; set; }
    }
}
