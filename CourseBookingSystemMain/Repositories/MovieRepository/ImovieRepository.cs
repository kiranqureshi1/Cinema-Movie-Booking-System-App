using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace CourseBookingSystemMain.Repositories.MovieRepository
{
    interface IMovieRepository
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovieByID(int Id);
        void InsertMovie(Movie Movie);
        void DeleteMovie(int Id);
        void DeleteAllMovies();
        void UpdateMovie(Movie Movie);
        void Save();
    }
}