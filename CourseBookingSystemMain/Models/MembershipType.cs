using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    //public class MembershipTypeContext : DbContext
    //{
    //     public MembershipTypeContext() : base("CustomerContext")
    //    {
    //    }
    //    public DbSet<MembershipType> MembershipTypes { get; set; }
    //}

    public class MembershipType
    {
        public int Id { get; set; }
        public short SignupFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }

        // public virtual ICollection<Movie> Movie { get; set; }
    }
}