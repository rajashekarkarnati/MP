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
    public class TeachesController : Controller
    {
        /// <summary>
        /// Project Group No-04
        /// Date of Creation-12-May-2019
        /// Description- Teaches Controller, For selecting course to teach
        /// </summary>
        private Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity();

        // GET: Teaches
        public ActionResult Index()
        {
            var teaches_174852 = db.Teaches_174852.Include(t => t.Courses_174852);
            return View(teaches_174852.ToList());
        }

        // GET: Teaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teaches_174852 teaches_174852 = db.Teaches_174852.Find(id);
            if (teaches_174852 == null)
            {
                return HttpNotFound();
            }
            return View(teaches_174852);
        }

        // GET: Teaches/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses_174852, "CourseId", "CourseName");
            return View();
        }

        // POST: Teaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherId,CourseId")] Teaches_174852 teaches_174852)
        {
            if (ModelState.IsValid)
            {
                var res = db.Teaches_174852.Where(a => a.TeacherId == teaches_174852.TeacherId).FirstOrDefault();
                if (res == null)
                {
                    var c = db.Teaches_174852.Where(a => a.CourseId == teaches_174852.CourseId && a.TeacherId == teaches_174852.TeacherId).FirstOrDefault();
                    if (c == null)
                    {
                        db.Teaches_174852.Add(teaches_174852);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ViewBag.CourseId = new SelectList(db.Courses_174852, "CourseId", "CourseName");
                        ModelState.AddModelError("", "Cant Enroll, May Other Teacher or Yourself Already Teaching Same Course");
                        return View();
                    }
                }
                else
                {
                    ViewBag.CourseId = new SelectList(db.Courses_174852, "CourseId", "CourseName");
                    ModelState.AddModelError("", "Cant Enroll, May You Already Teaching with Other Course or Others Teacher is teaching");
                    return View();
                }
            }

            ViewBag.CourseId = new SelectList(db.Courses_174852, "CourseId", "CourseName", teaches_174852.CourseId);
            return View(teaches_174852);
        }

        // GET: Teaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teaches_174852 teaches_174852 = db.Teaches_174852.Find(id);
            if (teaches_174852 == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses_174852, "CourseId", "CourseName", teaches_174852.CourseId);
            return View(teaches_174852);
        }

        // POST: Teaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeacherId,CourseId")] Teaches_174852 teaches_174852)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teaches_174852).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses_174852, "CourseId", "CourseName", teaches_174852.CourseId);
            return View(teaches_174852);
        }

        // GET: Teaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teaches_174852 teaches_174852 = db.Teaches_174852.Find(id);
            if (teaches_174852 == null)
            {
                return HttpNotFound();
            }
            return View(teaches_174852);
        }

        // POST: Teaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teaches_174852 teaches_174852 = db.Teaches_174852.Find(id);
            db.Teaches_174852.Remove(teaches_174852);
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
