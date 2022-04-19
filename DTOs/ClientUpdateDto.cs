using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.DTOs
{
    public class ClientUpdateDto
    {
        [Required]
        [MaxLength(150)]
        public string FnameClient { get; set; }

        [MaxLength(50)]
        public string MnameClient { get; set; }

        [Required]
        [MaxLength(100)]
        public string LnameClient { get; set; }

        [Required]
        public string PhoneClient { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOBClient { get; set; }

        [MaxLength(1)]
        public string SexClient { get; set; }

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
        public string EmailClient { get; set; }

        [MaxLength(2)]
        public string StateClient { get; set; }

        public int IDUser { get; set; }
    }
}
