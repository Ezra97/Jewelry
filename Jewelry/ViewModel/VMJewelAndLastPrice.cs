using Jewelry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewelry.ViewModel
{
    public class VMJewelAndLastPrice
    {
        public VMJewelAndLastPrice() 
        { 
            Jewel = new Jewel();
            Price = new Price();
        }
        public VMJewelAndLastPrice(Jewel jewel)
        {
            Jewel = jewel;
            Price = LastPrice(Jewel);            
        }
        public Price LastPrice(Jewel jewel)//  הפונקצייה מקבלת תכשיט שהגולש בחר ואם יש מחיר של התכשיט וגם אם המחיר סופי של התכשיט הוא גדול מהתאריך של היום אז מחזירים את המחיר הסופי של התכשיט ואחרת מוחקים את המחיר הסופי ומחזירים את מחיר הסופי החדש של התכשיט ובכל מקרא מחזירים את המחיר החדש ומוסיפים שנה לשנה הנוכי 
        {
            if (jewel.Prices.Count>0)
            {
                if (jewel.Prices.Last().UpToDate > DateTime.Now)
                {
                    return jewel.Prices.Last();
                }
                else
                {
                    jewel.Prices.Remove(jewel.Prices.Last());
                    return LastPrice(jewel);
                }
            }
            return new Price(0, 0, DateTime.Now.AddYears(1));
        }
        public Jewel Jewel { get; set; }
        public Price Price { get; set; }
        public string AddImageTitle
        {
            get
            {
                return "הוספת תמונה ל" + Jewel.Name;
            }
        }
        public string MaleTitle
        {
            get
            {
                if (Jewel.Male)
                    return "מתאים לגבר";
                return "לא מתאים לגבר";
            }
        }
        public string FemailTitle
        {
            get
            {
                if (Jewel.Female)
                    return "מתאים לאשה";
                return "לא מתאים לאשה";
            }
        }
        public string WeightTitle
        {
            get
            {
                return "משקל " + Jewel.Weight;
            }
        }
        public string ColorTitle
        {
            get
            {
                return "צבע " + Jewel.Color;
            }
        }
        public decimal PriceTitle
        {
            get
            {
                return Price.price;
            }
        }
        public string DiscountTitle
        {
            get
            {
                return Price.Discount + "%";
            }
        }
        public decimal FinalTitle
        {
            get
            {
                return Price.FinalPrice;
            }
        }
    }
}
