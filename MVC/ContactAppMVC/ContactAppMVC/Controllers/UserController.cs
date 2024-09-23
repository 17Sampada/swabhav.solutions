using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ContactAppMVC.Data;
using ContactAppMVC.Models;
using ContactAppMVC.ViewModels;
using NHibernate.Linq;

namespace ContactAppMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {

                    var getUser = session.Query<User>().SingleOrDefault(u => u.UserName == loginVM.UserName);
                    if (getUser != null)
                    {
                        if (getUser.IsActive)
                        {

                            if (BCrypt.Net.BCrypt.Verify(loginVM.Password, getUser.Password))
                            {
                                FormsAuthentication.SetAuthCookie(loginVM.UserName, true);
                                Session["UserId"] = getUser.Id;
                                return RedirectToAction("ViewStaffs");
                            }
                        }
                        else
                        {
                            if (BCrypt.Net.BCrypt.Verify(loginVM.Password, getUser.Password))
                            {
                                FormsAuthentication.SetAuthCookie(loginVM.UserName, true);
                                Session["UserId"] = getUser.Id;
                                return RedirectToAction("Index", "Contact");
                            }

                        }
                    }
                    ModelState.AddModelError("", "UserName/Password doesn't exists");
                    return View();
                }
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user, string password)
        {

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {

                    user.Role.User = user;
                    user.IsActive = true;
                    if (user.IsAdmin)
                    {
                        user.Role.RoleName = "Admin";
                    }
                    else
                    {
                        user.Role.RoleName = "Staff";
                    }
                    session.Save(user);
                    txn.Commit();
                    return RedirectToAction("ViewStaffs");
                }
            }
        }


        [Authorize(Roles = "Admin, Staff")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult ViewStaffs()
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var staffs = session.Query<User>().FetchMany(u => u.Contacts).Where(u => u.IsAdmin == false).ToList();
                return View(staffs);
            }
        }

        public ActionResult ViewAdmins()
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var admins = session.Query<User>().Where(u => u.IsAdmin == true).ToList();
                return View(admins);
            }
        }

        public ActionResult EditUser(Guid userId)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var fetchUser = session.Get<User>(userId);
                return View(fetchUser);
            }
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    user.Role.User = user;
                    if (user.IsAdmin)
                        user.Role.RoleName = "Admin";

                    else
                        user.Role.RoleName = "Staff";
                    session.Update(user);
                    txn.Commit();
                    return RedirectToAction("ViewStaffs");
                }
            }

        }


        public ActionResult ViewContacts(Guid userId)
        {
            TempData["userId"] = userId;
            using (var session = NHibernateHelper.CreateSession())
            {
                var contacts = session.Query<Contact>().Where(c => c.User.Id == userId).ToList();
                return View(contacts);
            }
        }

        public ActionResult ViewContactDetails(Guid contactId)
        {
            TempData["contactId"] = contactId;
            using (var session = NHibernateHelper.CreateSession())
            {
                var contactDetails = session.Query<ContactDetails>().Where(c => c.Contact.Id == contactId).ToList();
                return View(contactDetails);
            }
        }


        [HttpPost]
        public ActionResult UpdateIsActiveStatus(Guid userId, bool isActive)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var user = session.Get<User>(userId);
                    if (user != null)
                    {
                        user.IsActive = isActive;
                        session.Update(user);
                        txn.Commit();
                    }
                }
            }
            return Json(new { success = true });
        }
    }






}