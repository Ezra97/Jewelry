using Jewelry.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jewelry.ViewModel
{
    public class VMEditGroup
    {
        public Group Group { get; set; }
        [Display(Name ="תמונה")]
        public IFormFile File { get; set; }
        public int GroupID { get; set; }
    }
}
