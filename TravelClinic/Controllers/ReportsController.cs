using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.netmvc5.Models;

namespace asp.netmvc5.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        private VaccineDBContext db = new VaccineDBContext();

       
        public ActionResult Index()
        {
            IQueryable<VaccineNDCGroup> data = from vaccine in db.Vaccines
                                               where vaccine.Administered.Equals(false)
                                               group vaccine by new { vaccine.Barcode_NDC, vaccine.Description }
                                                   into numGroup
                                                   select new VaccineNDCGroup()
                                                   {

                                                       Barcode_NDC = numGroup.Key.Barcode_NDC,
                                                       Description = numGroup.Key.Description,
                                                       VaccineCount = numGroup.Count()
                                                   };
            return View(data.ToList());
        }
        public ActionResult VaccineSalesCount()
        {
            IQueryable<VaccineNDCGroup> data = from vaccine in db.Vaccines
                                               where vaccine.Administered.Equals(true)
                                               group vaccine by new { vaccine.Barcode_NDC, vaccine.Description }
                                                   into numGroup
                                                   select new VaccineNDCGroup()
                                                   {

                                                       Barcode_NDC = numGroup.Key.Barcode_NDC,
                                                       Description = numGroup.Key.Description,
                                                       VaccineCount = numGroup.Count()
                                                   };
            return View(data.ToList());
        }
    }
}