using BeautyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.DTOs
{
    public class ClientCreateDto
    {

        public string FnameClient { get; set; }

        public string MnameClient { get; set; }

        public string LnameClient { get; set; }

        public string PhoneClient { get; set; }

        public DateTime DOBClient { get; set; }

        
        public string CelClient { get; set; }

        public string SexClient { get; set; }

        public string StreetClient { get; set; }

        public string CountyClient { get; set; }

        public string ZipCodeClient { get; set; }

        public string EmailClient { get; set; }

        public string StateClient { get; set; }

        public int IDUser { get; set; }

        //public User TheUser { get; set; }
    }
}
