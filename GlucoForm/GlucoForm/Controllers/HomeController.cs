using GlucoForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GlucoForm.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            if (User.IsInRole("Patient"))
            {
                var currUser = db.Patients.Where(l => l.Email == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault().Id;
                ViewBag.currentUser = currUser;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}