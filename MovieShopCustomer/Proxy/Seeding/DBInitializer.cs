using Proxy.Context;
using Proxy.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Seeding
{
    class DBInitializer : DropCreateDatabaseAlways<MovieShopContext>
    {
        protected override void Seed(MovieShopContext context)
        {
            Genre g1 = context.Genres.Add(new Genre() { Id = 1, Name = "HorseSeed" });
            Genre g2 = context.Genres.Add(new Genre() { Id = 2, Name = "Cheese" });

            context.Movies.Add(new Movie() { Id = 1, Title = "Bools", Genre = g1, Price = 150, Year = DateTime.Now, ImgUrl = "http://twilightseriestheories.com/wp-content/uploads/2010/03/EclipseMovieCover.jpg", TrailerUrl = "https://www.youtube.com/watch?v=S2HIda5wSVU" });
            context.Movies.Add(new Movie() { Id = 2, Title = "Bools'N'Balls", Genre = g1, Price = 300, Year = DateTime.Now, ImgUrl = "http://www.bellanaija.com/wp-content/uploads/2009/10/Guilty-Pleasures-1.jpg", TrailerUrl = "https://www.youtube.com/watch?v=ARul3sUZfUM" });
            context.Movies.Add(new Movie() { Id = 3, Title = "RomanticStuff", Genre = g2, Price = 30, Year = DateTime.Now, ImgUrl = "https://jacobboombar.files.wordpress.com/2014/03/oblivion-dvd-cover-55.jpg", TrailerUrl = "https://www.youtube.com/watch?v=w0qQkSuWOS8" });

            base.Seed(context);
        }
    }
}
