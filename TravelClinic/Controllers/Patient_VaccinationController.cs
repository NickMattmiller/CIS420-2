using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using asp.netmvc5.Models;
using AspNetRoleBasedSecurity.Models;


namespace asp.netmvc5.Controllers
{
   [Authorize(Roles = "Admin, Executive, CanEdit, Researcher, Program Staff, Medical Staff")]
    public class Patient_VaccinationController : Controller
    {
        private VaccineDBContext db = new VaccineDBContext();
        private ApplicationDbContext appdb = new ApplicationDbContext();


        // GET: Patient_Vaccination

        public ActionResult Index()
        {
            var patient_Vaccinations = db.Patient_Vaccinations.Include(p => p.Vaccine);
            return View(patient_Vaccinations.ToList());
        }

        // GET: Patient_Vaccination/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Vaccination patient_Vaccination = db.Patient_Vaccinations.Find(id);
            if (patient_Vaccination == null)
            {
                return HttpNotFound();
            }
            return View(patient_Vaccination);
        }
        public ActionResult GetNDC(string term)
        {
            if (term.StartsWith("3"))
            {
                term = term.Remove(0, 1);
                term = term.Remove(10, 1);
            }

            //if(term.IndexOf(0,4 ,1).) 
            if (!term.StartsWith("00"))
            {
                term = term.Insert(5, "0");

            }
            if (term.StartsWith("000"))
            {
                term = term.Remove(0,3);

            }

            var result =
                from r in db.Vaccines
                where r.Barcode_NDC.ToString().Contains(term) && r.Administered.Equals(false)
                select new { VaccineID = r.Id, Description = r.Description, Barcode_NDC = r.Barcode_NDC.ToString() };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDescription(string term)
        {
            var result = (from r in db.Vaccines
                          where r.Description.StartsWith(term)
                          select r.Description).Take(20);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // GET: Patient_Vaccination/Create
        [Authorize(Roles = "Admin, Executive, CanEdit, Program Staff, Medical Staff")]
        public ActionResult Create()
        {
            string Username = User.Identity.Name;

            ViewBag.VaccineID = new SelectList(db.Vaccines, "Id", "Description");
            return View();
        }

        // POST: Patient_Vaccination/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Executive, CanEdit, Program Staff, Medical Staff")]
        public ActionResult Create([Bind(Include = "AdministeredID,Barcode_NDC,VaccineID,RefugeeId,Patient_Num,UserName,Price_Paid,Site_Administered,Date_Administered")] Patient_Vaccination patient_Vaccination)
        {
            if (ModelState.IsValid)
            {
                db.Patient_Vaccinations.Add(patient_Vaccination);
                LoginViewModel user = new LoginViewModel();
                patient_Vaccination.UserName = user.UserName;
                Vaccine vaccine = db.Vaccines.Find(patient_Vaccination.VaccineID);
                //db.Vaccines.Remove(vaccine);
                vaccine.Administered = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VaccineID = new SelectList(db.Vaccines, "Id", "Description", patient_Vaccination.VaccineID);
            return View(patient_Vaccination);
        }

        // GET: Patient_Vaccination/Edit/5
       [Authorize(Roles = "Admin, Executive, CanEdit, Program Staff, Medical Staff")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Vaccination patient_Vaccination = db.Patient_Vaccinations.Find(id);
            if (patient_Vaccination == null)
            {
                return HttpNotFound();
            }
            ViewBag.VaccineID = new SelectList(db.Vaccines, "Id", "Description", patient_Vaccination.VaccineID);
            return View(patient_Vaccination);
        }

        // POST: Patient_Vaccination/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Executive, CanEdit, Program Staff, Medical Staff")]
        public ActionResult Edit([Bind(Include = "AdministeredID,Barcode_NDC,VaccineID,RefugeeId,Patient_Num,UserName,Price_Paid,Site_Administered,Date_Administered")] Patient_Vaccination patient_Vaccination)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient_Vaccination).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VaccineID = new SelectList(db.Vaccines, "Id", "Description", patient_Vaccination.VaccineID);
            return View(patient_Vaccination);
        }

        // GET: Patient_Vaccination/Delete/5
       [Authorize(Roles = "Admin, Executive, CanEdit, Program Staff")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Vaccination patient_Vaccination = db.Patient_Vaccinations.Find(id);
            if (patient_Vaccination == null)
            {
                return HttpNotFound();
            }
            return View(patient_Vaccination);
        }

        // POST: Patient_Vaccination/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Executive, CanEdit, Program Staff, Medical Staff")]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient_Vaccination patient_Vaccination = db.Patient_Vaccinations.Find(id);
            db.Patient_Vaccinations.Remove(patient_Vaccination);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
