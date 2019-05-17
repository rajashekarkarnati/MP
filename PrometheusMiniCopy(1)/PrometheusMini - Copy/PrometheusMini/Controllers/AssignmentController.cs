using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrometheusMini.Models;

namespace PrometheusMini.Controllers
{
    [HandleError(View = "Error/Index")]
    public class AssignmentController : Controller
    {
        /// <summary>
        /// Project Group No-04
        /// Date of Creation-12-May-2019
        /// Description- Assignment Controller, controls Assignment operations
        /// </summary>
        Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity();

        // GET: Assignment
        public ActionResult Index()
        {
            //for (int i = 0; i < Session.Count; i++)
            //{
            //    string value = "Key: " + Session.Keys[i] + ", Value: " + Session[Session.Keys[i]].ToString();

            //    Response.Write(value);
            //}
            ViewBag.Count = 0;
            ViewBag.Status = false;
            if(TempData.ContainsKey("CourseId"))
            {
                try
                {
                    int id = int.Parse(Session["TeacherId"].ToString());
                    int CourseId = Convert.ToInt32(TempData["CourseId"]);
                    var res = db.Assignments_174852.Where(a => a.CourseId == CourseId && a.TeacherId == id).ToList();
                    if (res != null)
                    {
                        ViewBag.Count = res.Count();
                        ViewBag.Status = TempData["Status"];
                        TempData.Clear();
                        return View(res);
                    }
                }
                catch(Exception ex)
                {
                    TempData.Clear();
                    return View();
                }
            }
            TempData.Clear();
            return View();
        }

        [HttpPost]
        public ActionResult Index(string CourseName)
        {
            TempData.Clear();
            ViewBag.Status = false;
            ViewBag.Count = 0;
            if (CourseName != null)
            {
                try
                {
                    int id = int.Parse(Session["TeacherId"].ToString());
                    var res = db.Assignments_174852.Where(a => a.Courses_174852.CourseName.ToLower() == CourseName.ToLower() && a.TeacherId == id);
                    if (res != null)
                    {
                        ViewBag.Count = res.Count();
                        return View(res.ToList());
                    }
                }
                catch (Exception ex)
                {
                    return View(CourseName);
                }
            }        
            return View(CourseName);
        }

        [HttpPost]
        public ActionResult UpdateAssignmentRecord(int? TeacherId, int? HomeWorkId, string CourseName,  string LongDescription, string ReqTime, string Description, string Deadline, int? CourseId,  string StartDate, string EndDate)
        {
            TempData["CourseId"] = CourseId;
            try
            {

                var course = db.Courses_174852.Where(a => a.CourseId == CourseId).FirstOrDefault();
                var Homework = db.Homework_174852.Where(a => a.HomeWorkId == HomeWorkId).FirstOrDefault();
                if (course != null)
                {
                    course.StartDate = StartDate;
                    course.EndDate = (EndDate);
                }
                if (Homework != null)
                {
                    Homework.LongDescription = LongDescription;
                    Homework.ReqTime = ReqTime;
                    Homework.Description = Description;
                    Homework.Deadline = Deadline;
                }
                db.SaveChanges();
                TempData["Status"] = true;
            }
            catch(Exception ex)
            {
                TempData["Status"] = false;
            }
            return RedirectToAction("Index", "Assignment");
        }
    }
}