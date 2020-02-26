namespace WebApplication2.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication2.Models;
    using WebApplication2.Repositories.CustomersRepositories;
    using WebApplication2.Repositories.MovieRepository;
    using WebApplication2.Repositories.MembershipTypeRepository;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication2.Models.CustomerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication2.Models.CustomerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var MembershipTypeRepository = new MembershipTypeRepository(context);

            MembershipTypeRepository.DeleteAllMembershipTypes();

            var customerRepository = new CustomerRepository(context);

            customerRepository.DeleteAllCustomers();

            var movieRepository = new MovieRepository(context);

            movieRepository.DeleteAllMovies();





            IList<Customer> customers = new List<Customer>

            {

                new Customer {id = 1, Name = "Jojo", IsSubscribedToNewsletter = true },

                new Customer { id = 2, Name = "Kira", IsSubscribedToNewsletter = false }

            };

            //CustomerRepository.InsertMany();

            //base.Seed(context);

            //context.Customers.AddRange(customers);

            //base.Seed(context);



            IList<MembershipType> MembershipTypes = new List<MembershipType>

            {

                new MembershipType {Id = 1, DiscountRate = 22, DurationInMonths = 2, SignupFee = 23},

                new MembershipType {Id = 2, DiscountRate = 33, DurationInMonths = 3, SignupFee = 33},

                new MembershipType {Id = 3, DiscountRate = 44, DurationInMonths = 4, SignupFee = 43}

            };

            var membership1 = new MembershipType { Id = 8, DiscountRate = 26, DurationInMonths = 2, SignupFee = 3 };

            var membership2 = new MembershipType { Id = 6, DiscountRate = 63, DurationInMonths = 5, SignupFee = 43 };

            var membership3 = new MembershipType { Id = 7, DiscountRate = 34, DurationInMonths = 6, SignupFee = 63 };

            MembershipTypeRepository.InsertMembershipType(membership1);

            MembershipTypeRepository.InsertMembershipType(membership2);

            MembershipTypeRepository.InsertMembershipType(membership3);

            MembershipTypeRepository.Save();



            context.MembershipTypes.AddRange(MembershipTypes);

            base.Seed(context);

            //context.MembershipTypes.Add(membership1);

            //context.MembershipTypes.Add(membership3);

            //context.Customers.Add(customer1);


            var customer1 = new Customer { id = 3, Name = "Jojo", IsSubscribedToNewsletter = true, CurrentMembershipType = membership1, CurrentMembershipTypeId = membership1.Id };

            var customer2 = new Customer { id = 4, Name = "Kira", IsSubscribedToNewsletter = false, CurrentMembershipType = membership2, CurrentMembershipTypeId = membership2.Id };

            customerRepository.InsertCustomer(customer1);
            customerRepository.InsertCustomer(customer2);

            customerRepository.Save();



            IList<Movie> Movies = new List<Movie>

            {

                new Movie {Id = 1, Name = "Shrek"}

            };

            var movie1 = new Movie { Id = 4, Name = "Shrek" };
            var movie2 = new Movie { Id = 2, Name = "Drakula" };
            var movie3 = new Movie { Id = 3, Name = "Ice-Age" };

            movieRepository.InsertMovie(movie1);
            movieRepository.InsertMovie(movie2);
            movieRepository.InsertMovie(movie3);
            movieRepository.Save();

            // movie1.Customers.Add(customer1);5
            movie1.Customers.Add(customer2);
            movie2.Customers.Add(customer1);
            movie3.Customers.Add(customer2);
            movie3.Customers.Add(customer1);

            customer1.Movies.Add(movie1);
            customer2.Movies.Add(movie3);

            context.Movies.AddRange(Movies);

            base.Seed(context);
        }
    }
}
