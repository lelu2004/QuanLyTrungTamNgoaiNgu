using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyTrungTamNN.Models;

namespace QuanLyTrungTamNN.Controllers
{
    public class STUDENTsController : Controller
    {
        private TrungTamNgoaiNguEntities1 db = new TrungTamNgoaiNguEntities1 ();

        // GET: STUDENTs
        public ActionResult Index()
        {
            var sTUDENTs = db.STUDENTs.Include(s => s.PARENT);
            return View(sTUDENTs.ToList());
        }

        // GET: STUDENTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT sTUDENT = db.STUDENTs.Find(id);
            if (sTUDENT == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT);
        }

        // GET: STUDENTs/Create
        public ActionResult Create()
        {
            ViewBag.ParentID = new SelectList(db.PARENTs, "ParentID", "FullName");
            return View();
        }

        // POST: STUDENTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FullName,PhoneNumber,Email,DateOfBirth,Address,ParentID")] STUDENT sTUDENT)
        {
            if (ModelState.IsValid)
            {
                db.STUDENTs.Add(sTUDENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentID = new SelectList(db.PARENTs, "ParentID", "FullName", sTUDENT.ParentID);
            return View(sTUDENT);
        }

        // GET: STUDENTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT sTUDENT = db.STUDENTs.Find(id);
            if (sTUDENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentID = new SelectList(db.PARENTs, "ParentID", "FullName", sTUDENT.ParentID);
            return View(sTUDENT);
        }

        // POST: STUDENTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FullName,PhoneNumber,Email,DateOfBirth,Address,ParentID")] STUDENT sTUDENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTUDENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentID = new SelectList(db.PARENTs, "ParentID", "FullName", sTUDENT.ParentID);
            return View(sTUDENT);
        }

        // GET: STUDENTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT sTUDENT = db.STUDENTs.Find(id);
            if (sTUDENT == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT);
        }

        // POST: STUDENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STUDENT sTUDENT = db.STUDENTs.Find(id);
            db.STUDENTs.Remove(sTUDENT);
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
