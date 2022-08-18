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
    public class ReceptionistTblsController : Controller
    {
        private ClinicMVCDbEntities db = new ClinicMVCDbEntities();

        // GET: ReceptionistTbls
        public ActionResult Index()
        {
            return View(db.ReceptionistTbls.ToList());
        }

        // GET: ReceptionistTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceptionistTbl receptionistTbl = db.ReceptionistTbls.Find(id);
            if (receptionistTbl == null)
            {
                return HttpNotFound();
            }
            return View(receptionistTbl);
        }

        // GET: ReceptionistTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReceptionistTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecId,RecName,RecEmail,RecAdd,RecPhone,RecPassword")] ReceptionistTbl receptionistTbl)
        {
            if (ModelState.IsValid)
            {
                db.ReceptionistTbls.Add(receptionistTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(receptionistTbl);
        }

        // GET: ReceptionistTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceptionistTbl receptionistTbl = db.ReceptionistTbls.Find(id);
            if (receptionistTbl == null)
            {
                return HttpNotFound();
            }
            return View(receptionistTbl);
        }

        // POST: ReceptionistTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecId,RecName,RecEmail,RecAdd,RecPhone,RecPassword")] ReceptionistTbl receptionistTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receptionistTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(receptionistTbl);
        }

        // GET: ReceptionistTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceptionistTbl receptionistTbl = db.ReceptionistTbls.Find(id);
            if (receptionistTbl == null)
            {
                return HttpNotFound();
            }
            return View(receptionistTbl);
        }

        // POST: ReceptionistTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReceptionistTbl receptionistTbl = db.ReceptionistTbls.Find(id);
            db.ReceptionistTbls.Remove(receptionistTbl);
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
