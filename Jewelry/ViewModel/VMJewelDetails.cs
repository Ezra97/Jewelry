using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jewelry.Models;
using Microsoft.AspNetCore.Http;

namespace Jewelry.ViewModel
{
    public class VMJewelDetails
    {
        public VMJewelDetails()
        {
            JewelDetails = new Jewel();
            JewelsInGroup = new List<VMJewelAndLastPrice>();
            Groups = new List<Group>();
        }
        public List<Group> Groups { get; set; }
        public int ParentID { get; set; }
        public Jewel JewelDetails { get; set; }
        public ICollection<VMJewelAndLastPrice> JewelsInGroup { get; set; }
        public Price Price 
        { 
            get 
            { 
                return new VMJewelAndLastPrice().LastPrice(JewelDetails); //שהוא לוקח את המחיר ההכי מעודכן לפי תאריך
            } 
        }
        public string AddImageTitle 
        { 
            get 
            { 
                return "הוספת תמונה ל" + JewelDetails.Name; 
            }
        }
    }
}
