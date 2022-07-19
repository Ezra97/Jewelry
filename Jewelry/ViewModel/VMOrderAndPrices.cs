using Jewelry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewelry.ViewModel
{
    public class VMOrderAndPrices
    {
        public VMOrderAndPrices() 
        { 
            Order = new Order(); 
        }
        public VMOrderAndPrices(Order order) 
        { 
            Order = order; 
        }
        public Order Order { get; set; }
        public decimal SumPrices 
        { 
            get 
            { 
                return PriceTotal - PriceSending; 
            } 
        }
        public decimal PriceSending 
        { 
            get 
            { 
                return Order.PriceSending; 
            } 
        }
        public decimal PriceTotal 
        { 
            get 
            { 
                return Order.PriceTotal; 
            } 
        }
    }
}
