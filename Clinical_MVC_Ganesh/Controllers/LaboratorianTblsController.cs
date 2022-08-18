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
    public class LaboratorianTblsController : Controller
    {
        private ClinicMVCDbEntities db = new ClinicMVCDbEntities();

        // GET: LaboratorianTbls
        public ActionResult Index()
        {
            return View(db.LaboratorianTbls.ToList());
        }

        // GET: LaboratorianTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaboratorianTbl laboratorianTbl = db.LaboratorianTbls.Find(id);
            if (laboratorianTbl == null)
            {
                return HttpNotFound();
            }
            return View(laboratorianTbl);
        }

        // GET: LaboratorianTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LaboratorianTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LabId,LabName,LabEmail,LabPass,LabPhone,LabAddress,LabGen")] LaboratorianTbl laboratorianTbl)
        {
            if (ModelState.IsValid)
            {
                db.LaboratorianTbls.Add(laboratorianTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(laboratorianTbl);
        }

        // GET: LaboratorianTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaboratorianTbl laboratorianTbl = db.LaboratorianTbls.Find(id);
            if (laboratorianTbl == null)
            {
                return HttpNotFound();
            }
            return View(laboratorianTbl);
        }

        // POST: LaboratorianTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LabId,LabName,LabEmail,LabPass,LabPhone,LabAddress,LabGen")] LaboratorianTbl laboratorianTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laboratorianTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(laboratorianTbl);
        }

        // GET: LaboratorianTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaboratorianTbl laboratorianTbl = db.LaboratorianTbls.Find(id);
            if (laboratorianTbl == null)
            {
                return HttpNotFound();
            }
            return View(laboratorianTbl);
        }

        // POST: LaboratorianTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LaboratorianTbl laboratorianTbl = db.LaboratorianTbls.Find(id);
            db.LaboratorianTbls.Remove(laboratorianTbl);
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
