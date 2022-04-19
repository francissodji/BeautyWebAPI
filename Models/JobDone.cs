using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class JobDone
    {
        public int IDJobDone { get; set; }
        public int IDAppoint { get; set; }
        public DateTime DateJobDone { get; set; }
        public DateTime BegintimeJob { get; set; }
        public DateTime TimeEndJob { get; set; }
        public string Directfeedback { get; set; }
        public int IDStyleJob { get; set; }
        public char TypeserviceJob { get; set; }
        public bool AddTakeoffJob { get; set; }
        public int IDDiscount { get; set; }
        public int IdExtraJobDone { get; set; }
        public string ClientBehaviourNote { get; set; }
        public int IdBraiderOwnerRelate { get; set; }
    }
}
