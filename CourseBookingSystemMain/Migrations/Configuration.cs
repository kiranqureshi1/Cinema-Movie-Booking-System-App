namespace CourseBookingSystemMain.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication5.Models;

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

            IList<Customer> customers = new List<Customer>
            {
                new Customer { Name = "Jojo", IsSubscribedToNewsletter = true }
            };
            var customer1 = new Customer { id = 1, Name = "Jojo", IsSubscribedToNewsletter = true };
            var customer2 = new Customer { id = 2, Name = "Kira", IsSubscribedToNewsletter = false };
            
            context.Customers.AddRange(customers);
            base.Seed(context);

            //IList<MembershipType> MembershipTypes = new List<MembershipType>
            //{
            //    new MembershipType {Id = 1, DiscountRate = 22, DurationInMonths = 2, SignupFee = 23},
            //    new MembershipType {Id = 2, DiscountRate = 33, DurationInMonths = 3, SignupFee = 33},
            //    new MembershipType {Id = 3, DiscountRate = 44, DurationInMonths = 4, SignupFee = 43}
            //};
            var membership1 = new MembershipType { Id = 4, DiscountRate = 26, DurationInMonths = 2, SignupFee = 3 };
            var membership2 = new MembershipType { Id = 5, DiscountRate = 63, DurationInMonths = 5, SignupFee = 43 };
            //var membership3 = new MembershipType { Id = 6, DiscountRate = 34, DurationInMonths = 6, SignupFee = 63 };
            //var MembershipTypeRepository = new MembershipTypeRepository(context);
            //MembershipTypeRepository.InsertMembershipType(membership1);
            //MembershipTypeRepository.InsertMembershipType(membership2);
            //MembershipTypeRepository.InsertMembershipType(membership3);
            //MembershipTypeRepository.Save();

            //context.MembershipTypes.AddRange(MembershipTypes);
            //base.Seed(context);

            //context.Customers.Add(customer1);

            IList<Movie> Movies = new List<Movie>
            {
                new Movie {Name = "Shrek", CustomerId = customer1.id, MembershipTypeId = membership1.Id}
            };
            context.Movies.AddRange(Movies);
            base.Seed(context);

        }
    }
}
