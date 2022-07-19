using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jewelry.Models
{
    public class Customer
    {
        public Customer() 
        { 
            Name = "התחבר"; 
        }
        public Customer(string Name, string EmailAddress, string PhoneNumber)
        {
            this.Name = Name; 
            this.Email = EmailAddress; 
            this.Phone_Number = PhoneNumber;
        }
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [EmailAddress (ErrorMessage ="כתובת מייל אינה נכונה") ]
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        [Display(Name ="סיסמא")]
        public string Password { get; set; }

    }
}
