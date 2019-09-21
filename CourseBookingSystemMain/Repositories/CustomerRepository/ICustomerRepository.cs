using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Repositories.CustomersRepositories
{
    interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerByID(int Id);
        void InsertCustomer(Customer customer);
        void DeleteCustomer(int Id);
        void UpdateCustomer(Customer customer);
        void Save();
    }
}
