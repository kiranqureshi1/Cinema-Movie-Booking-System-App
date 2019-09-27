using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using WebApplication5.Models;
using WebApplication5.Repositories.CustomersRepositories;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Text;

namespace WebApplication2.Controllers
{
    //[RoutePrefix("api/customers")]
    public class CustomerController : Controller
    {
        // private ICustomerRepository iCustomerRepository;
        ICustomerRepository iCustomerRepository = new CustomerRepository(new DataContext());

        //public CustomerController()
        //{
        //    this.iCustomerRepository = new CustomerRepository(new CustomerContext());
        //}


        //public CustomersController(CustomerRepository customerRepository)
        //{
        //    this.iCustomerRepository = customerRepository;
        //}

        //[Route("customers")]
        //[HttpGet]
        // GET: Customers
        public ActionResult Customer()
        {
            ViewBag.Message = "Customers detail is: ";
            var customers = iCustomerRepository.GetCustomers();
            //Console.WriteLine(customers);
            //return View("customer", (object)customers);
            ViewBag.Message = "Let Check!.";
            return View(customers);
            //return View();
            //return Content("Hey");
        }

        //[Route("CustomerForm")]
        //[HttpPost]
        public ActionResult CustomerForm(Customer Customer)
        {
            ViewBag.Message = "Customers form is going to display: ";
            ViewBag.Id = Customer.id;
            ViewBag.Name = Customer.Name;
            if (Customer.IsSubscribedToNewsletter != true)
                ViewBag.Addon = "Selected";
            else
                ViewBag.Addon = "Not Selected";
            return View();
        }

        public ActionResult Edit(int id)
        {
            Customer customer = new Customer();
            customer = iCustomerRepository.GetCustomerByID(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult CustomerForm(int CustomerId, string CustomerName, bool CustomerisSubscribedToNewsLetter)
        {
            Customer customer = new Customer();
            customer.id = CustomerId;
            customer.Name = CustomerName;
            customer.IsSubscribedToNewsletter = CustomerisSubscribedToNewsLetter;
            iCustomerRepository.InsertCustomer(customer);
            iCustomerRepository.Save();
            return RedirectToAction("Customer");
        }

        [HttpPost]
        public ActionResult Edit(int CustomerId, string CustomerName, bool CustomerisSubscribedToNewsLetter)
        {
            Customer customer = new Customer();
            customer.id = CustomerId;
            customer.Name = CustomerName;
            customer.IsSubscribedToNewsletter = CustomerisSubscribedToNewsLetter;
            iCustomerRepository.UpdateCustomer(customer);
            iCustomerRepository.Save();
            return RedirectToAction("Customer");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Customer customer = new Customer();
            customer = iCustomerRepository.GetCustomerByID(id);
            iCustomerRepository.DeleteCustomer(customer.id);
            iCustomerRepository.Save();
            return RedirectToAction("Customer");
        }

    }
}