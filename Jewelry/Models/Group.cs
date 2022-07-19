using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Jewelry.Models
{
    public class Group
    {        
        public Group()// הפונקצייה היא בודקת אם אין תכשיטים או קבוצות במערכת אז ליצור תכשיט או קבוצה חדשה
        {           
            if(Jewels==null)
                Jewels = new List<Jewel>();
            if(Groups ==null)
                Groups = new List<Group>();
        }
        [Key]
        public int ID { get ;  set ;  }
        [Required]
       // Max Length = 20 
        public string Name { get; set; }
        public Group Parent { get; set; }
        // Max Length = 50
        public string Description { get; set; }
        [Display(Name ="תמונה")]
        public byte[] Photo { get; set; }
        public   ICollection<Jewel> Jewels { get; set; }
        public   ICollection<Group> Groups { get; set; }
        public void SetPhoto(IFormFile file) // הפונקצייה מקבלת את ההתמונה שהגולש העלה למערכת ושומר אותו
        {
            if (file == null) 
                return;
            MemoryStream stream = new MemoryStream();
            file.CopyTo(stream);
            Photo = stream.ToArray();
        }
        public void addGroup(Group group)// הפונקצייה היא מקבלת קבוצה ומוסיף אותה למערכת
        {
            this.Groups.Add(group);           
            group.Parent = this;
        }
        public void addJewel(Jewel jewel)// הפונקצייה היא מקבלת תכשיט ומוסיף אותו למערכת
        {
            this.Jewels.Add(jewel);         
            jewel.Parent = this;
        }
    }
}
