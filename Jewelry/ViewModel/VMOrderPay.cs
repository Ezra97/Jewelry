using Jewelry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewelry.ViewModel
{
    public class VMOrderPay
    {
        public VMOrderPay()
        {
            Order = Shop.GetShop().Order;
            Order.PriceSending = ((1000 - SumFinal) / 10);
            if (Order.PriceSending < 0) 
                Order.PriceSending = 0;
            Order.PriceTotal = SumTotal;
        }
        public decimal SumFinal
        {
            get
            {
                decimal sum = 0;
                foreach (JewelryInOrder jewel in Order.JewelryInOrder)
                {
                    sum += jewel.FinalTitle;
                }
                return sum;
            }
        }
        public decimal SumTotal 
        { 
            get 
            { 
                return SumFinal + Order.PriceSending; 
            } 
        }
        public Order Order { get; set; }
    }
}
