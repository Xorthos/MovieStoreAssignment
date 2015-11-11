using System.Collections.Generic;
using System.Linq;
using MovieShopDALC.Context;
using MovieShopDALC.Models;
using MovieShopDALC.Repositories.Abstraction;

namespace MovieShopDALC.Repositories.Implementation
{
    public class MovieRepository : IRepository<Movie>
    {
        /// <summary>
        /// Add a movie
        /// </summary>
        public Movie Add(Movie movie)
        {
            using (var ctx = new MovieShopContext())
            {
                ctx.Genres.Attach(movie.Genre);
                Movie newMov = ctx.Movies.Add(movie);
                ctx.SaveChanges();
                return newMov;
            }
        }
        /// <summary>
        /// Get all movie
        /// </summary>
        public IEnumerable<Movie> GetAll()
        {
            try
            {
                using (var ctx = new MovieShopContext())
                {
                    return ctx.Movies.Include("Genre").ToList();
                }
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// returns the movie by Id
        /// </summary>
        /// <returns>the movie with the given Id</returns>
        public Movie Get(int id)
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Movies.Include("Genre").Where(c => c.Id == id).FirstOrDefault();
            }
        }
        /// <summary>
        /// Update a movie
        /// </summary>
        public Movie Update(Movie mov)
        {
            using (var ctx = new MovieShopContext())
            {
                /*var movie = ctx.Movies.Include("Genre").Where(c => c.Id == mov.Id).FirstOrDefault();
                movie.Genre.Id = mov.Genre.Id;
                movie.Price = mov.Price;
                movie.Title = mov.Title;
                movie.Year = mov.Year;

                ctx.SaveChanges();
                return movie;*/
                Movie movie = Get(mov.Id);
                movie.Genre = mov.Genre;
                movie.Price = mov.Price;
                movie.Title = mov.Title;
                movie.Year = mov.Year;
                movie.ImgUrl = mov.ImgUrl;
                movie.TrailerUrl = mov.TrailerUrl;
                ctx.SaveChanges();
                return movie;
            }
        }

        public bool ChangeActive(Movie item)
        {
            throw new System.NotImplementedException();
        }
    }
}
