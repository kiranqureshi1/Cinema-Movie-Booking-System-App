using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication5.Models;


namespace WebApplication5.Repositories.CustomersRepositories
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private DataContext context;

        public CustomerRepository(DataContext context)
        {
            this.context = context;
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
        public void InsertMany()
        {
            context.Customers.AddRange(context.Customers);
        }
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