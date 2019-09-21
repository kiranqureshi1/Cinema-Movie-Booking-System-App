using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
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
        public byte Id { get; set; }
        public short SignupFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        //public ICollection<Movie> Movie { get; set; }
    }
}