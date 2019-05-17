using PrometheusMini.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrometheusMini.Controllers
{
    [HandleError(View = "Error/Index")]
    public class CourseController : Controller
    {
        /// <summary>
        /// Project Group No-04
        /// Date of Creation-12-May-2019
        /// Description- Course Controller, controls course operations
        /// </summary>
        Training_20Feb_MumbaiEntity s = new Training_20Feb_MumbaiEntity();
        // GET: Courses
        public ActionResult Index()
        {
            List<Courses_174852> stdlist = s.Courses_174852.ToList();
            return View(stdlist);
        }
        public ActionResult SearchbyId(string CourseName)
        {
            using (Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity())
            {
                return View(db.Courses_174852.Where(x => x.CourseName == CourseName || CourseName == null).ToList());
            }
        }
    }
}