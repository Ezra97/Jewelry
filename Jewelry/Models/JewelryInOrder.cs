using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jewelry.Models
{
    public class JewelryInOrder
    {
        public JewelryInOrder() 
        { 
            Jewel = new Jewel(); 
            Order = new Order();
            AddQuantity(); 
        }
        public JewelryInOrder(Jewel jewel, Order order) 
        { 
            Jewel = jewel; 
            Order = order; 
            AddQuantity(); 
        }
        [Key]
        public int ID { get; set; }
        public Jewel Jewel { get; set; }
        public Order Order { get; set; }
        [Display(Name ="מחיר סופי")]
        public Price Price 
        {
            get
            {
                Price LastPrice = new ViewModel.VMJewelAndLastPrice(Jewel).Price;
                Price price = new Price(LastPrice.price * Quantity, LastPrice.Discount, LastPrice.UpToDate);
                return price;
            }
        }
        [Display(Name = "כמות")]
        public int Quantity { get; set; }

        public void AddQuantity() // הפונקצייה היא מוסיף כמות אחרי שחישבנו את כמות בפונקצייה סט קוונטטי
        {
            SetQuantity(1);
        }
        public void MinusQuantity()// הפונקצייה היא בודקת אם יש כמות בהזמנה אז להסיר את המחיר של התכשיט שהגולש בחר, ואם אין כמות אז להסיר את התכשיט מההזמנה
        {
            if (Quantity > 1)
                SetQuantity(-1);
            else
                this.Order.JewelryInOrder.Remove(this);
        }
        private void SetQuantity(int add)// הפונקצייה היא מקבלת מחיר של תכשיט שהגולש בחר ומוסיף אותו לכמות של ההזמנה
        {
            Quantity += add;
        }
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
                return "לא מתאים לאישה"; 
            } 
        }
        public string WeightTitle 
        {
            get 
            { 
                return "גודל " + Jewel.Weight; 
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
