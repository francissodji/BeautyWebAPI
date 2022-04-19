using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Theword
    {
        [Key]
        public int IDPassword { get; set; }

        [Required]
        public int IDUser { get; set; }

        [Required]
        [MaxLength(1000)]
        public string UserPassword { get; set; }

        public int NumConnection { get; set; }

        public DateTime DateBeginPw { get; set; }

        public DateTime DateEndPw { get; set; }
    }
}

