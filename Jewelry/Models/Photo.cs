using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jewelry.Models
{
    public class Photo
    {

        public Photo() { }

        public Photo(byte[] photo) 
        { 
            MyPhoto = photo; 
        }
        [Key]
        public int ID { get; set; }
        public Jewel Parent { get; set; }
        [Required]
        public Byte[] MyPhoto { get; set; }
    }
}
