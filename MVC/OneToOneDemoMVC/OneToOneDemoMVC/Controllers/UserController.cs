using System.Linq;
using System.Web.Mvc;
using OneToOneDemoMVC.Data;
using OneToOneDemoMVC.Models;

namespace OneToOneDemoMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var users = session.Query<User>().ToList();
                return View(users);

            }

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    user.Address.User = user;
                    session.Save(user);
                    txn.Commit();

                    return RedirectToAction("Index");
                }

            }

        }

        public ActionResult Edit(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var user = session.Query<User>().SingleOrDefault(u => u.Id == id);
                return View(user);

            }

        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    user.Address.User = user;
                    session.Update(user);
                    txn.Commit();

                    return RedirectToAction("Index");
                }

            }
        }



        public ActionResult Delete(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var user = session.Get<User>(id);
                return View(user);

            }

        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteUser(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var user = session.Get<User>(id);


                    session.Delete(user);

                    txn.Commit();

                    return RedirectToAction("Index");
                }

            }

        }

    }
}