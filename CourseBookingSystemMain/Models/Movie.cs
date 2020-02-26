using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    //public class MovieContext : DbContext
    //{
    //    public MovieContext() : base("CustomerContext")
    //    {
    //    }
    //    public DbSet<Movie> Movies { get; set; }
    //}
    public class Movie
    {
        public Movie()
        {
            this.Customers = new HashSet<Customer>();
        }
        public int Id { get; set; }
        //[Required(ErrorMessage = "Name must be specified")]
        public string Name { get; set; }

        //[Required, ForeignKey(nameof(Customer))]
        //public int CustomerId { get; set; }

        //[Required, ForeignKey(nameof(MembershipType))]
        //public byte MembershipTypeId { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        //public int CustomerId { get; internal set; }
    }
}