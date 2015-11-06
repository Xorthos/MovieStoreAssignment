using System.Collections.Generic;
using System.Linq;
using MovieShopDALC.Context;
using MovieShopDALC.Models;
using MovieShopDALC.Repositories.Abstraction;

namespace MovieShopDALC.Repositories.Implementation
{
    public class GenreRepository : IRepository<Genre>
    {
        /// <summary>
        /// Adds a genre to the database and returns it
        /// </summary>
        /// <param name="gen">the genre to be added</param>
        public Genre Add(Genre gen)
        {
            using (var ctx = new MovieShopContext())
            {
                Genre newGen = ctx.Genres.Add(gen);
                ctx.SaveChanges();
                return newGen;
            }
        }

        /// <summary>
        /// Get all genre
        /// </summary>
        /// <returns>a list containing all genres</returns>
        public IEnumerable<Genre> GetAll()
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Genres.ToList();
            }
        }

        /// <summary>
        ///Edit one genre 
        /// </summary>
        public Genre Update(Genre gen)
        {
            using (var ctx = new MovieShopContext())
            {
                var genre = ctx.Genres.Where(c => c.Id == gen.Id).FirstOrDefault();
                genre.Name = gen.Name;
                ctx.SaveChanges();
                return genre;
            }
        }

        public bool ChangeActive(Genre item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Get one genre by id
        /// </summary>
        public Genre Get(int id)
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Genres.Where(c => c.Id == id).FirstOrDefault();
            }
        }
    }
}
