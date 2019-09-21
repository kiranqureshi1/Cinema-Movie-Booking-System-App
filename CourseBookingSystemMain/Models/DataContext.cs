using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {
        }

        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Movie> Movies { get; set; }
    }
}