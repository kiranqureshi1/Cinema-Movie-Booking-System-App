using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Repositories.CustomersRepositories;
using WebApplication2.Repositories.MovieRepository;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class MovieController : Controller
    {
        IMovieRepository iMovieRepository = new MovieRepository(new CustomerContext());
        ICustomerRepository iCustomerRepository = new CustomerRepository(new CustomerContext());
        CustomerContext CustomerContext = new CustomerContext();

        public ActionResult Index()
        {
            var Movies = iMovieRepository.GetMovies();
            //var movies = CustomerContext.Movies.Include(s => s.Customers);
            //var customers = CustomerContext.Customers.Include(c => c.Movies);
            //var Movies = movies.ToList();
            return View(Movies);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = CustomerContext.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = CustomerContext.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Movie movie = new Movie();
            movie = iMovieRepository.GetMovieByID(id);
            iMovieRepository.DeleteMovie(movie.Id);
            iMovieRepository.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Movies form is going to display: ";
            CustomerViewModel customers = new CustomerViewModel()
            {
                Customers = iCustomerRepository.GetCustomers()
            };
            //var customers = iCustomerRepository.GetCustomers();
            return View(customers);
        }

        [HttpPost]

        public ActionResult Create(int MovieId, string MovieName, int TotalSeats, int Ticket, bool AgeRestriction, bool DisabilityResourcesRequirments, List<Customer> Customers)

        {

            Movie movie = new Movie()
            {
                Id = MovieId,
                Name = MovieName,
                TotalSeats = TotalSeats,
                Ticket = Ticket,
                AgeRestriction = AgeRestriction,
                DisabilityResourcesRequirments = DisabilityResourcesRequirments,
                Customers = Customers
            };
            //for (int i = 0; i < Customers.Count; i++)
            //{
            //   movie.Customers.Add(Customers[i]);
            //}
            iMovieRepository.InsertMovie(movie);
            iMovieRepository.Save();

            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            Movie movie = new Movie();
            movie = iMovieRepository.GetMovieByID(id);
            CustomerViewModel Movie = new CustomerViewModel
            {
                Customers = CustomerContext.Customers,
                Movie = movie
            };
            return View(Movie);
        }

        [HttpPost]
        public ActionResult Edit(int MovieId, string MovieName, int TotalSeats, int Ticket, bool AgeRestriction, bool DisabilityResourcesRequirments, List<Customer> Customers)
        {
            Movie movie = new Movie()
            {
                Id = MovieId,
                Name = MovieName,
                TotalSeats = TotalSeats,
                Ticket = Ticket,
                AgeRestriction = AgeRestriction,
                DisabilityResourcesRequirments = DisabilityResourcesRequirments,
                Customers = Customers
            };

            //for (int i = 0; i < Customers.Count; i++)
            //{
            //    if(!movie.Customers.Contains(Customers[i]))
            //    {
            //        movie.Customers.Add(Customers[i]);
            //    }
            //}

            iMovieRepository.UpdateMovie(movie);
            iMovieRepository.Save();
            iCustomerRepository.Save();
            CustomerContext.SaveChanges();

            return Redirect("Index");
        }

    }
}