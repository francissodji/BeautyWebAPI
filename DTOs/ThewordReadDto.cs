using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.DTOs
{
    public class ThewordReadDto
    {

        public int IDUser { get; set; }

        public string UserPassword { get; set; }

        public int NumConnection { get; set; }

        public DateTime DateBeginPw { get; set; }

        public DateTime DateEndPw { get; set; }
    }
}
