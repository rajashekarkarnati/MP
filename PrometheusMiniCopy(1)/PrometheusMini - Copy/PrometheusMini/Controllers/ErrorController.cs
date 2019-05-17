using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrometheusMini.Controllers
{
    public class ErrorController : Controller
    {
        /// <summary>
        /// Project Group No-04
        /// Date of Creation-12-May-2019
        /// Description- Error Controller, shows error message
        /// </summary>
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }
    }
}