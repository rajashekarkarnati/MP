using PrometheusMini.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PrometheusMini.Controllers
{
    [HandleError(View = "Error/Index")]
    public class AdminController : Controller
    {
        /// <summary>
        /// Project Group No-04
        /// Date of Creation-12-May-2019
        /// Description- This a Teacher Controller, controls Teacher operations
        /// </summary>
        Training_20Feb_MumbaiEntity s = new Training_20Feb_MumbaiEntity();
        // GET: Student
        public ActionResult Index()
            {
            if (Session["TeacherId"] != null)
            {
                using (Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity())
                {
                    return View(db.Teachers_174852.ToList());
                }
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
            public ActionResult Register()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Register(Teachers_174852 teach)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                    Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity();
                        db.Teachers_174852.Add(teach);
                        db.SaveChanges();
                        ModelState.Clear();
                        ViewBag.Message = teach.FirstName + " " + teach.LastName + "successfully registered";
                        return RedirectToAction("Login");
                    }
                    catch (Exception ex)
                    {
                        return View(teach);
                    }
                }
                return View();
            }

            public ActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Login(Teachers_174852 user)
            {
            using (Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity())
            {

                var usr = db.Teachers_174852.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                if (usr != null)
                {
                    Session["TeacherId"] = usr.TeacherId.ToString();
                    Session["Username"] = usr.Username.ToString();
                    Session["Admin"] = usr.IsAdmin.ToLower();
                    if (usr != null && usr.IsAdmin.ToLower() == "true")
                    {
                        return RedirectToAction("Index", "Admi1");
                    }
                    else if (usr != null && usr.IsAdmin.ToLower() == "false")
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Session.Clear();
                        ModelState.AddModelError("", "Username or Password is wrong.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
            }
                return View();
            }

            public ActionResult LoggedIn()
            {
                if (Session["TeacherId"] != null)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            public ActionResult LogOut()
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login", "Admin");
            }
        // GET: Enrollment_174852/Details/
        public ActionResult SearchbyId(string Username)
        {
            using (Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity())
            {
                return View(db.Teachers_174852.Where(x => x.Username == Username).ToList());
            }

        }
        public ActionResult Update()
        {
            if (Session["TeacherId"] != null)
            {
                try
                {
                    int id = Convert.ToInt32(Session["TeacherId"]);
                    Teachers_174852 stud = s.Teachers_174852.Where(e => e.TeacherId == id).FirstOrDefault();
                    if (stud == null)
                    {
                        return HttpNotFound();
                    }
                    return View(stud);


                }
                catch (System.NullReferenceException ex)
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Teachers_174852 t)
        {
            if (Session["TeacherId"] != null)
            {
                try
                {


                    if (ModelState.IsValid)
                    {
                        Teachers_174852 std = s.Teachers_174852.Where(x => x.TeacherId == t.TeacherId).FirstOrDefault();
                        if (std != null)
                        {
                            std.FirstName = t.FirstName;
                            std.LastName = t.LastName;
                            std.Address = t.Address;
                            std.DOB = t.DOB;
                            std.City = t.City;
                            std.MobileNumber = t.MobileNumber;
                            s.SaveChanges();
                        }
                        return RedirectToAction("Index", "Admin");
                    }
                    return RedirectToAction("Index", "Admin");
                }
                catch(Exception ex)
                {
                    return RedirectToAction("Index", "Admin");
                }
                }
            else
            {
                return RedirectToAction("Login");
            }
        }

    }
}