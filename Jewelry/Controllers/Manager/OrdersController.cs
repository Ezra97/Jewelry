using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jewelry.Models;
using Jewelry.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace Jewelry.Controllers.Manager
{
    public class OrdersController : Controller
    {
        // GET: OrdersController
        public ActionResult Index(int? id)
        {
            if (Shop.GetShop().Order.Customer.Email == null) 
                return RedirectToAction("Connect", "Home");
            if (Shop.GetShop().Order.Customer.Email != "estollon@gmail.com" && Shop.GetShop().Order.Customer.Email != "ofek5597@gmail.com")
                return RedirectToAction("Index", "Home");
            List<JewelryInOrder> jewelryInOrders = Shop.GetShop().jewelryInOrders.Include(j => j.Jewel).ToList();
            List<Order> orders = Shop.GetShop().Orders.Include(o => o.Customer).Include(o => o.JewelryInOrder).ToList();
            if (orders != null)
                if (orders.Count > 0)
                {
                    VMAllOrders VM = new VMAllOrders();
                    if (id != null)
                        if (orders.Find(o => o.ID == id) != null)
                            VM.Order = new VMOrderAndPrices(orders.Find(o => o.ID == id));
                    foreach (Order order1 in orders)
                    {
                        VM.Orders.Add(new VMOrderAndPrices(order1));
                    }
                    return View(VM);
                }
            return View(new VMAllOrders());
        }
        public ActionResult Done(int? id)//שהלקוח מקבל הפריט מהמשלוח
        {
            if (id != null)
            {
                Shop.GetShop().Orders.ToList().Find(o => o.ID == id).IsDone = true;
                Shop.GetShop().SaveChanges();
                return RedirectToAction(nameof(Index), new { id = id });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
