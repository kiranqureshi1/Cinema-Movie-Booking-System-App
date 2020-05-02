using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class CustomerMoviesController : Controller
    {
        private CustomerContext db = new CustomerContext();

        // GET: CustomerMovies
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.CurrentMembershipType);
            return View(customers.ToList());
        }

        // GET: CustomerMovies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: CustomerMovies/Create
        public ActionResult Create()
        {
            ViewBag.CurrentMembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Id");
            return View();
        }

        // POST: CustomerMovies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,IsSubscribedToNewsletter,CurrentMembershipTypeId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CurrentMembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Id", customer.CurrentMembershipTypeId);
            return View(customer);
        }

        // GET: CustomerMovies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerViewModel customerViewModel = new CustomerViewModel
            {
                Customer = db.Customers.Include(i => i.Movies).First(i => i.id == id),
            };

            if (customerViewModel.Customer == null)
                return HttpNotFound();

            var allMoviesList = db.Movies.ToList();
            customerViewModel.AllMovies = allMoviesList.Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            });

            ViewBag.CurrentMembershipTypeId =
                    new SelectList(db.MembershipTypes, "Id", "SignupFee", customerViewModel.Customer.CurrentMembershipTypeId);

            return View(customerViewModel);
            //Customer customer = db.Customers.Find(id);
            //if (CustomerViewModel == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.CurrentMembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Id", customer.CurrentMembershipTypeId);
            //return View(customer);
        }

        // POST: CustomerMovies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,IsSubscribedToNewsletter,CurrentMembershipTypeId, Movie")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CurrentMembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Id", customer.CurrentMembershipTypeId);
            return View(customer);
        }

        // GET: CustomerMovies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: CustomerMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
