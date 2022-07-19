using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jewelry.Models;

namespace Jewelry.ViewModel
{
    public class VMGroup
    {
        public VMGroup() 
        { 
            Jewels = new List<VMJewelAndLastPrice>();
            ParentsGroups = new List<Group>(); 
        }
        public VMGroup(Group group)
        {
            Group = group;
            Jewels = new List<VMJewelAndLastPrice>();
            ParentsGroups = new List<Group>();
            AddJewelsIntoList(group);
            if (group.Parent != null)
                AddParentIntoList(group.Parent);
        }
        private void AddParentIntoList(Group group) // הפונקצייה הזאת מקבלת קבוצה שהגולש בחר ומוסיף אותה להורה של הקבוצה 
        {
            if (group.Parent != null)
                AddParentIntoList(group.Parent);
            ParentsGroups.Add(group);
        }
        private void AddJewelsIntoList(Group group)// הפונקצייה מקבלת קבוצה שהגולש בחר ואם יש תכשיטים אז מוסיפים את המחיר סופי לתכשיט בקבוצה וגם אם יש קבוצה אז מוסיפים את התכשיט לקבוצה  
        {
            if (group.Jewels.Count > 0)
                foreach (Jewel jewel in group.Jewels)
                {
                    Jewels.Add(new VMJewelAndLastPrice(jewel));
                }
            if (group.Groups.Count > 0)
                foreach (Group group1 in group.Groups)
                {
                    AddJewelsIntoList(group1);
                }
        }
        public Group Group { get; set; }
        public ICollection<VMJewelAndLastPrice> Jewels { get; set; }
        public ICollection<Group> ParentsGroups { get; set; }
    }
}
