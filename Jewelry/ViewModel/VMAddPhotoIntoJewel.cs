using Jewelry.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;//example of library of view model onlys

namespace Jewelry.ViewModel
{
    public class VMAddPhotoIntoJewel
    {
        public VMAddPhotoIntoJewel() 
        {
            Jewel = new Jewel();
        }
        public Jewel Jewel { get; set; }
        public int JewelID { get; set; }
        public IFormFile File { get; set; }
        public string Title 
        { 
            get 
            { 
                return "הוספת תמונה ל" + Jewel.Name; 
            } 
        }
    }
}
