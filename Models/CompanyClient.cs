using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class CompanyClient
    {
        public int IdCompClient { get; set; }

        public int IdCompany { get; set; }

        public int IdClient { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
