using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.ViewModel
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public MembershipType MembershipType { get; set; }
        public Movie Movie { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public int[] MovieId { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<SelectListItem> AllMovies { get; set; }

        private List<int> selectedMovies;
        public List<int> SelectedMovies
        {
            get
            {
                if (selectedMovies == null)
                {
                    selectedMovies = Customer.Movies.Select(m => m.Id).ToList();
                }
                return selectedMovies;
            }
            set { selectedMovies = value; }
        }
    }
}