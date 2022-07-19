using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Jewelry.Models
{
    public class Shop : DbContext
    {
        private static Shop shop;
        private Group root;
        public Order Order { get; set; }
        private Shop() : base("Server=localhost\\SQLEXPRESS07;Database=Jewelry;Trusted_Connection=True;")//connection string
        {
            Database.SetInitializer<Shop>(new DropCreateDatabaseIfModelChanges<Shop>());
            Order = new Order();
            if (Groups.Count() == 0)
            {
                root = new Group() 
                {  
                    Name = "חנות תכשיטים" 
                };
                Groups.Add(root);
                SaveChanges();
                 //Seed();
            }
            else
                root = Groups.First();
        }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Jewel> Jewels { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<JewelryInOrder> jewelryInOrders { get; set; }
        //private void Seed() //הפונקציה היא מכיל את כל הקבוצות באתר
        //{
        //    Group group = new Group() { Name = "תליונים" };
        //    root.addGroup(group);
        //    SaveChanges();
        //    Group group1 = new Group() { Name = "תליוני זהב" };
        //    group.addGroup(group1);
        //    SaveChanges();
        //    Group group2 = new Group() { Name = "תליוני כסף" };
        //    group.addGroup(group2);
        //    SaveChanges();
        //    Jewel jewel = new Jewel() { Name = "תליון יהלום" };
        //    group1.addJewel(jewel);
        //    SaveChanges();
        //}

        public static Shop GetShop()// הפונקצייה הזאצ היא מאוד חשובה בגלל שהיא אחראית על יצירת הבסיס נתונים חדש במידע ויש שינוי ב-שופ
        {
            if (shop == null)
                shop = new Shop();
            return shop;
        }

        public Group Root 
        { 
            get 
            { 
                return root; 
            } 
        }

        public void RemoveJewel(Jewel jewel)
        {
            RemoveAllPhotosByJewel(jewel);
            RemoveAllPricesByJewel(jewel);
            Jewels.Remove(jewel);
        }
        private void RemoveAllJewelsByGroup(Group group)// הפונקצייה היא מסירה את בל התכשיטים לפי הקבוצה שהוא נמצא בו 
        {
            if(group.Jewels.Count>0)
            {
                List<int> JewelIDs = new List<int>();
                foreach (Jewel jewel in group.Jewels)
                {
                    RemoveAllPhotosByJewel(jewel);
                    RemoveAllPricesByJewel(jewel);
                    JewelIDs.Add(jewel.ID);
                }
                foreach (int ID in JewelIDs)
                {
                    Jewels.Remove(Jewels.ToList().Find(j => j.ID == ID));
                }
            }
        }
        private void RemoveAllPricesByJewel(Jewel jewel)// הפונקצייה היא מסירה את כל המחירים לפי התכשיט שהוא נמצא בו
        {
            if (jewel.Prices.Count>0)
            {
                List<int> PricesIDs = new List<int>();
                foreach (Price price in jewel.Prices)
                {
                    PricesIDs.Add(price.ID);
                }
                foreach (int ID in PricesIDs)
                {
                    Prices.Remove(Prices.ToList().Find(p => p.ID == ID));
                }
            }
        }
        private void RemoveAllPhotosByJewel(Jewel jewel)// הפונקצייה היא מסירה את כל התמונות לפי התכשיט שהוא נמצא בו 
        {
            if (jewel.Photo.Count > 0)
            {
                List<int> PhotosIDs = new List<int>();
                foreach (Photo photo in jewel.Photo)
                {
                    PhotosIDs.Add(photo.ID);
                }
                foreach (int ID in PhotosIDs)
                {
                    Photos.Remove(Photos.ToList().Find(p => p.ID == ID));
                }
            }
        }
        public void RemoveGroup(Group group)// הפונקצייה הוא מסירה את הקבוצה לפי הקבוצה שהיא מקבלת
        {
            if (group.Groups.Count > 0)
            {
                List<int> groupIDs = new List<int>();
                RemoveGroup(group, groupIDs);
                foreach (int ID in groupIDs)
                {
                    Groups.Remove(Groups.ToList().Find(g => g.ID == ID));
                }
            }
            RemoveAllJewelsByGroup(group);
            Groups.Remove(group);
        }
        private void RemoveGroup(Group group, List<int> groupIDs)//  הפונקצייה היא מסירה את הקבוצה לפי הקבוצה והתעודת זהות שלה שהיא מקבלת
        {
            if (group.Groups.Count > 0)
                foreach (Group group1 in group.Groups)
                {
                    RemoveGroup(group1, groupIDs);
                }
            groupIDs.Add(group.ID);
            RemoveAllJewelsByGroup(group);
        }
    }
}
