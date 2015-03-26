using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using asp.netmvc5.Models;

namespace asp.netmvc5.Controllers
{
    [Authorize(Roles = "Admin, Executive, CanEdit, Researcher, Program Staff, Medical Staff")]
    public class NDC_LookupController : Controller
    {
        private VaccineDBContext db = new VaccineDBContext();

        // GET: NDC_Lookup
        public ActionResult Index()
        {
            return View(db.NDC_Lookup.ToList());
        }

        // GET: NDC_Lookup/Details/5
        [Authorize(Roles = "Admin, Executive, CanEdit, Researcher, Program Staff, Medical Staff")]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NDC_Lookup nDC_Lookup = db.NDC_Lookup.Find(id);
            if (nDC_Lookup == null)
            {
                return HttpNotFound();
            }
            return View(nDC_Lookup);
        }

        // GET: NDC_Lookup/Create
        [Authorize(Roles = "Admin, Executive, CanEdit, Program Staff")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: NDC_Lookup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Barcode_NDC,QRCode,Route,Brand_Name,Code_CVX,Description_CVX,Description_Generic,Package_Name,Package_Type,Date_Updated")] NDC_Lookup nDC_Lookup)
        {
            if (ModelState.IsValid)
            {
                db.NDC_Lookup.Add(nDC_Lookup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nDC_Lookup);
        }

        // GET: NDC_Lookup/Edit/5
        [Authorize(Roles = "Admin, Executive, CanEdit, Program Staff")]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NDC_Lookup nDC_Lookup = db.NDC_Lookup.Find(id);
            if (nDC_Lookup == null)
            {
                return HttpNotFound();
            }
            return View(nDC_Lookup);
        }

        // POST: NDC_Lookup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin, Executive, CanEdit, Program Staff")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Barcode_NDC,QRCode,Route,Brand_Name,Code_CVX,Description_CVX,Description_Generic,Package_Name,Package_Type,Date_Updated")] NDC_Lookup nDC_Lookup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nDC_Lookup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nDC_Lookup);
        }

        // GET: NDC_Lookup/Delete/5
        [Authorize(Roles = "Admin, Executive, CanEdit, Program Staff")]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NDC_Lookup nDC_Lookup = db.NDC_Lookup.Find(id);
            if (nDC_Lookup == null)
            {
                return HttpNotFound();
            }
            return View(nDC_Lookup);
        }

        // POST: NDC_Lookup/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, Executive, CanEdit, Program Staff")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            NDC_Lookup nDC_Lookup = db.NDC_Lookup.Find(id);
            db.NDC_Lookup.Remove(nDC_Lookup);
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
