using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PrometheusMini.Models;

namespace PrometheusMini.Controllers
{
    public class Admi1Controller : Controller
    {
        /// <summary>
        /// Project Group No-04
        /// Date of Creation-12-May-2019
        /// Description- Admin Controller, controls Admin operations
        /// </summary>
        private Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity();

        // GET: Admi1
        public ActionResult Index()
        {
            if (Session["TeacherId"] != null)
            {
                var student_174852 = db.Student_174852.Include(s => s.Planning_174852);
                return View(student_174852.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        // GET: Admi1/Details/5
        public ActionResult Details(int? id)
        {

            if (Session["TeacherId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Student_174852 student_174852 = db.Student_174852.Find(id);
                if (student_174852 == null)
                {
                    return HttpNotFound();
                }
                return View(student_174852);
            }
            else
            {
                return RedirectToAction("Login","Admin" );
            }
           
        }

        // GET: Admi1/Create
        public ActionResult Create()
        {
            if (Session["TeacherId"] != null)
            {
                ViewBag.StudentId = new SelectList(db.Planning_174852, "StudentId", "Monday");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        // POST: Admi1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,Username,FName,LName,Address,DOB,City,Password,MobileNo")] Student_174852 student_174852)
        {
            if (Session["TeacherId"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Student_174852.Add(student_174852);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.StudentId = new SelectList(db.Planning_174852, "StudentId", "Monday", student_174852.StudentId);
                return View(student_174852);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
          
        }

        // GET: Admi1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["TeacherId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Student_174852 student_174852 = db.Student_174852.Find(id);
                if (student_174852 == null)
                {
                    return HttpNotFound();
                }
                ViewBag.StudentId = new SelectList(db.Planning_174852, "StudentId", "Monday", student_174852.StudentId);
                return View(student_174852);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        // POST: Admi1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,Username,FName,LName,Address,DOB,City,Password,MobileNo")] Student_174852 student_174852)
        {
            if (Session["TeacherId"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(student_174852).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.StudentId = new SelectList(db.Planning_174852, "StudentId", "Monday", student_174852.StudentId);
                return View(student_174852);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        // GET: Admi1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["TeacherId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Student_174852 student_174852 = db.Student_174852.Find(id);
                if (student_174852 == null)
                {
                    return HttpNotFound();
                }
                return View(student_174852);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        // POST: Admi1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_174852 student_174852 = db.Student_174852.Find(id);
            db.Student_174852.Remove(student_174852);
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
        //////////////////////////////////////////////////////TEACHER/////////////////////////////////////////////////////
        // GET: Teacher
        public ActionResult TIndex()
        {
            if (Session["TeacherId"] != null)
            {
                return View(db.Teachers_174852.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        // GET: Teacher/Details/5
        public ActionResult TDetails(int? id)
        {
            if (Session["TeacherId"] != null)
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
            else
            {
                return RedirectToAction("Login", "Admin");
            }
          
        }

        // GET: Teacher/Create
        public ActionResult TCreate()
        {
            if (Session["TeacherId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
            
        }

        // POST: Teacher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TCreate([Bind(Include = "TeacherId,Username,FirstName,LastName,Address,DOB,City,Password,MobileNumber,IsAdmin")] Teachers_174852 teachers_174852)
        {
            if (Session["TeacherId"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Teachers_174852.Add(teachers_174852);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(teachers_174852);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        // GET: Teacher/Edit/5
        public ActionResult TEdit(int? id)
        {
            if (Session["TeacherId"] != null)
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
            else
            {
                return RedirectToAction("Login", "Admin");
            }
           
        }

        // POST: Teacher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TEdit([Bind(Include = "TeacherId,Username,FirstName,LastName,Address,DOB,City,Password,MobileNumber,IsAdmin")] Teachers_174852 teachers_174852)
        {
            if (Session["TeacherId"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(teachers_174852).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(teachers_174852);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
           
        }

        // GET: Teacher/Delete/5
        public ActionResult TDelete(int? id)
        {
            if (Session["TeacherId"] != null)
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
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult TDeleteConfirmed(int id)
        {
            Teachers_174852 teachers_174852 = db.Teachers_174852.Find(id);
            db.Teachers_174852.Remove(teachers_174852);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /////////////////////////////////////////Courses//////////////////////////////////////////////////////
        public ActionResult CIndex()
        {
            if (Session["TeacherId"] != null)
            {
                var courses_174852 = db.Courses_174852.Include(c => c.Enrollment_174852);
                return View(courses_174852.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
           
        }

        // GET: C/Details/5
        public ActionResult CDetails(int? id)
        {
            if (Session["TeacherId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Courses_174852 courses_174852 = db.Courses_174852.Find(id);
                if (courses_174852 == null)
                {
                    return HttpNotFound();
                }
                return View(courses_174852);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
         
        }

        // GET: C/Create
        public ActionResult CCreate()
        {
            if (Session["TeacherId"] != null)
            {
                ViewBag.CourseId = new SelectList(db.Enrollment_174852, "CourseId", "CourseId");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
           
        }

        // POST: C/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CCreate([Bind(Include = "CourseId,CourseName,StartDate,EndDate")] Courses_174852 courses_174852)
        {
            if (Session["TeacherId"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Courses_174852.Add(courses_174852);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.CourseId = new SelectList(db.Enrollment_174852, "CourseId", "CourseId", courses_174852.CourseId);
                return View(courses_174852);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
          
        }

        // GET: C/Edit/5
        public ActionResult CEdit(int? id)
        {
            if (Session["TeacherId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Courses_174852 courses_174852 = db.Courses_174852.Find(id);
                if (courses_174852 == null)
                {
                    return HttpNotFound();
                }
                ViewBag.CourseId = new SelectList(db.Enrollment_174852, "CourseId", "CourseId", courses_174852.CourseId);
                return View(courses_174852);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
          
        }

        // POST: C/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CEdit([Bind(Include = "CourseId,CourseName,StartDate,EndDate")] Courses_174852 courses_174852)
        {
            if (Session["TeacherId"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(courses_174852).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.CourseId = new SelectList(db.Enrollment_174852, "CourseId", "CourseId", courses_174852.CourseId);
                return View(courses_174852);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
          
        }

        // GET: C/Delete/5
        public ActionResult CDelete(int? id)
        {
            if (Session["TeacherId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Courses_174852 courses_174852 = db.Courses_174852.Find(id);
                if (courses_174852 == null)
                {
                    return HttpNotFound();
                }
                return View(courses_174852);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
         
        }

        // POST: C/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult CDeleteConfirmed(int id)
        {
            Courses_174852 courses_174852 = db.Courses_174852.Find(id);
            db.Courses_174852.Remove(courses_174852);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //////////////////////////////////////////////////SEARCH////////////////////////////////////////////////////////////
        public ActionResult SearchS(string Username)
        {
            if (Session["TeacherId"] != null)
            {
                using (Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity())
                {
                    return View(db.Student_174852.Where(x => x.Username == Username).ToList());
                }
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
         
        }
        public ActionResult SearchT(string Username)
        {
            if (Session["TeacherId"] != null)
            {
                using (Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity())
                {
                    return View(db.Teachers_174852.Where(x => x.Username == Username).ToList());
                }
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
          
        }
        public ActionResult SearchC(string CourseName)
        {
            if (Session["TeacherId"] != null)
            {
                using (Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity())
                {
                    return View(db.Courses_174852.Where(x => x.CourseName == CourseName).ToList());
                }
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
           
            }
    }


}
