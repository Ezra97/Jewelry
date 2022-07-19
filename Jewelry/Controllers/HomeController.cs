using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Jewelry.Models;
using Jewelry.ViewModel;
using System.Data.Entity;
using System.IO;
using iText.IO;

namespace Jewelry.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? id)
        {
            List<Jewel> jewels = Shop.GetShop().Jewels.Include(j => j.Parent).Include(j => j.Photo).Include(j => j.Prices).ToList();
            List<Group> groups = Shop.GetShop().Groups.Include(g => g.Groups).Include(g => g.Jewels).ToList();
            if (id != null)
                if (groups.Find(g => g.ID == id.Value) != null)
                {
                    VMOrder VM = new VMOrder{ VMGroup = new VMGroup(groups.Find(g => g.ID == id.Value)) };
                    return View(VM);
                }
            VMOrder VMFirst = new VMOrder{ VMGroup = new VMGroup(groups.First()) };
            return View(VMFirst);
        }
        public ActionResult Orders()
        {
            List<Order> orders = Shop.GetShop().Orders.ToList().FindAll(o => o.Customer.ID == Shop.GetShop().Order.Customer.ID);
            return View(orders);
        }
        public ActionResult Search(string search)
        {
            if (search != "")
            {
                List<Group> groups = Shop.GetShop().Groups.ToList();
                foreach (Group group in groups)
                {
                    if (group.Name == search) 
                        return RedirectToAction(nameof(Index), new { id = group.ID });
                }
                List<Jewel> jewels = Shop.GetShop().Jewels.ToList();
                foreach (Jewel jewel in jewels)
                {
                    if (jewel.Name == search) 
                        return RedirectToAction(nameof(Details), new { id = jewel.ID });
                }
            }
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Details(int? id)
        {
            if(id==null)
                return RedirectToAction(nameof(Index));
            Jewel Jewel = Shop.GetShop().Jewels.ToList().Find(j => j.ID == id.Value);
            if(Jewel==null)
                return RedirectToAction(nameof(Index));
            VMJewelAndLastPrice jewel = new VMJewelAndLastPrice(Jewel);
            return View(jewel);
        }

        public ActionResult AddToCart(int? id)
        {
            if (id != null)
                if (id > 0)
                {
                    JewelryInOrder jewelry = Shop.GetShop().Order.JewelryInOrder.ToList().Find(j => j.Jewel.ID == id);
                    if (jewelry != null)
                        jewelry.AddQuantity();
                    else
                        Shop.GetShop().Order.JewelryInOrder.Add(new JewelryInOrder(Shop.GetShop().Jewels.ToList().Find(j => j.ID == id), Shop.GetShop().Order));
                }
            return View(new VMOrderPay());            
        }
        public ActionResult MinusQuantity(int? id)
        {
            if (id != null)
                Shop.GetShop().Order.JewelryInOrder.ToList().Find(j => j.Jewel.ID == id).MinusQuantity();
            return RedirectToAction(nameof(AddToCart), new { id = 0 });
        }
        public ActionResult RemoveFromCart(int? id)
        {
            if (id != null)
                Shop.GetShop().Order.JewelryInOrder.Remove(Shop.GetShop().Order.JewelryInOrder.ToList().Find(j => j.Jewel.ID == id));

            return View("AddToCart",new VMOrderPay());
        }
        
        public ActionResult Connect()
        {
            if(Shop.GetShop().Order.Customer.Email!=null)
                return View("AddToCart",new VMOrderPay());
            Customer customer = new Customer();
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Connect(Customer customer)
        {
            Customer CustomerExist= Shop.GetShop().Customers.ToList().Find(c => c.Email == customer.Email);
            if (CustomerExist!=null)
            {
                if (CustomerExist.Name!=customer.Name || CustomerExist.Password!=customer.Password)
                {
                    return View(customer);
                }
                CustomerExist.Phone_Number = customer.Phone_Number;
            }
            else
            {
                Shop.GetShop().Customers.Add(customer);
            }
            Shop.GetShop().SaveChanges();
            Shop.GetShop().Order.Customer = Shop.GetShop().Customers.ToList().Find(c => c.Email == customer.Email);
            return View("AddToCart", new VMOrderPay());
        }
        
        public ActionResult UnConnect()
        {
            return View(new VMOrderPay());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UnConnect(VMOrderPay VM)
        {
            Shop.GetShop().Order = new Order();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Pay()
        {
            if (Shop.GetShop().Order.Customer.Email == null) 
                return View("Connect", new Customer());
            return View(new VMPay());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pay(VMPay pay)
        {
            if (CheckCreditCard(pay.NumberCreditCard,pay.ValidDateCreditCard,pay.CVV))
            {
                Shop.GetShop().Order.PriceSending = pay.OrderPay.Order.PriceSending;
                Shop.GetShop().Order.PriceTotal = pay.OrderPay.Order.PriceTotal;
                Shop.GetShop().Order.City = pay.OrderPay.Order.City;
                Shop.GetShop().Order.Street = pay.OrderPay.Order.Street;
                Shop.GetShop().Order.Number = pay.OrderPay.Order.Number;
                Shop.GetShop().Order.IfPay = true;
                Shop.GetShop().Orders.Add(Shop.GetShop().Order);
                Shop.GetShop().SaveChanges();
                Order Temp = Shop.GetShop().Order;
                Temp.SendMailOrder();
                Shop.GetShop().Order = new Order();                
                return View("ThankYou",Temp);
            }
            return View(new VMPay());
        }

        private bool CheckCreditCard(string NumberCreditCard,DateTime ValidDateCreditCard, string cvv)//הפונקציה היא בודקת אם המספר והתאריך תוקף של הכרטיס אשראי היא תקין  
        {
            if (ValidDateCreditCard > DateTime.Now) 
                return true;
            return false;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
