using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class UserAuthentResponse
    {
        public int IdUser { get; set; }

        public int IdClientBraider { get; set; }

        public string FirstNClientBraider { get; set; }
        public string MiddleNClientBraider { get; set; }

        public string LastNClientBraider { get; set; }

        public string AccessTocken { get; set; }

    }
}
