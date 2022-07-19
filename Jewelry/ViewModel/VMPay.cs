using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jewelry.ViewModel
{
    public class VMPay
    {
        public VMPay() 
        { 
            OrderPay = new VMOrderPay(); 
            ValidDateCreditCard = DateTime.Now.AddMonths(1).AddYears(1); 
        }
        public VMOrderPay OrderPay { get; set; }
        [Required]
        public string NumberCreditCard { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ValidDateCreditCard { get; set; }
        [Required]
        public string CVV { get; set; }

    }
}
