using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class CashRegisterTransfer
    {
        public int IDRegistTransf { get; set; }
        public DateTime DateTransf { get; set; }
        public decimal AmountTransf { get; set; }
        public int IDRegisterSender { get; set; }
        public int IDRegisterReceiver { get; set; }
    }
}
