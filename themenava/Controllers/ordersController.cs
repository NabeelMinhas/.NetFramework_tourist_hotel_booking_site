using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using themenava.Models;
using System.IO;

namespace themenava.Controllers
{
    public class ordersController : Controller
    {
        assainmentEntities6 db = new assainmentEntities6();
        // GET: orders

        //section start for new order page
        
        //just to return the data from database to view in new orders page
        public ActionResult Index()
        {
            //return the new orders
            var rec = db.orders.ToList();
            return View("index",rec);
        }
 
        //for order to send in progress
        public ActionResult del_and_add(string id )
        {
            int m=  Int32.Parse(id);
            order rec = (from c in db.orders
                                 where c.id == m
                                 select c).FirstOrDefault();

            string temp=rec.price.ToString();
             
            orders_inpregress in_rec= new orders_inpregress();
            in_rec.id=rec.id;
            in_rec.first_name = rec.first_name;
            in_rec.last_name = rec.last_name;
            in_rec.phone_no_1 = rec.phone_no_1;
            in_rec.phone_no_2 = rec.phone_no_2;
            in_rec.email_address = rec.email_address;
            in_rec.cnic = rec.cnic;
            in_rec.date = rec.date;
            in_rec.no_of_days = rec.no_of_days;
            in_rec.price = temp;

            db.orders.Remove(rec);
            db.orders_inpregress.Add(in_rec);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        //for deete the spam order from database
        public ActionResult delete_Orders(string id)
        {
            int m = Int32.Parse(id);
            order rec = (from c in db.orders
                         where c.id == m
                         select c).FirstOrDefault();

            recycle_bin reuse = new recycle_bin();
            reuse.title = rec.title;
            reuse.id = rec.id;
            reuse.last_name = rec.last_name;
            reuse.first_name = rec.first_name;
            reuse.cnic = rec.cnic;
            reuse.date = rec.date;
            reuse.phone_no_1 = rec.phone_no_1;
            reuse.phone_no_2 = rec.phone_no_2;
            reuse.email_address = rec.email_address;
            reuse.price = rec.price;
            reuse.no_of_days = rec.no_of_days;

            db.recycle_bin.Add(reuse);
            db.orders.Remove(rec);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        //section for progress page

        //just returning the default data from database
        public ActionResult progress()
        {
            var rec=db.orders_inpregress.ToList();
            return View(rec);
        }

        //adding data in complete order page and delete from progress page
        public ActionResult del_and_add_for_complete(string id)
        {
            int m = Int32.Parse(id);
            orders_inpregress rec = (from c in db.orders_inpregress
                         where c.id == m
                         select c).FirstOrDefault();

            int temp = Int32.Parse(rec.price);

            orders_complete com_rec = new orders_complete();
            com_rec.id = rec.id;
            com_rec.first_name = rec.first_name;
            com_rec.last_name = rec.last_name;
            com_rec.phone_no_1 = rec.phone_no_1;
            com_rec.phone_no_2 = rec.phone_no_2;
            com_rec.email_address = rec.email_address;
            com_rec.cnic = rec.cnic;
            com_rec.date = rec.date;
            com_rec.no_of_days = rec.no_of_days;
            com_rec.price = temp;

            db.orders_inpregress.Remove(rec);
            db.orders_complete.Add(com_rec);
            db.SaveChanges();
            return RedirectToAction("progress");
        }
        //delete data from progress page
        public ActionResult delete_inprogress(string id)
        {
            int m = Int32.Parse(id);
            orders_inpregress rec = (from c in db.orders_inpregress
                         where c.id == m
                         select c).FirstOrDefault();

            int temp = Int32.Parse(rec.price);

            recycle_bin reuse = new recycle_bin();
            reuse.title = rec.title;
            reuse.id = rec.id;
            reuse.last_name = rec.last_name;
            reuse.first_name = rec.first_name;
            reuse.cnic = rec.cnic;
            reuse.date = rec.date;
            reuse.phone_no_1 = rec.phone_no_1;
            reuse.phone_no_2 = rec.phone_no_2;
            reuse.email_address = rec.email_address;
            reuse.price = temp;
            reuse.no_of_days = rec.no_of_days;

            db.recycle_bin.Add(reuse);

            db.orders_inpregress.Remove(rec);
            db.SaveChanges();
            return RedirectToAction("progress");
        }

        //return just data from data base to complete page
        public ActionResult complete()
        {
            var rec=db.orders_complete.ToList();
            return View(rec);
        }
        //deleting record from complete page
        public ActionResult delete_complete(string id)
        {
            int m = Int32.Parse(id);
            orders_complete rec = (from c in db.orders_complete
                                     where c.id == m
                                     select c).FirstOrDefault();

            recycle_bin reuse = new recycle_bin();
            reuse.title = rec.title;
            reuse.id = rec.id;
            reuse.last_name = rec.last_name;
            reuse.first_name = rec.first_name;
            reuse.cnic = rec.cnic;
            reuse.date = rec.date;
            reuse.phone_no_1 = rec.phone_no_1;
            reuse.phone_no_2 = rec.phone_no_2;
            reuse.email_address = rec.email_address;
            reuse.price = rec.price;
            reuse.no_of_days = rec.no_of_days;

            db.recycle_bin.Add(reuse);

            db.orders_complete.Remove(rec);
            db.SaveChanges();
            return RedirectToAction("complete");
        }
        public ActionResult recycle()
        {
            var rec = db.recycle_bin.ToList();
            return View(rec);
        }
        public ActionResult recycle_del(string id)
        {
            
            int m = Int32.Parse(id);
            recycle_bin rec = (from c in db.recycle_bin
                                   where c.id == m
                                   select c).FirstOrDefault();

                db.recycle_bin.Remove(rec);
                db.SaveChanges();
                return RedirectToAction("recycle_del");
        }
    }
}