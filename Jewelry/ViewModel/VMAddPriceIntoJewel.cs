using Jewelry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewelry.ViewModel
{
    public class VMAddPriceIntoJewel
    {
        public VMAddPriceIntoJewel() 
        { 
            Jewel = new Jewel(); 
            Price = new Price(); 
        }
        public Jewel Jewel { get; set; }
        public int JewelID { get; set; }
        public Price Price { get; set; }
        public string Title 
        { 
            get 
            { 
                return "הוספת מחיר ל" + Jewel.Name; 
            } 
        }
    }
}
