using System.Web.Mvc;
using SessionTimeOutDemoMVC.Models;

namespace SessionTimeOutDemoMVC.Controllers
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

                Session["Student"] = student;


                Session.Timeout = 2;

                return RedirectToAction("Details");
            }

            return View(student);
        }


        public ActionResult Details()
        {

            if (Session["Student"] == null)
            {
                TempData["Message"] = "Session expired! Please enter the details again.";
                return RedirectToAction("Create");
            }


            Student student = Session["Student"] as Student;
            return View(student);
        }
    }
}
