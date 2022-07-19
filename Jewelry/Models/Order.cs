using Jewelry.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Jewelry.Models
{
    public class Order
    {
        public Order()
        {
            JewelryInOrder = new List<JewelryInOrder>();
            Customer = new Customer();
            date = DateTime.Now;
        }

        [Key]
        public int ID { get; set; }        
        public int CountJewels
        {
            get
            {
                int sum = 0;
                foreach (JewelryInOrder jewelry in JewelryInOrder)
                {
                    sum += jewelry.Quantity;
                }
                return sum;
            }
        }
       
        public Customer Customer { get; set; }
        [Required]        
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        public DateTime date { get; set; }
        //דמי משלוח
        public decimal PriceSending { get; set; }
        public virtual ICollection<JewelryInOrder> JewelryInOrder { get; set; }
        public bool IfPay { get; set; }
        [Display(Name ="האם שולם")]
        public string IfISPay 
        { 
            get 
            { 
                if (IfPay) 
                    return "שולם"; 
                return "לא שולם"; 
            } 
        }
        [Display(Name ="כתובת למשלוח")]
        public string Address 
        { 
            get 
            { 
                return City + " " + Street + " " + Number; 
            } 
        }
        [Display(Name ="עיר")]
        public string City { get; set; }
        [Display(Name = "רחוב")]
        public string Street { get; set; }
        [Display(Name = "מספר")]
        public string Number { get; set; }
        public decimal PriceTotal { get; set; }
        [Display(Name = "האם בוצע")]
        public bool IsDone { get; set; }
        [Display(Name = "האם בוצע")]
        public string IfIsDone 
        { 
            get 
            { 
                if (IsDone) 
                    return "בוצע";
                return "לא בוצע"; 
            } 
        }

        public bool SendMailOrder() // הפונקצייה היא מכינה אימייל חדשה בשביל הגולש שבוצאה הזמנה, אם הכמות והמחיר והתמונה  של התכשיטים שהגולש קנה וגם הדמי משלוח והמחיר סופי והכתובת שאליה המשלוח יגיע
        {
            int index = 0;
            MailMessage mail = new MailMessage(new MailAddress("ofek8852@gmail.com", "אופק חרזי"), new MailAddress(Customer.Email, Customer.Name));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            string message = "הזמנתך מספר " + ID + " נקלטה במערכת. \n";
            message += "ההזמנה כוללת: \n";
            
            foreach (JewelryInOrder jewelry in JewelryInOrder)
            {
                index++;
                message += index + ". " + jewelry.Jewel.Description + " כמות " + jewelry.Quantity + " מחיר " + jewelry.Price.price + " . \n";
                mail.Attachments.Add(new Attachment(new MemoryStream(jewelry.Jewel.Photo.First().MyPhoto), jewelry.Jewel.Name + ".jpg"));
            }
            message += " דמי משלוח " + PriceSending + " .\n";
            message += " סך הכל לתשלום " + PriceTotal + " .\n";
            message += " תישלח לכתובת " + Address + " .\n";
            message += " טלפון: " + Customer.Phone_Number + " .\n";
            message += "המשלוח יגיע עד 7 ימי עסקים";
            try
            {
                mail.Subject = "הזמנתך מספר " + ID;
                mail.Body = message;
                smtp.Credentials = new NetworkCredential("ofek8852@gmail.com", "ofek1234");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
