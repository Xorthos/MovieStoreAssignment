using Proxy.Context;
using Proxy.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Repositories
{
    public class GenreRepository
    {
        /// <summary>
        /// Adds a genre to the database
        /// </summary>
        /// <param name="gen">the genre to be added</param>
        public void Add(Genre gen)
        {
            using (var ctx = new MovieShopContext())
            {
                ctx.Genres.Add(gen);
                ctx.SaveChanges();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>a list containing all genres</returns>
        public List<Genre> GetAll()
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Genres.ToList();
            }
        }

        public void EditGenre(Genre gen)
        {
            using (var ctx = new MovieShopContext())
            {
                var genre = ctx.Genres.Where(c => c.Id == gen.Id).FirstOrDefault();

            }
        }

        public Genre GetGenre(int id)
        {
            using(var ctx = new MovieShopContext()) { 
                return ctx.Genres.Where(c => c.Id == id).FirstOrDefault();
            }
        }
    }
}
