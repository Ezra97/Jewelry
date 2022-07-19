using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jewelry.Models;

namespace Jewelry.ViewModel
{
    public class VMOrder
    {
        public VMOrder()
        {
            Order = Shop.GetShop().Order;
            VMGroup = new VMGroup(Shop.GetShop().Root); 
            Jewels = new List<VMJewelAndLastPrice>();
        }
        public VMOrder(Order order,List<VMJewelAndLastPrice> Jewels,int? GroupID)
        {
            Order = order;
            if (GroupID != null)
                VMGroup = new VMGroup(Shop.GetShop().Groups.ToList().Find(g => g.ID == GroupID.Value));
            else
                VMGroup = new VMGroup(Shop.GetShop().Root);
            this.Jewels = Jewels;
        }
        public Order Order { get; set; }
        public VMGroup VMGroup { get; set; }
        public List<VMJewelAndLastPrice> Jewels { get; set; }
        public decimal SumPrice { get; set; }
        //public void AddJewelToOrder(Jewel jewel)// הפונקצייה מוסיפה תכשיט להזמנה ומעדבן את המחיר של התכשיט
        //{
        //    Order.JewelryInOrder.Add(new Models.JewelryInOrder(jewel, Order));
        //    SumPrice += (new VMJewelAndLastPrice().LastPrice(jewel).price * (100 - new VMJewelAndLastPrice().LastPrice(jewel).Discount));
        //}
        //public void AddPriceSending(decimal PriceSending)//הפונקצייה מוסיפה דמי משלוח
        //{
        //    Order.PriceSending = PriceSending; 
        //    SumPrice += PriceSending;
        //}
    }
}
