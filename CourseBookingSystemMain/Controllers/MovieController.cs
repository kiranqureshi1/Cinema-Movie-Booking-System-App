using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie/Random
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer {Name = "Customer 1"},
        //        new Customer {Name = "Customer 2"}
        //    };

        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    return View(viewModel);

        //    // return Content("Hello world");
        //    // return HttpNotFound();
        //    //return new EmptyResult();
        //    // return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name" });
        //}

        //[Route("Movie/ByReleaseDate/{year}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}

        //public actionresult edit(int id)
        //{
        //    return content("id = " + id);
        //}

        ////movies
        //public actionresult index(int? pageindex, string sortby)
        //{
        //    if (!pageindex.hasvalue)
        //        pageindex = 1;
        //    if (string.isnullorwhitespace(sortby))
        //        sortby = "name";
        //    return content(string.format("pageindex={0}&sortby={1}", pageindex, sortby));
        //}


    }
}