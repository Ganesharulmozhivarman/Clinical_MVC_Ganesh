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
    public class LabTestTblsController : Controller
    {
        private readonly ClinicMVCDbEntities db = new ClinicMVCDbEntities();

        // GET: LabTestTbls
        public ActionResult Index()
        {
            var labTestTbls = db.LabTestTbls.Include(l => l.LaboratorianTbl);
            return View(labTestTbls.ToList());
        }

        // GET: LabTestTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabTestTbl labTestTbl = db.LabTestTbls.Find(id);
            if (labTestTbl == null)
            {
                return HttpNotFound();
            }
            return View(labTestTbl);
        }

        // GET: LabTestTbls/Create
        public ActionResult Create()
        {
            ViewBag.AddBy = new SelectList(db.LaboratorianTbls, "LabId", "LabName");
            return View();
        }

        // POST: LabTestTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestId,TestName,TestCost,AddBy")] LabTestTbl labTestTbl)
        {
            if (ModelState.IsValid)
            {
                db.LabTestTbls.Add(labTestTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddBy = new SelectList(db.LaboratorianTbls, "LabId", "LabName", labTestTbl.AddBy);
            return View(labTestTbl);
        }

        // GET: LabTestTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabTestTbl labTestTbl = db.LabTestTbls.Find(id);
            if (labTestTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddBy = new SelectList(db.LaboratorianTbls, "LabId", "LabName", labTestTbl.AddBy);
            return View(labTestTbl);
        }

        // POST: LabTestTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestId,TestName,TestCost,AddBy")] LabTestTbl labTestTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(labTestTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddBy = new SelectList(db.LaboratorianTbls, "LabId", "LabName", labTestTbl.AddBy);
            return View(labTestTbl);
        }

        // GET: LabTestTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabTestTbl labTestTbl = db.LabTestTbls.Find(id);
            if (labTestTbl == null)
            {
                return HttpNotFound();
            }
            return View(labTestTbl);
        }

        // POST: LabTestTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LabTestTbl labTestTbl = db.LabTestTbls.Find(id);
            db.LabTestTbls.Remove(labTestTbl);
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
