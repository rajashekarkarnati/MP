using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrometheusMini.Models;

namespace PrometheusMini.Controllers
{
    [HandleError(View = "Error/Index")]
    public class TeacherController : Controller
    {
       
        private Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity();

        // GET: Teacher
        public ActionResult Index()
        {
            return View(db.Teachers_174852.ToList());
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teachers_174852 teachers_174852 = db.Teachers_174852.Find(id);
            if (teachers_174852 == null)
            {
                return HttpNotFound();
            }
            return View(teachers_174852);
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherId,Username,FirstName,LastName,Address,DOB,City,Password,MobileNumber,IsAdmin")] Teachers_174852 teachers_174852)
        {
            if (ModelState.IsValid)
            {
                db.Teachers_174852.Add(teachers_174852);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teachers_174852);
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teachers_174852 teachers_174852 = db.Teachers_174852.Find(id);
            if (teachers_174852 == null)
            {
                return HttpNotFound();
            }
            return View(teachers_174852);
        }

        // POST: Teacher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeacherId,Username,FirstName,LastName,Address,DOB,City,Password,MobileNumber,IsAdmin")] Teachers_174852 teachers_174852)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teachers_174852).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teachers_174852);
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teachers_174852 teachers_174852 = db.Teachers_174852.Find(id);
            if (teachers_174852 == null)
            {
                return HttpNotFound();
            }
            return View(teachers_174852);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teachers_174852 teachers_174852 = db.Teachers_174852.Find(id);
            db.Teachers_174852.Remove(teachers_174852);
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
