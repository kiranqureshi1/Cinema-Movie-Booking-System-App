using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using WebApplication5.Models;
using WebApplication5.Repositories.CustomersRepositories;

namespace WebApplication5.Controllers
{
    //[RoutePrefix("api/customers")]
    public class CustomersController : Controller
    {
        private ICustomerRepository iCustomerRepository;

        public CustomersController()
        {
            this.iCustomerRepository = new CustomerRepository(new DataContext());
        }


        public CustomersController(CustomerRepository customerRepository)
        {
            this.iCustomerRepository = customerRepository;
        }

        [Route("customers")]
        [HttpGet]
        // GET: Customers
        public ActionResult Index()
        {
            var customers = iCustomerRepository.GetCustomers();
            //return View(customers);
            return Content("Hey");
        }


    }
}