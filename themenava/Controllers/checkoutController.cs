using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using themenava.Models;

namespace themenava.Controllers
{
    public class checkoutController : Controller
    {
        // GET: checkout
        public ActionResult Index(string title,int price)
        {
            ViewBag.title = title;
            ViewBag.price = price;
            return View();
        }
        [HttpPost]
        public ActionResult add_data(order data)
        {
            using (assainmentEntities6 db = new assainmentEntities6())
            {
                
                db.orders.Add(data);
                
                db.SaveChanges();
            }
            return  RedirectToAction("index", "home");
        }
    }
}