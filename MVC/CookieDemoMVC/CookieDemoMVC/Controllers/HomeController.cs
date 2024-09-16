using System;
using System.Web;
using System.Web.Mvc;
using CookieDemoMVC.Models;

namespace CookieDemoMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {

                SetStudentCookies(student);

                return RedirectToAction("Details");
            }

            return View(student);
        }


        public ActionResult Details()
        {

            Student student = GetStudentFromCookies();

            if (student == null)
            {
                TempData["Message"] = "Cookies expired! Please enter the details again.";
                return RedirectToAction("Create");
            }

            return View(student);
        }


        private void SetStudentCookies(Student student)
        {
            HttpCookie nameCookie = new HttpCookie("StudentName", student.Name)
            {
                Expires = DateTime.Now.AddMinutes(10)
            };

            HttpCookie idCookie = new HttpCookie("StudentID", student.ID.ToString())
            {
                Expires = DateTime.Now.AddMinutes(10)
            };

            HttpCookie emailCookie = new HttpCookie("StudentEmail", student.Email)
            {
                Expires = DateTime.Now.AddMinutes(10)
            };


            Response.Cookies.Add(nameCookie);
            Response.Cookies.Add(idCookie);
            Response.Cookies.Add(emailCookie);
        }


        private Student GetStudentFromCookies()
        {
            if (Request.Cookies["StudentName"] != null &&
                Request.Cookies["StudentID"] != null &&
                Request.Cookies["StudentEmail"] != null)
            {
                Student student = new Student
                {
                    Name = Request.Cookies["StudentName"].Value,
                    ID = int.Parse(Request.Cookies["StudentID"].Value),
                    Email = Request.Cookies["StudentEmail"].Value
                };
                return student;
            }

            return null;
        }
    }
}