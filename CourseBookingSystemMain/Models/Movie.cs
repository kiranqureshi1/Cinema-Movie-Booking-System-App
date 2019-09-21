using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
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
        public int Id { get; set; }
        public string Name { get; set; }

        [Required, ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        [Required, ForeignKey(nameof(MembershipType))]
        public byte MembershipTypeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual MembershipType MembershipType { get; set; }

    }
}