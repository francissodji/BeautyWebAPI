using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Style
    {
        [Key]
        public int IdStyle { get; set; }

        [Required]
        [MaxLength(200)]
        public string DesigStyle { get; set; }

        [MaxLength(3000)]
        public string? DescriptStyle { get; set; }

        public bool HairProvStyle { get; set; } = false;

        public double? CostStyle { get; set; } = 0; //0 = Default value

        public double? PriceTakeOffHair { get; set; } = 0;

        public double? CostTouchUp { get; set; } = 0;

        [MaxLength(1000)]
        public string? PictureStyle { get; set; }



        //Navigation Property

        public List<ExtratStyle> ExtratStyles { get; set; }

        //To Appointment
        public List<Appointment> Appointment { get; set; }
    }
}
