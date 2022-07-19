using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Jewelry.Models;
using Microsoft.AspNetCore.Http;

namespace Jewelry.ViewModel
{
    public class VMCreateGroup
    {
        public VMCreateGroup() 
        { 
            Group = new Group();
            Groups = new List<Group>(); 
        }
        public int ParentID { get; set; }
        public Group Group { get; set; }
        [Display(Name ="תמונה")]
        public IFormFile File { get; set; }
        public List<Group> Groups { get; set; }
    }
}
