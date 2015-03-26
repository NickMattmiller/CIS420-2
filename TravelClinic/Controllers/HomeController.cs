using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.netmvc5.Models;

namespace asp.netmvc5.Controllers
{
    public class HomeController : Controller
    {
        private VaccineDBContext db = new VaccineDBContext();
        public ActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "OnlineRegistration, Admin, Executive, CanEdit, Researcher")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Vaccines()
        {
            ViewBag.Message = "Vaccine Inventory page.";

            return View();
        }
        public ActionResult OurPartners()
        {
            return View();
        }
        public ActionResult CivilSurgeon()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult Immunization()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult OurResearch()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
    }
}