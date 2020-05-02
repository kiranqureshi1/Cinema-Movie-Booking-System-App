using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    //public class CustomerContext : DbContext
    //{

    //    public CustomerContext() : base("CustomerContext")
    //    {
    //    }

    //    //public DbSet<MembershipType> MembershipTypes { get; set; }
    //    public DbSet<Customer> Customers { get; set; }
    //}


    public class Customer
    {
        public Customer()
        {
            this.Movies = new HashSet<Movie>();
        }
        public int id { get; set; }
        //[Required(ErrorMessage = "Name must be specified")]
        [StringLength(255)]
        public String Name { get; set; }
        public int Age { get; set; }
        public bool StudentStatus { get; set; }
        public float Bill { get; set; }
        public bool Disable { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        //[Required, ForeignKey(nameof(MembershipType))]
        public int CurrentMembershipTypeId { get; set; }
        public virtual MembershipType CurrentMembershipType { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }

        //public int[] SelectedTags { get; set; }
        //public SelectList Options { get; set; }

        //public void OnGet()
        //{
        //    Options = new SelectList(Movies, nameof(Movie.Id), nameof(Movie.Name));
        //}

        //public int MovieId { get; internal set; }

        //public MembershipType membershiptype { get; set; }
        //public byte membershiptypeid { get; set; }
    }
}

