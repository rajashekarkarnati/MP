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
    public class HomeworkController : Controller
    {
        /// <summary>
        /// Project Group No-04
        /// Date of Creation-12-May-2019
        /// Description- Homework Controller, create homework operations
        /// </summary>
        private Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity();

        // GET: Homework
        public ActionResult Index()
        {
            ViewBag.Status = false;
            ViewBag.Deleted = false;
            if (TempData.ContainsKey("ForAlert"))
            {
                ViewBag.Status = TempData["ForAlert"];
            }
            else if(TempData.ContainsKey("Deleted"))
            {
                ViewBag.Deleted = TempData["Deleted"];
            }
            TempData.Clear();
            if (Session["Admin"].ToString() == "true")
            {
                var homework_174852 = db.Homework_174852.Include(h => h.Assignments_174852);
                return View(homework_174852.ToList());
            }
            else if(Session["Admin"].ToString() == "false")
            {
                int id = Convert.ToInt32(Session["TeacherId"]);
                var homework_174852 = db.Teaches_174852.Where(a=>a.TeacherId==id).FirstOrDefault();
                if(homework_174852 == null)
                {
                    return RedirectToAction("Create", "Teaches");
                }
                else
                {
                    var res = db.Homework_174852.Where(a => a.Assignments_174852.TeacherId == id).FirstOrDefault();
                    if ( res == null)
                    {
                        TempData["CourseId"] = homework_174852.CourseId;
                        return RedirectToAction("Create", "Homework");
                    }
                    return RedirectToAction("Edit","Homework", new { id= res.HomeWorkId });
                }
            }
            return View();
        }

        // GET: Homework/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homework_174852 homework_174852 = db.Homework_174852.Find(id);
            if (homework_174852 == null)
            {
                return HttpNotFound();
            }
            return View(homework_174852);
        }

        // GET: Homework/Create
        public ActionResult Create()
        {
            ViewBag.HasCourse = false;
            if(TempData.ContainsKey("CourseId"))
            {
                ViewBag.HasCourse = true;
                ViewBag.CourseId = TempData["CourseId"];
                TempData.Clear();
            }
            ViewBag.HomeWorkid = db.Homework_174852.Count();
            //ViewBag.HomeWorkId = new SelectList(db.Assignments_174852, "HomeWorkId", "HomeWorkId");
            return View();
        }

        // POST: Homework/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HomeWorkId,Description,Deadline,ReqTime,LongDescription,CourseId")] Homework_174852 homework_174852)
        {
            ViewBag.HasCourse = false;
            ViewBag.HomeWorkid = db.Homework_174852.Count();
            try
            {
                if (ModelState.IsValid)
                {
                    db.Homework_174852.Add(homework_174852);
                    Assignments_174852 new_assignment = new Assignments_174852();
                    new_assignment.CourseId = int.Parse(homework_174852.CourseId.ToString());
                    new_assignment.HomeWorkId = homework_174852.HomeWorkId;
                    new_assignment.TeacherId = int.Parse(Session["TeacherId"].ToString());
                    db.Assignments_174852.Add(new_assignment);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Admin");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Cannot Insert");
                return View(homework_174852);
            }
            ViewBag.HomeWorkId = new SelectList(db.Assignments_174852, "HomeWorkId", "HomeWorkId", homework_174852.HomeWorkId);
            return View(homework_174852);
        }

        // GET: Homework/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homework_174852 homework_174852 = db.Homework_174852.Find(id);
            if (homework_174852 == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomeWorkId = new SelectList(db.Assignments_174852, "HomeWorkId", "HomeWorkId", homework_174852.HomeWorkId);
            return View(homework_174852);
        }

        // POST: Homework/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HomeWorkId,Description,Deadline,ReqTime,LongDescription")] Homework_174852 homework_174852)
        {
            TempData["ForAlert"] = false;
            if (ModelState.IsValid)
            {
                db.Entry(homework_174852).State = EntityState.Modified;
                db.SaveChanges();
                TempData["ForAlert"] = true;
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.HomeWorkId = new SelectList(db.Assignments_174852, "HomeWorkId", "HomeWorkId", homework_174852.HomeWorkId);
            return View(homework_174852);
        }

        // GET: Homework/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homework_174852 homework_174852 = db.Homework_174852.Find(id);
            if (homework_174852 == null)
            {
                return HttpNotFound();
            }
            return View(homework_174852);
        }

        // POST: Homework/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Homework_174852 homework_174852 = db.Homework_174852.Find(id);
            db.Homework_174852.Remove(homework_174852);
            db.SaveChanges();
            TempData["Deleted"] = true;
            return RedirectToAction("Index", "Admin");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Search(string Description)
        {
                using (Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity())
                {
                    return View(db.Homework_174852.Where(x => x.Description == Description).ToList());
                }
         

        }
    }
}
