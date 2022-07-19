using System.Collections.Generic;
using System.Linq;
using Jewelry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Jewelry.ViewModel;
using System.Drawing;
using System.Data.Entity;
using System.IO;
using System;

namespace Jewelry.Controllers.Manager
{
    public class managerController : Controller
    {
        // GET: manager
        public ActionResult Index(int? id)
        {
            if (Shop.GetShop().Order.Customer.Email == null) 
                return RedirectToAction("Connect", "Home");
            if(Shop.GetShop().Order.Customer.Email!= "estollon@gmail.com" && Shop.GetShop().Order.Customer.Email != "ofek5597@gmail.com")
                    return RedirectToAction("Index", "Home");
            List<Jewel> jewels = Shop.GetShop().Jewels.Include(j => j.Parent).Include(j => j.Photo).Include(j => j.Prices).ToList();
            List<Group> groups = Shop.GetShop().Groups.Include(g => g.Groups).Include(g => g.Jewels).ToList();
            if (id == null || groups.Find(g => g.ID == id) == null)
                return View(new VMGroup(groups.First()));
            return View(new VMGroup(groups.Find(g => g.ID == id)));
        }
        // GET: manager/DetailsJewel/5
        public ActionResult Details(int? id)
        {
            List<Jewel> jewels = Shop.GetShop().Jewels.Include(j => j.Parent).Include(j=>j.Photo).Include(j=>j.Prices).ToList();
            if (id == null || jewels.Find(j => j.ID == id) == null)
                return RedirectToAction(nameof(Index));
            Jewel jewel = jewels.Find(j => j.ID == id);
            VMJewelDetails VM = new VMJewelDetails
            {
                JewelDetails = jewel
            };
            foreach (Jewel jewel1 in jewel.Parent.Jewels)
            {
                if(jewel1!=jewel)
                    VM.JewelsInGroup.Add(new VMJewelAndLastPrice(jewel1));
            }            
            return View(VM);
        }
        public ActionResult EditJewel(int? id)
        {
            List<Group> groups = Shop.GetShop().Groups.Include(g => g.Groups).Include(g => g.Jewels).ToList();
            List<Jewel> jewels = Shop.GetShop().Jewels.Include(j => j.Parent).ToList();
            if (id == null || jewels.Find(j => j.ID == id) == null)
                return RedirectToAction(nameof(Index));
            Jewel jewel = jewels.Find(j => j.ID == id);
            return View(jewel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJewel(Jewel jewelEdit)
        {
            try
            {
                //TODO: Add insert logic here
                Shop shop = Shop.GetShop();
                Jewel jewel = shop.Jewels.ToList().Find(j => j.ID == jewelEdit.ID);
                jewel.Name = jewelEdit.Name;
                jewel.Description = jewelEdit.Description;
                jewel.Male = jewelEdit.Male;
                jewel.Female = jewelEdit.Female;
                jewel.Color = jewelEdit.Color;
                jewel.Weight = jewelEdit.Weight;
                shop.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: manager/Create
        public ActionResult Create(int? id)
        {
            List<Group> groups = Shop.GetShop().Groups.Include(g => g.Groups).Include(g => g.Jewels).ToList();
            VMCreateGroup VM = new VMCreateGroup
            {
                Group = new Group() { ID = groups.Last().ID + 1 },
                Groups = groups
            };
            if (id != null) 
                VM.ParentID = id.Value; 
            else 
                VM.ParentID = 1;
            return View(VM);
        }
        // POST: manager/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMCreateGroup VM)
        {
            try
            {
                //TODO: Add insert logic here
                Shop shop = Shop.GetShop();
                VM.Group.SetPhoto(VM.File);
                shop.Groups.ToList().Find(g => g.ID == VM.ParentID).addGroup(VM.Group);
                shop.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AddPrice(int? id)
        {
            if (id == null) 
                return RedirectToAction(nameof(Index));
            Jewel jewel = Shop.GetShop().Jewels.ToList().Find(j => j.ID == id);
            if (jewel == null) 
                return RedirectToAction(nameof(Index));
            VMAddPriceIntoJewel VM = new VMAddPriceIntoJewel
            {
                Jewel = jewel,
                JewelID = jewel.ID
            };
            return View(VM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPrice(VMAddPriceIntoJewel VM)
        {
            try
            {
                //TODO: Add insert logic here
                Shop shop = Shop.GetShop();
                shop.Jewels.ToList().Find(j => j.ID == VM.JewelID).Prices.Add(new Price(VM.Price.price, VM.Price.Discount, VM.Price.UpToDate));
                shop.SaveChanges();
                return RedirectToAction(nameof(Details), new { id = VM.JewelID });
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AddImage(int? id)
        {
            if (id == null) 
                return RedirectToAction(nameof(Index));
            Jewel jewel = Shop.GetShop().Jewels.ToList().Find(j => j.ID == id);
            if (jewel == null) 
                return RedirectToAction(nameof(Index));
            VMAddPhotoIntoJewel VM = new VMAddPhotoIntoJewel
            {
                Jewel = jewel,
                JewelID = jewel.ID
            };
            return View(VM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddImage(VMAddPhotoIntoJewel VM)
        {
            try
            {
                //TODO: Add insert logic here
                Shop shop = Shop.GetShop();
                if (VM.File != null)
                    shop.Jewels.ToList().Find(j => j.ID == VM.JewelID).Photo.Add(new Photo(GetByteImageFromFile(VM.File)));
                shop.SaveChanges();               
                return RedirectToAction(nameof(Details),new { id = VM.JewelID } );               
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AddJewel(int? id)
        {
            if (id == null) 
                return RedirectToAction(nameof(Index));
            List<Group> groups = Shop.GetShop().Groups.ToList();
            Group group = groups.Find(g => g.ID == id.Value);
            if (group == null) 
                return RedirectToAction(nameof(Index));
            VMAddJewel VM = new VMAddJewel
            {
                Groups = groups,
                ParentID = group.ID
            };
            return View(VM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddJewel(VMAddJewel VM)
        {
            try
            {
                //TODO: Add insert logic here
                if (VM.file != null) 
                    VM.Jewel.Photo.Add(new Photo(GetByteImageFromFile(VM.file)));
                VM.Jewel.Prices.Add(VM.Price);
                Shop shop = Shop.GetShop();
                shop.Groups.ToList().Find(g => g.ID == VM.ParentID).addJewel(VM.Jewel);
                shop.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private byte[] GetByteImageFromFile(IFormFile file)
        {
            MemoryStream stream = new MemoryStream();
            file.CopyTo(stream);
            return stream.ToArray();
        }
        // GET: manager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) 
                return RedirectToAction(nameof(Index));
            Group group = Shop.GetShop().Groups.ToList().Find(g => g.ID == id.Value);
            if (group == null) 
                return RedirectToAction(nameof(Index));
            return View(new VMEditGroup() { Group = group ,GroupID=group.ID});
        }
        // POST: manager/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMEditGroup groupEdit)
        {
            try
            {
                // TODO: Add update logic here
                Shop shop = Shop.GetShop();
                Group group = shop.Groups.ToList().Find(g => g.ID == groupEdit.GroupID);
                group.Name = groupEdit.Group.Name; group.Description = groupEdit.Group.Description;
                group.SetPhoto(groupEdit.File);
                shop.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: manager/DeletePhoto/5        
        public ActionResult DeletePhoto(int? id)
        {
            if (id == null) 
                return RedirectToAction(nameof(Index));
            Photo photo = Shop.GetShop().Photos.ToList().Find(p => p.ID == id.Value);
            if (photo == null) 
                return RedirectToAction(nameof(Index));
            return View(photo);
        }
        // POST: manager/DeletePhoto/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePhoto(int id)
        {
            try
            {
                Shop.GetShop().Photos.Remove(Shop.GetShop().Photos.ToList().Find(p => p.ID == id));
                Shop.GetShop().SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(Shop.GetShop().Photos.ToList().Find(p => p.ID == id));
            }
        }
        // GET: manager/DeleteJewel/5        
        public ActionResult DeleteJewel(int? id)
        {
            if (id == null) 
                return RedirectToAction(nameof(Index));
            Jewel jewel = Shop.GetShop().Jewels.ToList().Find(j => j.ID == id.Value);            
            if (jewel == null) 
                return RedirectToAction(nameof(Index));
            
            return View(jewel);
        }
        // POST: manager/DeleteJewel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteJewel(int id)
        {
            try
            {
                Shop.GetShop().Jewels.Remove(Shop.GetShop().Jewels.ToList().Find(j => j.ID == id));              
                Shop.GetShop().SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: manager/Delete/5        
        public ActionResult Delete(int? id)
        {
            if (id == null) 
                return RedirectToAction(nameof(Index));
            Group group = Shop.GetShop().Groups.ToList().Find(g => g.ID == id.Value);
            if (group == null) 
                return RedirectToAction(nameof(Index));
            return View(group);
        }
        // POST: manager/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Group group = Shop.GetShop().Groups.ToList().Find(g => g.ID == id);
                if (group != null && id > 1) 
                    Shop.GetShop().RemoveGroup(group);
                Shop.GetShop().SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(Shop.GetShop().Groups.ToList().Find(g => g.ID == id));
            }
        }
    }
}