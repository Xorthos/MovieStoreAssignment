﻿using MovieShopDALC.Context;
using MovieShopDALC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDALC.Seeding
{
    public class DBInitializer : DropCreateDatabaseAlways<MovieShopContext>
    {
        public DBInitializer() : base()
        {
            //This should make the database initialise
            var  cont = new MovieShopContext();
            //cont.Database.Initialize(true);
            cont.Database.Delete(); // the proper initializing doesn't work, so we use this.

            Seed(new MovieShopContext());
        }

        protected override void Seed(MovieShopContext context)
        {
            Status stat1 = new Status() { Name = "Processing" };
            Status stat2 = new Status() { Name = "Shipped" };
            Status stat3 = new Status() { Name = "Completed" };
            context.Status.Add(stat1);
            context.Status.Add(stat2);
            context.Status.Add(stat3);

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

            Customer cust = new Customer() { Id = 1, Email = "bh@h.dk", FirstName = "Hej", MiddleName = "Nows", LastName = "DFNDF", Password = "ddddddd", StreetName = "hejs", StreetNumber = 5 };
            Customer cust2 = (new Customer() { Email = "mads@minimads.com", Password = "1234567", Id = 2, FirstName = "Mads", MiddleName = "Albæk", LastName = "Damsgaard-Sørensen", StreetName = "Skrænten", StreetNumber = 132 });

            context.Customers.Add(cust);
            context.Customers.Add(cust2);


            List<Orderline> orderlines = new List<Orderline>();
            orderlines.Add(context.Orderline.Add(new Orderline() { OrderId = 1, MovieId = hello.Id, Amount = 3, Price = hello.Price }));
            orderlines.Add(context.Orderline.Add(new Orderline() { OrderId = 1, MovieId = 6, Amount = 6, Price = 30 }));
            orderlines.Add(context.Orderline.Add(new Orderline() { OrderId = 1, MovieId = 17, Amount = 8, Price = 30 }));

            var ord = new Order(orderlines, "bools@gmail.com")
            {
                Id = 1,
                Status = stat1
            };

            context.Orders.Add(ord);

            List<Orderline> orderline2 = new List<Orderline>();
            orderline2.Add(context.Orderline.Add(new Orderline() { OrderId = 2, MovieId = 10, Amount = 5, Price = 150 }));
            var ord2 = new Order(orderline2, "bools@gmail.com")
            {
                Id = 2,
                Status = stat1
            };
            context.Orders.Add(ord2);

            List<Orderline> orderline3 = new List<Orderline>();
            orderline3.Add(context.Orderline.Add(new Orderline() { OrderId = 3, MovieId = 11, Amount = 1, Price = 300 }));
            var ord3 = new Order(orderline3, "bools@gmail.com")
            {
                Id = 3,
                Status = stat1
            };
            context.Orders.Add(ord3);

            // this is again because the original intend of the method doesn't work.
            context.SaveChanges();
            
            base.Seed(context);
        }
    }
}
