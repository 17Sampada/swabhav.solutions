using System;
using System.Linq;
using System.Web.Mvc;
using OneTo1CombinedWith1ToMany.Data;
using OneTo1CombinedWith1ToMany.Models;

namespace OneTo1CombinedWith1ToMany.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BookDetails(Guid authorId)
        {
            TempData["authorId"] = authorId;
            using (var session = NHibernateHelper.CreateSession())
            {
                var books = session.Query<Books>().Where(o => o.Author.Id == authorId).ToList();

                return View(books);

            }
        }

        public ActionResult Create()
        {
            int authorId = (int)TempData.Peek("authorId");


            return View();
        }


        [HttpPost]
        public ActionResult Create(Books book)
        {

            int authorId = (int)TempData.Peek("authorId");// Ensure empId is available after form re-display


            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var employee = session.Get<Author>(authorId);

                    book.Author = employee;

                    session.Save(book);
                    txn.Commit();





                    TempData["authorId"] = authorId;
                    return RedirectToAction("BookDetails", new { authorId = authorId });


                }

            }
        }

        public ActionResult Edit(Guid id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var book = session.Get<Books>(id);

                return View(book);
            }
        }

        [HttpPost]

        public ActionResult Edit(Books order)
        {
            Guid authorId = (Guid)TempData.Peek("authorId");
            if (order != null)
            {
                using (var session = NHibernateHelper.CreateSession())
                {
                    using (var transaction = session.BeginTransaction())

                    {
                        order.Author.Id = authorId;
                        session.Update(order);
                        transaction.Commit();
                        return RedirectToAction("BookDetails", new { authorId = authorId });
                    }
                }

            }
            return View();




        }

        public ActionResult Delete(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var order = session.Get<Books>(id);
                    return View(order);
                }
            }
        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteOrder(int id)
        {
            int empId = (int)TempData.Peek("authorId");
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var order = session.Get<Books>(id);
                    session.Delete(order);
                    transaction.Commit();
                    return RedirectToAction("BookDetails"/*, new { authorId = authorId }*/);
                }
            }
        }
    }
}