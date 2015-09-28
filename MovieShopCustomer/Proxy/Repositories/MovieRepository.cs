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
        /// 
        /// </summary>
        /// <param name="movie"></param>
        public void Add(Movie movie)
        {
            using(var ctx = new MovieShopContext())
            {
                ctx.Movies.Add(movie);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Movie> GetAllMovies()
        {
            using(var ctx = new MovieShopContext())
            {
                return ctx.Movies.ToList();
            }
        }

        /// <summary>
        /// returns the movie wih the given Id
        /// </summary>
        /// <param name="id">the id</param>
        /// <returns>the movie with the given Id</returns>
        public Movie GetMovie(int id)
        {
            using(var ctx = new MovieShopContext()) { 
                return ctx.Movies.Include("Genre").Where(c => c.ID == id).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new MovieShopContext())
            {
                var movie = ctx.Movies.Where(c => c.ID == id).FirstOrDefault();
                ctx.Movies.Remove(movie);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void ChangeMovie(Movie mov)
        {
            using (var ctx = new MovieShopContext())
            {
                var movie = ctx.Movies.Include("Genre").Where(c => c.ID == mov.ID).FirstOrDefault();
                movie.Genre = mov.Genre;
                movie.price = mov.price;
                movie.Title = mov.Title;
                movie.Year = mov.Year;

                ctx.SaveChanges();
            }
        }
    }
}
