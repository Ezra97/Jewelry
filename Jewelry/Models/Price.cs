using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jewelry.Models
{
    public class Price
    {
        public Price()// הפונקצייה מעדכנת את התאריך
        { 
            UpToDate = DateTime.Now.AddYears(1); 
        }
        public Price(decimal price,int discount,DateTime upToDate)// זה הבנאי בשביל המחלקה הזאת
        {
            this.price = price; 
            Discount = discount; 
            UpToDate = upToDate;
        }
        [Key]
        public int ID { get; set; }  
        public Jewel Jewel { get; set; }
        [Required]
        [Display(Name ="מחיר")]
        public decimal price { get; set; }
        [Default(0)]
        [Display(Name = "הנחה")]
        public int Discount { get; set; }
        [Default("2020-06-06")]
        [DataType(DataType.Date)]
        [Column(TypeName ="datetime2")]
        [Display(Name = "עד לתאריך")]
        public DateTime UpToDate { get; set; }
        public decimal FinalPrice 
        { 
            get 
            { 
                return price * (100 - Discount)/100; 
            } 
        }
    }
}
