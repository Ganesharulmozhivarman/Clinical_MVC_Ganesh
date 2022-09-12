using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Clinical_MVC_Ganesh.Models;

namespace Clinical_MVC_Ganesh.Controllers
{
    [Authorize(Roles = "Receptionist")]
    public class AppointTblsController : Controller
    {
        private ClinicMVCDbEntities db = new ClinicMVCDbEntities();

        // GET: AppointTbls
        public ActionResult Index()
        {
            var appointTbls = db.AppointTbls.Include(a => a.DoctorTbl).Include(a => a.PatientTbl).Include(a => a.ReceptionistTbl);
            return View(appointTbls.ToList());
        }

        // GET: AppointTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointTbl appointTbl = db.AppointTbls.Find(id);
            if (appointTbl == null)
            {
                return HttpNotFound();
            }
            return View(appointTbl);
        }

        // GET: AppointTbls/Create
        public ActionResult Create()
        {
            ViewBag.Doctor = new SelectList(db.DoctorTbls, "DocId", "DocName");
            ViewBag.Patient = new SelectList(db.PatientTbls, "PatId", "PatName");
            ViewBag.Receptionist = new SelectList(db.ReceptionistTbls, "RecId", "RecName");
            return View();
        }

        // POST: AppointTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppID,Patient,Doctor,Receptionist,Date")] AppointTbl appointTbl)
        {
            if (ModelState.IsValid)
            {
                db.AppointTbls.Add(appointTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Doctor = new SelectList(db.DoctorTbls, "DocId", "DocName", appointTbl.Doctor);
            ViewBag.Patient = new SelectList(db.PatientTbls, "PatId", "PatName", appointTbl.Patient);
            ViewBag.Receptionist = new SelectList(db.ReceptionistTbls, "RecId", "RecName", appointTbl.Receptionist);
            return View(appointTbl);
        }

        // GET: AppointTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointTbl appointTbl = db.AppointTbls.Find(id);
            if (appointTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Doctor = new SelectList(db.DoctorTbls, "DocId", "DocName", appointTbl.Doctor);
            ViewBag.Patient = new SelectList(db.PatientTbls, "PatId", "PatName", appointTbl.Patient);
            ViewBag.Receptionist = new SelectList(db.ReceptionistTbls, "RecId", "RecName", appointTbl.Receptionist);
            return View(appointTbl);
        }

        // POST: AppointTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppID,Patient,Doctor,Receptionist,Date")] AppointTbl appointTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Doctor = new SelectList(db.DoctorTbls, "DocId", "DocName", appointTbl.Doctor);
            ViewBag.Patient = new SelectList(db.PatientTbls, "PatId", "PatName", appointTbl.Patient);
            ViewBag.Receptionist = new SelectList(db.ReceptionistTbls, "RecId", "RecName", appointTbl.Receptionist);
            return View(appointTbl);
        }

        // GET: AppointTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointTbl appointTbl = db.AppointTbls.Find(id);
            if (appointTbl == null)
            {
                return HttpNotFound();
            }
            return View(appointTbl);
        }

        // POST: AppointTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppointTbl appointTbl = db.AppointTbls.Find(id);
            db.AppointTbls.Remove(appointTbl);
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
