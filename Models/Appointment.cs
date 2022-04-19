using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Appointment
    {
        [Key]
        public int IDAppoint { get; set; }

        [Required]
        public DateTime? DateAppoint { get; set; }

        public bool AddTakeOffAppoint { get; set; }

        [MaxLength(1)]
        public char StateAppoint { get; set; }

        [MaxLength(1)]
        public char Typeservice { get; set; }

        public int? NumberTrack { get; set; }

        public int? IDBraiderAppoint { get; set; }


        public int? IdBraiderOwner { get; set; }


        //navigation

            //Client
        public int IDClientAppoint { get; set; }
        public Client client { get; set; }

            //Style
        public int IDStyleAppoint { get; set; }
        public Style style { get; set; }

            //Length
        public int IDLenghtAppoint { get; set; }
        public Extrat length { get; set; }

        //Size
        public int IdSizeAppoint { get; set; }
        public Size size { get; set; }
    }
}
