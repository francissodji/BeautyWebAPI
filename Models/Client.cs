using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Client
    {
        [Key]
        public int IDClient { get; set; }

        [Required]
        [MaxLength(150)]
        public string FnameClient { get; set; }

        [MaxLength(50)]
        public string? MnameClient { get; set; }


        [MaxLength(100)]
        public string? LnameClient { get; set; }


        [MaxLength(14)]
        public string? PhoneClient { get; set; }


        [MaxLength(1)]
        public string? SexClient{ get; set; }

        [DataType(DataType.Date)]
        public DateTime? DOBClient { get; set; }

        [Required]
        [Phone]
        [MaxLength(14)]
        public string CelClient { get; set; }


        [MaxLength(150)]
        public string StreetClient { get; set; }

        [MaxLength(75)]
        public string CountyClient { get; set; }

        [MaxLength(10)]
        public string ZipCodeClient { get; set; }

        [MaxLength(100)]
        public string? EmailClient { get; set; }

        [MaxLength(2)]
        public string? StateClient { get; set; }


        //Navigation Properties
            //User
        public int IDUser { get; set; } //This is the foreign key from table USER

        public User User { get; set; }


        //To Appointment
        public List<Appointment> Appointment { get; set; }

    }
}
