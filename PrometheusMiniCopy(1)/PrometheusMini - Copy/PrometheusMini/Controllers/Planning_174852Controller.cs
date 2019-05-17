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
    [HandleError(View ="Error/Index")]
    public class Planning_174852Controller : Controller
    {
        /// <summary>
        /// Project Group No-04
        /// Date of Creation-12-May-2019
        /// Description- Student Controller, create plans
        /// </summary>
        private Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity();

        // GET: Planning_174852
        public ActionResult Index()
        {
            var planning_174852 = db.Planning_174852.Include(p => p.Student_174852);
            return View(planning_174852.ToList());
        }

        // GET: Planning_174852/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planning_174852 planning_174852 = db.Planning_174852.Find(id);
            if (planning_174852 == null)
            {
                return HttpNotFound();
            }
            return View(planning_174852);
        }

        // GET: Planning_174852/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Student_174852, "StudentId", "Username");
            return View();
        }

        // POST: Planning_174852/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday")] Planning_174852 planning_174852)
        {
            if (ModelState.IsValid)
            {
                db.Planning_174852.Add(planning_174852);
                db.SaveChanges();
                return RedirectToAction("Index", "Student");
            }

            ViewBag.StudentId = new SelectList(db.Student_174852, "StudentId", "Username", planning_174852.StudentId);
            return View(planning_174852);
        }

        public ActionResult Edit()
        {
            if (Session["StudentId"] != null)
            {
                try
                {
                    int id = Convert.ToInt32(Session["StudentId"]);
                    Planning_174852 plan = db.Planning_174852.Where(e => e.StudentId == id).FirstOrDefault();
                    if (plan == null)
                    {
                        return RedirectToAction("Create");
                        //return HttpNotFound();
                    }
                    return View(plan);


                }
                catch (System.NullReferenceException ex)
                {
                    return RedirectToAction("Index", "Planning_174852");
                }
            }
            else
            {
                return RedirectToAction("Login","Student");
            }
         
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string Monday, string Tuesday, string Wednesday, string Thursday, string Friday, string Saturday, int StudentId)
        {
            if (Session["StudentId"] != null)
            {
                if (ModelState.IsValid)
                {
                    Planning_174852 std = db.Planning_174852.Where(x => x.StudentId == StudentId).FirstOrDefault();
                    if (std != null)
                    {
                        std.Monday = Monday;
                        std.Tuesday = Tuesday;
                        std.Wednesday = Wednesday;
                        std.Thursday = Thursday;
                        std.Friday = Friday;
                        std.Saturday = Saturday;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index", "Student");
                }
                return RedirectToAction("Index", "Student");
            }
            else
            {
                return RedirectToAction("Login", "Student");
            }
           
        }
        // GET: Planning_174852/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planning_174852 planning_174852 = db.Planning_174852.Find(id);
            if (planning_174852 == null)
            {
                return HttpNotFound();
            }
            return View(planning_174852);
        }

        // POST: Planning_174852/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Planning_174852 planning_174852 = db.Planning_174852.Find(id);
            db.Planning_174852.Remove(planning_174852);
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
