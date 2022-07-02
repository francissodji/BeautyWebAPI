using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class AppointWithLibel
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

        public int IDClientAppoint { get; set; }

        public int IDStyleAppoint { get; set; }

        public int IDLenghtAppoint { get; set; }

        public int IdSizeAppoint { get; set; }

        public string DesigStyle { get; set; }
        public string TitleSize { get; set; }
        public string TitleExtrat { get; set; }

        public string ClientFullName { get; set; }

        public string ServiceTitle { get; set; }

        public string TakeDownTitle { get; set; }

        public double TotalCostBraiding { get; set; }

    }
}
