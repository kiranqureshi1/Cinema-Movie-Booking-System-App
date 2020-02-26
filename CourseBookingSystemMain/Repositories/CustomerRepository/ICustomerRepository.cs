using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using WebApplication2.Models;



namespace WebApplication2.Repositories.CustomersRepositories

{

    interface ICustomerRepository

    {

        IEnumerable<Customer> GetCustomers();

        Customer GetCustomerByID(int Id);

        //short GetMembershipTypeSignupFee(int id);

        void InsertCustomer(Customer customer);

        void DeleteCustomer(int Id);

        void DeleteAllCustomers();

        void UpdateCustomer(Customer customer);

        void Save();

    }

}