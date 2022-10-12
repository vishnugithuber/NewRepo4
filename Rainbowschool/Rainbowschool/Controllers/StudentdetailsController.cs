using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rainbowschool.Models;

namespace Rainbowschool.Controllers
{
    public class StudentdetailsController : Controller
    {
        private RainbowSchoolDBEntities1 db = new RainbowSchoolDBEntities1();

        // GET: Studentdetails
        public ActionResult Index()
        {
            return View(db.Studentdetails.ToList());
        }

        // GET: Studentdetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentdetail studentdetail = db.Studentdetails.Find(id);
            if (studentdetail == null)
            {
                return HttpNotFound();
            }
            return View(studentdetail);
        }

        // GET: Studentdetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Studentdetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,StudentName,Subject,Class")] Studentdetail studentdetail)
        {
            if (ModelState.IsValid)
            {
                db.Studentdetails.Add(studentdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentdetail);
        }

        // GET: Studentdetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentdetail studentdetail = db.Studentdetails.Find(id);
            if (studentdetail == null)
            {
                return HttpNotFound();
            }
            return View(studentdetail);
        }

        // POST: Studentdetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,StudentName,Subject,Class")] Studentdetail studentdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentdetail);
        }

        // GET: Studentdetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentdetail studentdetail = db.Studentdetails.Find(id);
            if (studentdetail == null)
            {
                return HttpNotFound();
            }
            return View(studentdetail);
        }

        // POST: Studentdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Studentdetail studentdetail = db.Studentdetails.Find(id);
            db.Studentdetails.Remove(studentdetail);
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
