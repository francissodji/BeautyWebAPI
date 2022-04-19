using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class CashRegisterState
    {
        public int IdRegisterStatus { get; set; }
        public DateTime DateStatus { get; set; }
        public decimal TheoryBalance { get; set; }
        public decimal PhysicalBalance { get; set; }
        public string StateRegister { get; set; }
        public int IdRegister { get; set; }
    }
}
