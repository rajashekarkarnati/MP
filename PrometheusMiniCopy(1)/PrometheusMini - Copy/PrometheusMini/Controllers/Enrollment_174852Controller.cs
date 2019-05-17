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
    public class Enrollment_174852Controller : Controller
    {
        /// <summary>
        /// Project Group No-04
        /// Date of Creation-12-May-2019
        /// Description- Enrollment Controller, controls enrollment operations
        /// </summary>
        private Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity();

        // GET: Enrollment_174852
        public ActionResult Index()
        {
            var enrollment_174852 = db.Enrollment_174852.Include(e => e.Courses_174852).Include(e => e.Student_174852);
            return View(enrollment_174852.ToList());
        }
        public ActionResult Index1()
        {
            int id = Convert.ToInt32(Session["TeacherId"]);
            var teachercourse = db.Teaches_174852.Where(a => a.TeacherId == id).FirstOrDefault();
            if (teachercourse != null)
            {
                var enrollment_174852 = db.Enrollment_174852.Where(a => a.CourseId == teachercourse.CourseId).Include(e => e.Courses_174852).Include(e => e.Student_174852);
                return View(enrollment_174852.ToList());
            }
            return View();
        }

        // GET: Enrollment_174852/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment_174852 enrollment_174852 = db.Enrollment_174852.Find(id);
            if (enrollment_174852 == null)
            {
                return HttpNotFound();
            }
            return View(enrollment_174852);
        }

        // GET: Enrollment_174852/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses_174852, "CourseId", "CourseName");
            ViewBag.StudentId = new SelectList(db.Student_174852, "StudentId", "Username");
            return View();
        }

        // POST: Enrollment_174852/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,StudentId")] Enrollment_174852 enrollment_174852)
        {
            if (ModelState.IsValid)
            {
                var res = db.Enrollment_174852.Where(a => a.StudentId == enrollment_174852.StudentId).FirstOrDefault();
                if (res == null)
                {
                    db.Enrollment_174852.Add(enrollment_174852);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    ModelState.AddModelError("", "May be You are Already Enrolled with One Course ");
                }
            }

            ViewBag.CourseId = new SelectList(db.Courses_174852, "CourseId", "CourseName", enrollment_174852.CourseId);
            ViewBag.StudentId = new SelectList(db.Student_174852, "StudentId", "Username", enrollment_174852.StudentId);
            return View(enrollment_174852);
        }

        // GET: Enrollment_174852/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment_174852 enrollment_174852 = db.Enrollment_174852.Find(id);
            if (enrollment_174852 == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses_174852, "CourseId", "CourseName", enrollment_174852.CourseId);
            ViewBag.StudentId = new SelectList(db.Student_174852, "StudentId", "Username", enrollment_174852.StudentId);
            return View(enrollment_174852);
        }

        // POST: Enrollment_174852/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,StudentId")] Enrollment_174852 enrollment_174852)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment_174852).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses_174852, "CourseId", "CourseName", enrollment_174852.CourseId);
            ViewBag.StudentId = new SelectList(db.Student_174852, "StudentId", "Username", enrollment_174852.StudentId);
            return View(enrollment_174852);
        }

        // GET: Enrollment_174852/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment_174852 enrollment_174852 = db.Enrollment_174852.Find(id);
            if (enrollment_174852 == null)
            {
                return HttpNotFound();
            }
            return View(enrollment_174852);
        }

        // POST: Enrollment_174852/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollment_174852 enrollment_174852 = db.Enrollment_174852.Find(id);
            db.Enrollment_174852.Remove(enrollment_174852);
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
