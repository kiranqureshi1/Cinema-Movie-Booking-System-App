using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    //public class CustomerContext : DbContext
    //{

    //    public CustomerContext() : base("CustomerContext")
    //    {
    //    }

    //    public DbSet<MembershipType> MembershipTypes { get; set; }
    //    public DbSet<Customer> Customers { get; set; }
    //}


    public class Customer
    {
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public String Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public ICollection<Movie> Movie { get; set; }

        //public MembershipType membershiptype { get; set; }
        //public byte membershiptypeid { get; set; }
    }
}