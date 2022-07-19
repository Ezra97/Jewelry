using Jewelry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewelry.ViewModel
{
    public class VMAllOrders
    {
        public VMAllOrders() 
        { 
            Order = new VMOrderAndPrices();
            Orders = new List<VMOrderAndPrices>(); 
        }
        public VMOrderAndPrices Order { get; set; }
        public List<VMOrderAndPrices> Orders { get; set; }
    }
}
