using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StudentViewTemplateDemo.Models;

namespace StudentViewTemplateDemo.Controllers
{
    public class StudentController : Controller
    {

        static List<Student> students = new List<Student>()
        {


            new Student() { Id = 1, Name = "Allen", Age = 34, Address = new Address() { Id = 101, Country = "India", State = "Goa", City = "Panjim" } },
            new Student() { Id = 2, Name = "Mary", Age = 22, Address = new Address() { Id = 102, Country = "USA", State = "texas", City = "Mohali" } },
             new Student() { Id = 3, Name = "Sampada", Age = 25, Address = new Address() { Id = 103, Country = "Japan", State = "Tokyo", City = "Panjim" } },
            new Student() { Id = 4, Name = "Swamini", Age = 46, Address = new Address() { Id = 104, Country = "India", State = "Maharashtra", City = "Mumbai" } },
             new Student() { Id = 5, Name = "Swati", Age = 13, Address = new Address() { Id = 105, Country = "India", State = "Up", City = "Lakhnow" } }


        };
        //// GET: Student
        //public ActionResult GetAllStudent()
        //{
        //    var data = students;
        //    return View(data);

        //}

        ////[Route("{id:int}")]

        //public ActionResult GetStudentById(int id)
        //{
        //    var student = students.FirstOrDefault(st => st.Id == id);
        //    return View(student);
        //}

        //// [route("address/{id}")]
        //public ActionResult GetStudentAddressbyid(int id)
        //{
        //    var studentaddress = students.Where(st => st.Id == id).Select(st => st.Address).FirstOrDefault();
        //    return View(studentaddress);
        //}

        //public ActionResult AddStudent(Student student)
        //{
        //    students.Add(student);
        //    return View(student);


        //}






        //public ActionResult DeleteStudent(int id)
        //{
        //    var student = students.FirstOrDefault(s => s.Id == id);
        //    if (student != null)
        //    {
        //        students.Remove(student);
        //    }
        //    return RedirectToAction("GetAllStudents");
        //}


        ////get method for updating student
        //public ActionResult EditStudent(int id)
        //{
        //    var student = students.FirstOrDefault(s => s.Id == id);
        //    if (student == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(student);
        //}

        //[HttpPost]
        //public ActionResult EditStudent(Student updatedStudent)
        //{
        //    var student = students.FirstOrDefault(s => s.Id == updatedStudent.Id);
        //    if (student != null)
        //    {
        //        student.Name = updatedStudent.Name;
        //        student.Age = updatedStudent.Age;

        //    }
        //    return RedirectToAction("GetAllStudents");
        //}

        //public ActionResult ViewStudent(int id)
        //{
        //    var student = students.FirstOrDefault(s => s.Id == id);
        //    if (student == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(student);
        //}

        //public ActionResult EditAddress(int id)
        //{
        //    var address = students.Select(s => s.Address).FirstOrDefault(a => a.Id == id);
        //    if (address == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(address);
        //}


        //[HttpPost]
        //public ActionResult EditAddress(Address updatedAddress)
        //{
        //    var student = students.FirstOrDefault(s => s.Address.Id == updatedAddress.Id);
        //    if (student != null)
        //    {
        //        student.Address.Country = updatedAddress.Country;
        //        student.Address.State = updatedAddress.State;
        //        student.Address.City = updatedAddress.City;

        //    }
        //    return RedirectToAction("GetAddress", new { studentId = student.Id });
        //}

        //// GET: Address/DeleteAddress/5
        //public ActionResult DeleteAddress(int id)
        //{
        //    var student = students.FirstOrDefault(s => s.Address.Id == id);
        //    if (student == null || student.Address == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(student.Address);
        //}

        //// POST: Address/DeleteAddress/5
        //[HttpPost, ActionName("DeleteAddress")]
        //public ActionResult DeleteAddressConfirmed(int id)
        //{
        //    var student = students.FirstOrDefault(s => s.Address.Id == id);
        //    if (student != null)
        //    {
        //        student.Address = null;
        //    }
        //    return RedirectToAction("GetAllStudents");
        //}

        //// GET: Address/AddAddress
        ////public ActionResult AddAddress(int studentId)
        ////{
        ////    var student = students.GetStudentById(studentId);
        ////    if (student == null)
        ////    {
        ////        return HttpNotFound();
        ////    }

        ////    var address = new Address { Id = studentId };
        ////    return View(address);
        ////}

        ////// POST: Address/AddAddress
        ////[HttpPost]
        ////public ActionResult AddAddress(Address address)
        ////{
        ////    var student = students.GetStudentById(address.Id);
        ////    if (student != null)
        ////    {
        ////        address.Id = students.Select(s => s.Address?.Id).Max() + 1 ?? 1;
        ////        student.Address = address;

        ////        return RedirectToAction("GetAddress", new { studentId = student.Id });
        ////    }

        ////    return View(address);
        ////}
        ///

        public ActionResult Index()
        {
            return View(students);
        }


        public ActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Student student)
        {

            ModelState.Remove("Address.Id");


            if (ModelState.IsValid)
            {
                students.Add(student);
                return RedirectToAction("Index", student);
            }
            return View(student);
        }


        public ActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }



        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);
                if (existingStudent != null)
                {
                    existingStudent.Name = student.Name;
                    existingStudent.Age = student.Age;
                }
                return RedirectToAction("Index", student);
            }
            return View(student);
        }


        public ActionResult Delete(int id)
        {
            var item = students.Where(s => s.Id == id).FirstOrDefault();
            students.Remove(item);
            return RedirectToAction("Index");
        }


        public ActionResult AddAddress(int id)
        {
            var student = students.FirstOrDefault(st => st.Id == id);

            ViewBag.StudentId = id;
            return View(new Address { Id = student.Id });
        }


        [HttpPost]
        public ActionResult AddAddress(int id, Address address)
        {

            if (ModelState.IsValid)
            {
                var student = students.FirstOrDefault(st => st.Id == id);
                student.Address = address;
                return RedirectToAction("Index");
            }
            return View(address);
        }


        public ActionResult GetAddress(int id)
        {
            var item = students.Where(s => s.Id == id).FirstOrDefault();
            if (item.Address == null)
            {
                return RedirectToAction("AddAddress", new { id = item.Id });
            }
            return View(item.Address);
        }

        public ActionResult EditAddress(int id)
        {
            var student = students.FirstOrDefault(s => s.Address != null && s.Address.Id == id);
            return View(student.Address);
        }


        [HttpPost]
        public ActionResult EditAddress(int id, Address address)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = students.FirstOrDefault(st => st.Address.Id == id);
                if (existingStudent != null)
                {
                    existingStudent.Address.Country = address.Country;
                    existingStudent.Address.State = address.State;
                    existingStudent.Address.City = address.City;

                    return RedirectToAction("Index");
                }

            }
            return View(address);
        }


        public ActionResult DeleteAddress(int id)
        {
            var student = students.FirstOrDefault(st => st.Address.Id == id);
            student.Address = null;
            return RedirectToAction("Index");
        }












    }
}