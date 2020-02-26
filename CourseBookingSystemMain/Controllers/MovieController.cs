using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Movie()
        {
            var Movies = iMovieRepository.GetMovies();
            //var movies = CustomerContext.Movies.Include(s => s.Customers);
            //var customers = CustomerContext.Customers.Include(c => c.Movies);
            //var Movies = movies.ToList();
            return View(Movies);
        }

        public ActionResult MovieForm()
        {
            ViewBag.Message = "Customers form is going to display: ";
            CustomerViewModel customers = new CustomerViewModel()
            {
                Customers = iCustomerRepository.GetCustomers()
            };
            //var customers = iCustomerRepository.GetCustomers();
            return View(customers);
        }

        [HttpPost]

        public ActionResult MovieForm(int MovieId, string MovieName, Customer Customer)

        {

            Movie movie = new Movie();
            movie.Id = MovieId;
            movie.Name = MovieName;
            movie.Customers.Add(Customer);

            iMovieRepository.InsertMovie(movie);
            iMovieRepository.Save();

            return RedirectToAction("Movie");

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
        public ActionResult Edit(int MovieId, string MovieName, IList<Customer> customers)
        {
            Movie movie = new Movie();
            movie.Id = MovieId;
            movie.Name = MovieName;
            movie.Customers = customers;

            iMovieRepository.UpdateMovie(movie);
            iMovieRepository.Save();
            iCustomerRepository.Save();
            CustomerContext.SaveChanges();

            return Redirect("Movie");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Movie movie = new Movie();
            movie = iMovieRepository.GetMovieByID(id);
            iMovieRepository.DeleteMovie(movie.Id);
            iMovieRepository.Save();
            return RedirectToAction("Movie");
        }
    }
}