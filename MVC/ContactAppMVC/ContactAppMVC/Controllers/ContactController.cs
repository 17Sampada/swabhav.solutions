﻿using System;
using System.Linq;
using System.Web.Mvc;
using ContactAppMVC.Data;
using ContactAppMVC.Models;

namespace ContactAppMVC.Controllers
{
    [Authorize(Roles = "Staff")]
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult GetAllContacts()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            Guid userId = (Guid)Session["UserId"];
            using (var session = NHibernateHelper.CreateSession())
            {

                var contacts = session.Query<Contact>()
                                      .Where(c => c.User.Id == userId)
                                      .Select(c => new Contact
                                      {
                                          Id = c.Id,
                                          FName = c.FName,
                                          LName = c.LName,
                                          IsActive = c.IsActive
                                      })
                                      .ToList();

                return Json(contacts, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            Guid userId = (Guid)Session["UserId"];
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var user = session.Query<User>().FirstOrDefault(u => u.Id == userId);
                    if (user == null)
                    {
                        return Json(new { success = false, message = "User not found" }, JsonRequestBehavior.AllowGet);
                    }
                    contact.User = user;

                    session.Save(contact);
                    txn.Commit();
                }

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult GetContact(Guid id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var contact = session.Get<Contact>(id);
                if (contact == null)
                {
                    return Json(new { success = false, message = "Contact not found" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new
                {
                    success = true,
                    contact = new
                    {
                        contact.Id,
                        contact.FName,
                        contact.LName
                    }
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult EditContact(Contact contact)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var existingContact = session.Get<Contact>(contact.Id);
                    if (existingContact == null)
                    {
                        return Json(new { success = false, message = "Contact not found" });
                    }

                    existingContact.FName = contact.FName;
                    existingContact.LName = contact.LName;

                    session.Update(existingContact);
                    txn.Commit();

                    return Json(new { success = true });
                }
            }
        }

        [HttpPost]
        public ActionResult UpdateIsActiveStatus(Guid contactId, bool isActive)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var contact = session.Get<Contact>(contactId);
                    if (contact != null)
                    {
                        contact.IsActive = isActive;
                        session.Update(contact);
                        txn.Commit();
                        return Json(new { success = true });
                    }
                    else
                    {
                        return Json(new { success = false, message = "Contact not found" });
                    }
                }
            }

        }

    }
}