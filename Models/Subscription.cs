using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Subscription
    {
        [Key]
        public int IdSubscript { get; set; }

        public int IdAccount { get; set; }

        public int TypeSubscript { get; set; }

        public int PeriodSubscript { get; set; } // => 1 mensual; 3 = 3 mounth; 6 = 6 month; 12 = annaul

        public DateTime DateDebSusbscript { get; set; }

        public DateTime DateEndSusbscript { get; set; }

        public DateTime DateAddedbscript { get; set; }
    }
}
