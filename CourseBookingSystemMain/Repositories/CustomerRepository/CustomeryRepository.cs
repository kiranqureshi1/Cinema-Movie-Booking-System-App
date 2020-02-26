using System;

using System.Collections.Generic;

using System.Data.Entity;

using System.Linq;

using System.Web;
using WebApplication2.Models;





namespace WebApplication2.Repositories.CustomersRepositories

{

    public class CustomerRepository : ICustomerRepository, IDisposable

    {

        private CustomerContext context;



        public CustomerRepository(CustomerContext context)

        {

            this.context = context;

        }

        //public short GetMembershipTypeSignupFee()
        //{
        //    var Customers = context.Customers.ToList();
        //    foreach (var customer in Customers)
        //    {
        //       return  customer.CurrentMembershipType.SignupFee;
        //    }

        //}

        public IEnumerable<Movie> GetMovies()

        {

            return context.Movies.ToList();

        }

        public IEnumerable<Customer> GetCustomers()

        {

            return context.Customers.ToList();

        }

        public Customer GetCustomerByID(int Id)

        {

            return context.Customers.Find(Id);

        }

        public void InsertCustomer(Customer customer)

        {

            context.Customers.Add(customer);

        }

        //public void InsertMany(IList<Movie> movies)

        //{

        //    context.Customers.AddRange(movies);

        //}

        public void DeleteCustomer(int Id)

        {

            Customer customer = context.Customers.Find(Id);

            context.Customers.Remove(customer);

        }

        public void DeleteAllCustomers()

        {

            context.Customers.RemoveRange(context.Customers);

            context.SaveChanges();

        }

        public void UpdateCustomer(Customer customer)

        {

            context.Entry(customer).State = EntityState.Modified;

        }

        public void Save()

        {

            context.SaveChanges();

        }



        private bool disposed = false;

        protected virtual void Dispose(bool disposing)

        {

            if (!this.disposed)

            {

                if (disposing)

                {

                    context.Dispose();

                }

            }

            this.disposed = true;

        }



        public void Dispose()

        {

            Dispose(true);

            GC.SuppressFinalize(this);

        }

    }

}