namespace CourseBookingSystemMain.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication5.Models;
    using WebApplication5.Repositories.CustomersRepositories;
    //using WebApplication5.Repositories.MovieRepository;
    using WebApplication5.Repositories.MembershipTypeRepository;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication5.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication5.Models.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var MembershipTypeRepository = new MembershipTypeRepository(context);
            MembershipTypeRepository.DeleteAllMembershipTypes();
            var CustomerRepository = new CustomerRepository(context);
            CustomerRepository.DeleteAllCustomers();


            IList<Customer> customers = new List<Customer>
            {
                new Customer { Name = "Jojo", IsSubscribedToNewsletter = true },
                new Customer { Name = "Kira", IsSubscribedToNewsletter = false }
            };
            CustomerRepository.InsertMany();
            base.Seed(context);
            var customer1 = new Customer {Name = "Jojo", IsSubscribedToNewsletter = true };
            //var customer2 = new Customer {Name = "Kira", IsSubscribedToNewsletter = false };
            
            //context.Customers.AddRange(customers);
            //base.Seed(context);

            //IList<MembershipType> MembershipTypes = new List<MembershipType>
            //{
            //    new MembershipType {DiscountRate = 22, DurationInMonths = 2, SignupFee = 23},
            //    new MembershipType {DiscountRate = 33, DurationInMonths = 3, SignupFee = 33},
            //    new MembershipType {DiscountRate = 44, DurationInMonths = 4, SignupFee = 43}
            //};
            var membership1 = new MembershipType {Id = 5, DiscountRate = 26, DurationInMonths = 2, SignupFee = 3 };
            var membership2 = new MembershipType {Id = 6, DiscountRate = 63, DurationInMonths = 5, SignupFee = 43 };
            var membership3 = new MembershipType { Id = 7, DiscountRate = 34, DurationInMonths = 6, SignupFee = 63 };
            MembershipTypeRepository.InsertMembershipType(membership1);
            MembershipTypeRepository.InsertMembershipType(membership2);
            MembershipTypeRepository.InsertMembershipType(membership3);
            MembershipTypeRepository.Save();

            //context.MembershipTypes.AddRange(MembershipTypes);
            //base.Seed(context);
            context.MembershipTypes.Add(membership1);
            context.MembershipTypes.Add(membership2);
            //context.Customers.Add(customer1);

            IList<Movie> Movies = new List<Movie>
            {
                new Movie {Id = 1, Name = "Shrek", CustomerId = customer1.id, MembershipTypeId = membership2.Id}
            };
            context.Movies.AddRange(Movies);
            base.Seed(context);

        }
    }
}
