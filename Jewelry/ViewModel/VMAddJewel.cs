using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Jewelry.Models;
using Microsoft.AspNetCore.Http;

namespace Jewelry.ViewModel
{
    public class VMAddJewel
    {
        public VMAddJewel() 
        { 
            Jewel = new Jewel(); 
            Groups = new List<Group>(); 
            Price = new Price(); 
        }
        public Jewel Jewel { get; set; }
        public List<Group> Groups { get; set; }
        public int ParentID { get; set; }
        public IFormFile file { get;set; }
        public Price Price { get; set; }
    }// להציג כמה דברים במקביל
}
