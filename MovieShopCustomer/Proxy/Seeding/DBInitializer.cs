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
            Genre g1 = context.Genres.Add(new Genre() { Id = 1, Name = "Comedy" });
            Genre g2 = context.Genres.Add(new Genre() { Id = 2, Name = "Action" });
            Genre g3 = context.Genres.Add(new Genre() { Id = 3, Name = "Drama" });
            Genre g4 = context.Genres.Add(new Genre() { Id = 4, Name = "Sci-Fi" });
            Genre g5 = context.Genres.Add(new Genre() { Id = 5, Name = "Horror" });

            var hello = new Movie() { Id = 1, Title = "Avengers: Age Of Ultron", Genre = g2, Price = 150, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/the-avengers-age-of-ultron", TrailerUrl = "https://www.youtube.com/watch?v=S2HIda5wSVU" };

            context.Movies.Add(hello);
            context.Movies.Add(new Movie() { Id = 2, Title = "The Voices", Genre = g1, Price = 300, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/voices-the", TrailerUrl = "https://www.youtube.com/watch?v=ARul3sUZfUM" });
            context.Movies.Add(new Movie() { Id = 3, Title = "The D Train", Genre = g1, Price = 30, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/d-train-the", TrailerUrl = "https://www.youtube.com/watch?v=w0qQkSuWOS8" });
            context.Movies.Add(new Movie() { Id = 4, Title = "Horns", Genre = g3, Price = 30, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/horns", TrailerUrl = "https://www.youtube.com/watch?v=w0qQkSuWOS8" });
            context.Movies.Add(new Movie() { Id = 5, Title = "Good Kill", Genre = g2, Price = 30, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/good-kill", TrailerUrl = "https://www.youtube.com/watch?v=w0qQkSuWOS8" });
            context.Movies.Add(new Movie() { Id = 6, Title = "Tomorrowland: A world beyond", Genre = g4, Price = 30, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/tomorrowland-a-world-beyond", TrailerUrl = "https://www.youtube.com/watch?v=w0qQkSuWOS8" });
            context.Movies.Add(new Movie() { Id = 7, Title = "Aloha", Genre = g3, Price = 30, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/aloha", TrailerUrl = "https://www.youtube.com/watch?v=w0qQkSuWOS8" });
            context.Movies.Add(new Movie() { Id = 8, Title = "It follows", Genre = g5, Price = 30, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/it-follows", TrailerUrl = "https://www.youtube.com/watch?v=w0qQkSuWOS8" });
            context.Movies.Add(new Movie() { Id = 9, Title = "Fast & Furious 7", Genre = g2, Price = 30, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/fast-furious-7", TrailerUrl = "https://www.youtube.com/watch?v=w0qQkSuWOS8" });
            context.Movies.Add(new Movie() { Id = 10, Title = "Avengers: Age Of Ultron", Genre = g2, Price = 150, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/the-avengers-age-of-ultron", TrailerUrl = "https://www.youtube.com/watch?v=S2HIda5wSVU" });
            context.Movies.Add(new Movie() { Id = 11, Title = "The Voices", Genre = g1, Price = 300, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/voices-the", TrailerUrl = "https://www.youtube.com/watch?v=ARul3sUZfUM" });
            context.Movies.Add(new Movie() { Id = 12, Title = "The D Train", Genre = g1, Price = 30, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/d-train-the", TrailerUrl = "https://www.youtube.com/watch?v=w0qQkSuWOS8" });
            context.Movies.Add(new Movie() { Id = 13, Title = "Horns", Genre = g3, Price = 30, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/horns", TrailerUrl = "https://www.youtube.com/watch?v=w0qQkSuWOS8" });
            context.Movies.Add(new Movie() { Id = 14, Title = "Good Kill", Genre = g2, Price = 30, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/good-kill", TrailerUrl = "https://www.youtube.com/watch?v=w0qQkSuWOS8" });
            context.Movies.Add(new Movie() { Id = 15, Title = "Tomorrowland: A world beyond", Genre = g4, Price = 30, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/tomorrowland-a-world-beyond", TrailerUrl = "https://www.youtube.com/watch?v=w0qQkSuWOS8" });
            context.Movies.Add(new Movie() { Id = 16, Title = "Aloha", Genre = g3, Price = 30, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/aloha", TrailerUrl = "https://www.youtube.com/watch?v=w0qQkSuWOS8" });
            context.Movies.Add(new Movie() { Id = 17, Title = "It follows", Genre = g5, Price = 30, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/it-follows", TrailerUrl = "https://www.youtube.com/watch?v=w0qQkSuWOS8" });
            context.Movies.Add(new Movie() { Id = 18, Title = "Fast & Furious 7", Genre = g2, Price = 30, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/fast-furious-7", TrailerUrl = "https://www.youtube.com/watch?v=w0qQkSuWOS8" });

            Customer cust = new Customer() { Id = 1, Email = "bh@h.dk", FirstName = "Hej", MiddleName = "Nows", LastName = "DFNDF", Password="ddddddd", StreetName= "hejs", StreetNumber = 5};
            context.Customers.Add(new Customer() { Email = "mads@minimads.com", Password = "1234567", Id = 1, FirstName = "Mads", MiddleName = "Albæk", LastName = "Damsgaard-Sørensen", StreetName = "Skrænten", StreetNumber = 132 });

            context.Customers.Add(cust);


            List<Orderline> orderlines = new List<Orderline>();
            orderlines.Add(context.Orderline.Add(new Orderline() { OrderId = 1, MovieId = hello.Id, Amount = 3 }));
            orderlines.Add(context.Orderline.Add(new Orderline() { OrderId = 1, MovieId = 6, Amount = 6 }));
            orderlines.Add(context.Orderline.Add(new Orderline() { OrderId = 1, MovieId = 17, Amount = 8 }));

            var ord = new Order(orderlines, cust)
            {
                Id = 1
            };

            context.Orders.Add(ord);

            base.Seed(context);
        }
    }
}
