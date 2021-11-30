using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using themenava.Models;

namespace themenava.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            //returning the default dashboard layout
            return View();
        }
        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("login", "Home");
        }
        public ActionResult message()
        {
            using (assainmentEntities6 db=new assainmentEntities6())
            {
                var sms=db.messages.ToList();
                return View(sms);
            }

        }
        public ActionResult delete(string id)
        {
            using(assainmentEntities6 db=new assainmentEntities6())
            {
                int m = Int32.Parse(id);
                message rec = (from c in db.messages
                             where c.id == m
                             select c).FirstOrDefault();
                db.messages.Remove(rec);
                db.SaveChanges();
                return RedirectToAction("message");
            }

        }
        public ActionResult hotels()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addhotel(hotel hotl)
        {
            string filename = Path.GetFileNameWithoutExtension(hotl.imagefile.FileName);
            string extension = Path.GetExtension(hotl.imagefile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            hotl.imageurl = "../../uploadedimages/" + filename;
            filename = Path.Combine(Server.MapPath("~/uploadedimages/"), filename);
            hotl.imagefile.SaveAs(filename);
                using (assainmentEntities6 db = new assainmentEntities6())
                {
                    db.hotels.Add(hotl);
                    db.SaveChanges();
                }
            ModelState.Clear();
            return RedirectToAction("Index", "dashboard");
        }
        public ActionResult place()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addplace(place plac)
        {
            string filename = Path.GetFileNameWithoutExtension(plac.imagefile.FileName);
            string extension = Path.GetExtension(plac.imagefile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            plac.imageurl = "../../uploadedimages/" + filename;
            filename = Path.Combine(Server.MapPath("~/uploadedimages/"), filename);
            plac.imagefile.SaveAs(filename);
            using(assainmentEntities6 db=new assainmentEntities6())
            {
                db.places.Add(plac);
                db.SaveChanges();
            }
            ModelState.Clear();
            return RedirectToAction("Index","dashboard");
        }
        public ActionResult flight()
        {
            return View();
        }
    }
}