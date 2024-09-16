using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using OneTo1CombinedWith1ToMany.Data;
using OneTo1CombinedWith1ToMany.Models;
using OneTo1CombinedWith1ToMany.Utils;
using OneTo1CombinedWith1ToMany.ViewModels;

namespace OneTo1CombinedWith1ToMany.Controllers
{
    [AllowAnonymous]
    public class AuthorController : Controller
    {
        // GET: Author
        //public ActionResult Index()
        //{
        //    using (var session = NHibernateHelper.CreateSession())
        //    {
        //        var authors = session.Query<Author>().FetchMany(e => e.Books).ToList();
        //        return View(authors);

        //    }
        //}

        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(Author author)
        //{
        //    using (var session = NHibernateHelper.CreateSession())
        //    {
        //        using (var txn = session.BeginTransaction())
        //        {
        //            author.AuthorDetails.Author = author;
        //            session.Save(author);
        //            txn.Commit();

        //            return RedirectToAction("Index");
        //        }

        //    }

        //}

        //public ActionResult Edit(Guid id)
        //{
        //    using (var session = NHibernateHelper.CreateSession())
        //    {
        //        var user = session.Query<Author>().SingleOrDefault(u => u.Id == id);
        //        return View(user);

        //    }

        //}

        //[HttpPost]
        //public ActionResult Edit(Author author)
        //{
        //    using (var session = NHibernateHelper.CreateSession())
        //    {
        //        using (var txn = session.BeginTransaction())
        //        {
        //            author.AuthorDetails.Author = author;
        //            session.Update(author);
        //            txn.Commit();

        //            return RedirectToAction("Index");
        //        }

        //    }
        //}

        //public ActionResult Delete(Guid id)
        //{
        //    using (var session = NHibernateHelper.CreateSession())
        //    {
        //        var user = session.Get<Author>(id);
        //        return View(user);

        //    }

        //}

        //[HttpPost, ActionName("Delete")]

        //public ActionResult DeleteUser(Guid id)
        //{
        //    using (var session = NHibernateHelper.CreateSession())
        //    {
        //        using (var txn = session.BeginTransaction())
        //        {
        //            var user = session.Get<Author>(id);


        //            session.Delete(user);

        //            txn.Commit();

        //            return RedirectToAction("Index");
        //        }

        //    }

        //}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllBooks()
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var authors = session.Query<Books>().ToList();
                return View(authors);

            }

        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(LoginVm loginVM, string password)
        {

            string hashedpassword = Hashing.HashPasword(password);
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var user = session.Query<Author>().SingleOrDefault(u => u.Name == loginVM.UserName);
                    if (user != null && Hashing.ValidatePassword(password, user.Password))
                    {

                        FormsAuthentication.SetAuthCookie(loginVM.UserName, true);
                        return RedirectToAction("Index", "Author");



                    }
                    else
                    {
                        ModelState.AddModelError("", "UserName/Password doesn't match");
                        return View("Login", loginVM);

                    }


                }
            }
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Author user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Hashing.HashPasword(user.Password);
                using (var session = NHibernateHelper.CreateSession())
                {
                    using (var txn = session.BeginTransaction())
                    {
                        session.Save(user);
                        txn.Commit();
                        return RedirectToAction("Login");


                    }
                }

            }
            return View(user);

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


    }
}