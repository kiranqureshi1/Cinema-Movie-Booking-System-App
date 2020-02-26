using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Repositories.CustomersRepositories;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Text;
using WebApplication2.Repositories.MembershipTypeRepository;
using WebApplication2.Repositories.MovieRepository;
using WebApplication2.ViewModel;
using System.Net;

namespace WebApplication2.Controllers
{
    //[RoutePrefix("api/customers")]
    public class CustomerController : Controller
    {
        // private ICustomerRepository iCustomerRepository;
        ICustomerRepository iCustomerRepository = new CustomerRepository(new CustomerContext());
        IMembershipTypeRepository iMembershipTypeRepository = new MembershipTypeRepository(new CustomerContext());
        IMovieRepository imovieRepository = new MovieRepository(new CustomerContext());
        CustomerContext CustomerContext = new CustomerContext();


        // GET: Customers
        public ActionResult Index()
        {
            // ViewBag.Message = "Customers detail is: ";
            // var MembershipTypeSignupfee = iCustomerRepository.GetMembershipTypeSignupFee(id);
            // var customers = iCustomerRepository.GetCustomers();
            // //Console.WriteLine(customers);
            // //return View("customer", (object)customers);
            //// ViewBag.Message = "Let Check!."; 
            // return View(customers);
            var customers = CustomerContext.Customers.Include(c => c.Movies);
            //var customers = CustomerContext.Customers.Include(c => c.Movies);
            //var results = from b in CustomerContext.Customers.Find(MembershipType) where ;
            var Customers = customers.ToList();
            return View(Customers);
            //return View();
            //return Content("Hey");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = CustomerContext.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //public ActionResult CustomerForm(Customer Customer)
        public ActionResult Create(Customer customer)
        {
            var membershipTypes = iMembershipTypeRepository.GetMembershipTypes();
            var Movie = imovieRepository.GetMovies();
            ViewBag.Message = "Customers form is going to display: ";
            ViewBag.Movies = imovieRepository.GetMovies();
            CustomerViewModel customerViewModel = new CustomerViewModel
            {
                MembershipTypes = CustomerContext.MembershipTypes,
                Movies = CustomerContext.Movies,
            };
            if (customer.IsSubscribedToNewsletter != true)
                ViewBag.Addon = "Selected";
            else
                ViewBag.Addon = "Not Selected";
            return View(customerViewModel);
        }



        //public ActionResult Edit(int id)
        //{
        //    Customer Customer = new Customer();
        //     Customer = iCustomerRepository.GetCustomerByID(id);
        //    CustomerViewModel customer = new CustomerViewModel();
        //    customer.MembershipTypes = CustomerContext.MembershipTypes;
        //    // customer.Customer = iCustomerRepository.GetCustomerByID(id); 
        //    // Customer = CustomerContext.Customers.Find(id),
        //   // customer.Customer = CustomerContext.Customers.Find(id);
        //        ViewBag.Message = Customer;
        //        customer.Movies = CustomerContext.Movies;
        //    //customer.Customer = CustomerContext.Customers.Where(Customer.id);
        //    // var membershipTypes = iMembershipTypeRepository.GetMembershipTypes();
        //    // var movies = imovieRepository.GetMovies();
        //    //ViewBag.MembershipTypes = membershipTypes; 

        //    return View(customer);
        //}

        [HttpPost]

        public ActionResult Create(int CustomerId, string CustomerName, bool CustomerisSubscribedToNewsLetter, int membershipTypeId, Movie movie)
        {

            // Customer customer = new Customer();
            //// Movie Movie = new Movie();

            // customer.id = CustomerId;

            // customer.Name = CustomerName;

            // customer.IsSubscribedToNewsletter = CustomerisSubscribedToNewsLetter;
            // customer.CurrentMembershipTypeId = membershipTypeId;

            using (var customerContext = new CustomerContext())
            {
                Customer customer = new Customer()
                {
                    id = CustomerId,

                    Name = CustomerName,

                    IsSubscribedToNewsletter = CustomerisSubscribedToNewsLetter,

                    CurrentMembershipTypeId = membershipTypeId
                };
                // Movie Movie = new Movie();
                customerContext.Customers.Attach(customer);
                //var mathClass = new Class { Name = "Math" };
                // Student student1 = context.Students.FirstOrDefault(s => s.Name == "Alice");
                //Student student2 = context.Students.FirstOrDefault(s => s.Name == "Bob");
                //mathClass.Students.Add(student1);
                //mathClass.Students.Add(student2);

                // CustomerContext.AddToClasses(mathClass);
                customer.Movies.Add(movie);
                customerContext.Customers.Add(customer);
                customerContext.SaveChanges();
                //iCustomerRepository.InsertCustomer(customer);
                // imovieRepository.InsertMovie(movie);

                // iCustomerRepository.Save();
            }

            //for (int i = 0; i < imovieRepository.GetMovies().Count(); i++)
            //{
            //    if (imovieRepository.GetMovies().ToList()[i].Id == movieId)
            //    {
            //        customer.Movies.Add(imovieRepository.GetMovies().ToList()[i]);
            //    }
            //    //if (movieObj.Id == movieId)
            //    //{
            //    //    customer.Movies.Add(movieObj);
            //    //}

            //}

            // customer.Movies.Add(movie);
            // movie.Customers.Add(customer);


            // iCustomerRepository.InsertCustomer(customer);
            //// imovieRepository.InsertMovie(movie);

            // iCustomerRepository.Save();
            // imovieRepository.Save();

            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            Customer Customer = new Customer();
            Customer = iCustomerRepository.GetCustomerByID(id);
            CustomerViewModel customer = new CustomerViewModel
            {
                MembershipTypes = CustomerContext.MembershipTypes,
                Movies = CustomerContext.Movies,
                Customer = Customer
            };
            return View(customer);
        }
        [HttpPost]
        public ActionResult Edit(int CustomerId, string CustomerName, bool CustomerIsSubscribedToNewsLetter, int membershipTypeId, IList<Movie> movie)
        {
            Customer Customer = new Customer();
            Customer.id = CustomerId;
            Customer.Name = CustomerName;
            Customer.IsSubscribedToNewsletter = CustomerIsSubscribedToNewsLetter;
            Customer.CurrentMembershipTypeId = membershipTypeId;
            Customer.Movies = movie;
            // customer.CurrentMembershipType.SignupFee = signupfee;
            //customer.CurrentMembershipTypeId = signupfee;
            iCustomerRepository.UpdateCustomer(Customer);
            iCustomerRepository.Save();
            //CustomerContext.Movies.AddRange(movie);
            imovieRepository.Save();
            CustomerContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = CustomerContext.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Customer customer = new Customer();
            customer = iCustomerRepository.GetCustomerByID(id);
            iCustomerRepository.DeleteCustomer(customer.id);
            iCustomerRepository.Save();
            return RedirectToAction("Index");
        }

    }
}