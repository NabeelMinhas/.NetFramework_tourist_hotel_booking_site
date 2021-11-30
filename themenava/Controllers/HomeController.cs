using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using themenava.Models;

namespace themenava.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //return home page of webside
            return View();
        }
        public ActionResult Contact()
        {
            //return Contact page of web site
            return View();
        }
        [HttpPost]
        public ActionResult Contact(message sm)
        {
            assainmentEntities6 db = new assainmentEntities6();
            db.messages.Add(sm);
            db.SaveChanges();
            ModelState.Clear();
            sm.congratulate_message = "Your message is delivered";
            sm.email = "";
            sm.name = "";
            sm.phone_no = "";
            sm.sms = "";
            return View("contact",sm);
        }
        public ActionResult login()
        {
            //return login page of website
            return View();
        }
        [HttpPost]
        public ActionResult logincheck(themenava.Models.admin_login record)
        {
            //checking the user name and password of login form
            using(assainmentEntities6 db = new assainmentEntities6())
            {
                var getrecord = db.admin_login.Where(x => x.username == record.username && x.password == record.password).FirstOrDefault();
                if(getrecord==null)
                {
                    //return login form with error message 
                    record.errormessage = "username or password is wrong";
                    return View("Login",record);
                }
                else
                {
                    //dashboard
                    Session["userID"] = record.username;
                    return RedirectToAction("Index", "dashboard",record.username);
                }
            }
        }
    }
}