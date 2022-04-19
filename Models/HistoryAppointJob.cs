using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class HistoryAppointJob
    {
        [Key]
        public int IdJHistoryAppointJob { get; set; }


        [Required]
        public int IDAppoint { get; set; }

        [Required]
        public int IdClient { get; set; }


        public int? IdStyle { get; set; }

        public int? IdSize { get; set; }

        public int? IdLenght { get; set; }


        [MaxLength(1)]
        [Required]
        public char StateJobHistory { get; set; }

        [Required]
        public DateTime DateJobHistory { get; set; }

        public bool? AddTakeOffAppoint { get; set; }


        [MaxLength(1)]
        public char? Typeservice { get; set; }

        public int? NumberTrack { get; set; }
    }
}
