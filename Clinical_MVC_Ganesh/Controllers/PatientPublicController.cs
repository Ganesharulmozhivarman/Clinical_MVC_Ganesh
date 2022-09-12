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
    [Authorize(Roles = "Doctor")]
    public class PatientPublicController : Controller
    {
        private ClinicMVCDbEntities db = new ClinicMVCDbEntities();

        // GET: PatientPublic
        public ActionResult Index()
        {
            var patientTbls = db.PatientTbls.Include(p => p.ReceptionistTbl);
            return View(patientTbls.ToList());
        }

        // GET: PatientPublic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientTbl patientTbl = db.PatientTbls.Find(id);
            if (patientTbl == null)
            {
                return HttpNotFound();
            }
            return View(patientTbl);
        }

        // GET: PatientPublic/Create
        public ActionResult Create()
        {
            ViewBag.AddBy = new SelectList(db.ReceptionistTbls, "RecId", "RecName");
            return View();
        }

        // POST: PatientPublic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatId,PatName,PatPhone,PatGen,PatDOB,PatAdd,PatAllegies,AddBy")] PatientTbl patientTbl)
        {
            if (ModelState.IsValid)
            {
                db.PatientTbls.Add(patientTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddBy = new SelectList(db.ReceptionistTbls, "RecId", "RecName", patientTbl.AddBy);
            return View(patientTbl);
        }

        // GET: PatientPublic/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientTbl patientTbl = db.PatientTbls.Find(id);
            if (patientTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddBy = new SelectList(db.ReceptionistTbls, "RecId", "RecName", patientTbl.AddBy);
            return View(patientTbl);
        }

        // POST: PatientPublic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatId,PatName,PatPhone,PatGen,PatDOB,PatAdd,PatAllegies,AddBy")] PatientTbl patientTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddBy = new SelectList(db.ReceptionistTbls, "RecId", "RecName", patientTbl.AddBy);
            return View(patientTbl);
        }

        // GET: PatientPublic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientTbl patientTbl = db.PatientTbls.Find(id);
            if (patientTbl == null)
            {
                return HttpNotFound();
            }
            return View(patientTbl);
        }

        // POST: PatientPublic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientTbl patientTbl = db.PatientTbls.Find(id);
            db.PatientTbls.Remove(patientTbl);
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
