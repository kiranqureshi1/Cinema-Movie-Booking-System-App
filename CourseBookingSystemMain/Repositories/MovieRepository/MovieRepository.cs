using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseBookingSystemMain.Repositories.MovieRepository
{
    public class MovieRepository : IMovieRepository, IDisposable
    {
        public void DeleteAllMovies()
        {
            context.Movies.RemoveRange(context.Movies);
            context.SaveChanges();
        }
    }
}