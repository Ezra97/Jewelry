using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jewelry.Models
{
    public class Jewel 
    {        
        public Jewel() // הפונקצייה בודקת אם אין מחירים או תמונה במערכת אז ליצור מחירים או תמונה חדשה במערכת      
        {
            if(Prices == null) 
                Prices = new List<Price>();
            if (Photo == null) 
                Photo = new List<Photo>(); 
        }
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(60)]        
        public string Name { get; set; }
        public Group Parent { get; set; }

        [Default("")]
         public string Description { get; set; } 

        [Default(false)]
        public bool Male { get; set; }

        [Default(true)]
        public bool Female { get; set; }
        [Required]
        public ICollection<Photo> Photo { get; set; }
        
        public float Weight { get; set; }
        
        public string Color { get; set; }

        public ICollection<Price> Prices { get; set; }
    }
}
