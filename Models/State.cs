using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class State
    {
        [Key]
        [MaxLength(2)]
        public string CodeState { get; set; }


        [MaxLength(100)]
        public string? DesignState { get; set; }
    }
}
