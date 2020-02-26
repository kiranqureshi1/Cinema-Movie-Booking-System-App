using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Models
{
    public class CustomerContext : DbContext
    {

        public CustomerContext() : base("CustomerContext")
        {
        }

        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Movie> Movies { get; set; }


        //Configure a One-to-Many Relationship using Fluent API
        //Generally, you don't need to configure the one-to-many relationship in entity framework because one-to-many relationship conventions cover all combinations. However, you may configure relationships using Fluent API at one place to make it more maintainable.
        //below method is not necessary its just if you wanna alter table name or any information in many-many or One-Many relationships.
        //https://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>()
                        .HasMany<Movie>(s => s.Movies)
                        .WithMany(c => c.Customers)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("CustomerId");
                            cs.MapRightKey("MovieId");
                            cs.ToTable("CustomersMovies");
                        });

            modelBuilder.Entity<Customer>()
           .HasRequired<MembershipType>(s => s.CurrentMembershipType)
           .WithMany(g => g.Customers)
           .HasForeignKey<int>(s => s.CurrentMembershipTypeId);

        }
    }
}

//how to remove migrations from scrach to clean slate https://stackoverflow.com/questions/11679385/reset-entity-framework-migrations