using Proxy.Context;
using Proxy.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Repositories
{
    public class MovieRepository
    {
        /// <summary>
        /// Add a movie
        /// </summary>
        public void Add(Movie movie)
        {
            using(var ctx = new MovieShopContext())
            {
                ctx.Movies.Add(movie);
                ctx.SaveChanges();
            }
        }
        /// <summary>
        /// Get all movie
        /// </summary>
        public List<Movie> GetAll()
        {
            try
            {
                using(var ctx = new MovieShopContext())
            {
                return ctx.Movies.Include("Genre").ToList();
            }
            }
            catch(Exception e)
            {
                return null;
            }
            
        }

        /// <summary>
        /// returns the movie by Id
        /// </summary>
        /// <returns>the movie with the given Id</returns>
        public Movie GetMovie(int id)
        {
            using(var ctx = new MovieShopContext()) { 
                return ctx.Movies.Include("Genre").Where(c => c.Id == id).FirstOrDefault();
            }
        }
        /// <summary>
        /// Delete a movie
        /// </summary>
        public void Delete(int id)
        {
            using (var ctx = new MovieShopContext())
            {
                var movie = ctx.Movies.Where(c => c.Id == id).FirstOrDefault();
                ctx.Movies.Remove(movie);
                ctx.SaveChanges();
            }
        }
        /// <summary>
        /// Update a movie
        /// </summary>
        public void UpdateMovie(Movie mov)
        {
            using (var ctx = new MovieShopContext())
            {
                var movie = ctx.Movies.Include("Genre").Where(c => c.Id == mov.Id).FirstOrDefault();
                movie.Genre = mov.Genre;
                movie.Price = mov.Price;
                movie.Title = mov.Title;
                movie.Year = mov.Year;

                ctx.SaveChanges();
            }
        }
    }
}
