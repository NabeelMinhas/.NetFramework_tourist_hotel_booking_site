using themenava.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace themenava.Controllers
{
    public class placesController : Controller
    {
        assainmentEntities6 db = new assainmentEntities6();
        // GET: shop
        public ActionResult Index()
        {
            var rec = db.places.ToList();
            return View(rec);
        }
        public ActionResult All_Hotel()
        {
            using (assainmentEntities6 db = new assainmentEntities6())
            {
                var Hotl = db.hotels.ToList();
                return View(Hotl);
            }
        }

        public ActionResult Hotel(string placeid)
        {
            using (assainmentEntities6 db = new assainmentEntities6())
            {
                List<hotel> Hotl = db.hotels.ToList();
                var ans=db.hotels.Where(a => a.h_placeid==placeid).ToList();
                return View(ans);
            }

        }


        public ActionResult origionalhoteldetail(string id)
        {
            using (assainmentEntities6 db = new assainmentEntities6())
            {
                List<hotel> Hotl = db.hotels.ToList();
                int temp = Convert.ToInt32(id);
                var ans = db.hotels.Where(a=>a.id == temp).ToList();
                return View(ans);
            }
        }
    }
}