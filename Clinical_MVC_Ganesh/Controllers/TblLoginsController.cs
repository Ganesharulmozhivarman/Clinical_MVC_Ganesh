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
    public class TblLoginsController : Controller
    {
        private ClinicMVCDbEntities db = new ClinicMVCDbEntities();

        // GET: TblLogins
        public ActionResult Index()
        {
            return View(db.TblLogins.ToList());
        }

        // GET: TblLogins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblLogin tblLogin = db.TblLogins.Find(id);
            if (tblLogin == null)
            {
                return HttpNotFound();
            }
            return View(tblLogin);
        }

        // GET: TblLogins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TblLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MailID,Password,Role")] TblLogin tblLogin)
        {
            if (ModelState.IsValid)
            {
                db.TblLogins.Add(tblLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblLogin);
        }

        // GET: TblLogins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblLogin tblLogin = db.TblLogins.Find(id);
            if (tblLogin == null)
            {
                return HttpNotFound();
            }
            return View(tblLogin);
        }

        // POST: TblLogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MailID,Password,Role")] TblLogin tblLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblLogin);
        }

        // GET: TblLogins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblLogin tblLogin = db.TblLogins.Find(id);
            if (tblLogin == null)
            {
                return HttpNotFound();
            }
            return View(tblLogin);
        }

        // POST: TblLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblLogin tblLogin = db.TblLogins.Find(id);
            db.TblLogins.Remove(tblLogin);
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
