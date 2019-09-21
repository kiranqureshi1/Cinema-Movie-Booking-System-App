using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.Repositories.MovieRepository
{
    public class MovieRepository : IMovieRepository, IDisposable
    {
        private DataContext context;

        public MovieRepository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return context.Movies.ToList();
        }
        public Movie GetMovieByID(int Id)
        {
            return context.Movies.Find(Id);
        }
        public void InsertMovie(Movie Movie)
        {
            context.Movies.Add(Movie);
        }
        public void DeleteMovie(int Id)
        {
            Movie Movie = context.Movies.Find(Id);
            context.Movies.Remove(Movie);
        }
        public void DeleteAllMovies()
        {
            context.Movies.RemoveRange(context.Movies);
            context.SaveChanges();
        }
        public void UpdateMovie(Movie Movie)
        {
            context.Entry(Movie).State = EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
