using PrometheusMini.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PrometheusMini.Controllers
{
    [HandleError(View = "Error/Index")]
    public class StudentController : Controller
    {
      /// <summary>
      /// Project Group No-04
      /// Date of Creation-12-May-2019
      /// Description- Student Controller, controls student operations
      /// </summary>
        Training_20Feb_MumbaiEntity s = new Training_20Feb_MumbaiEntity();
        // GET: Student
        public ActionResult Index()
        {
            if (Session["StudentId"] != null)
            {
                using (Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity())
                {
                    return View(db.Student_174852.ToList());
                }
            }
            else
            {
                return RedirectToAction("Login");
            }

        }


        public ActionResult SearchbyId(string Username)
        {
                using (Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity())
                {
                    return View(db.Student_174852.Where(x => x.Username== Username).ToList());
                }

        }


        public ActionResult Update()
        {
            if (Session["StudentId"] != null)
            {
                try
                {
                    int id = Convert.ToInt32(Session["StudentId"]);
                    Student_174852 stud = s.Student_174852.Where(e => e.StudentId == id).FirstOrDefault();
                    if (stud == null)
                    {
                        return HttpNotFound();
                    }
                    return View(stud);

                }
                catch (System.NullReferenceException ex)
                {
                    return RedirectToAction("Index", "Student");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(string FName, string LName, string Address, DateTime DOB, string City, string MobileNo, int StudentId)
        {
            TempData.Clear();
            if (Session["StudentId"] != null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        Student_174852 std = s.Student_174852.Where(x => x.StudentId == StudentId).FirstOrDefault();
                        if (std != null)
                        {
                            std.FName = FName;
                            std.LName = LName;
                            std.Address = Address;
                            std.DOB = DOB;
                            std.City = City;
                            std.MobileNo = MobileNo;
                           
                                s.SaveChanges();
                                TempData["Updated"] = true;
                                return RedirectToAction("Index", "Student");
                           
                        }
                        else
                        {
                            TempData["Message"] = "You are not authorized.";
                            return RedirectToAction("Login");
                        }
                        
                    }
                    return View();
                }
                catch (Exception ex)
                {
                    TempData["message"] = "Some error occured";
                    return View();
                }
              
            }
            return View();
        }




        public ActionResult Register()
        {
            
                return View();
          
        }
        [HttpPost]
        public ActionResult Register(Student_174852 stud)
        {       if(stud == null)
            {
                ViewBag.Message = "Please Enter Data";
            }
                if (ModelState.IsValid)
                {
                    using (Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity())
                    {
                        db.Student_174852.Add(stud);
                        db.SaveChanges();
                        ViewBag.Message = "Successfully Registered.";
                    }
                    ModelState.Clear();
                    ViewBag.Message = stud.FName + " " + stud.LName + "successfully registered";
                }
                return View();
            }
           
        


        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Student_174852 user)
        {
            using (Training_20Feb_MumbaiEntity db = new Training_20Feb_MumbaiEntity())
            {
                var usr = db.Student_174852.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                if (usr != null)
                {
                    Session["StudentId"] = usr.StudentId.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("Index");
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
            if (Session["StudentId"] != null)
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
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Student");
        }


    }
}