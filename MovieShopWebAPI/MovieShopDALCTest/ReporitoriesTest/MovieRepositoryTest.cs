using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDALC.Models;
using MovieShopDALC.Repositories.Implementation;
using NUnit.Framework;

namespace MovieShopDALCTest.ReporitoriesTest
{    
    [TestFixture]
     public class MovieRepositoryTest
    { 
        /// <summary>
        /// This method is testing if I add a customer the list of all customer is increasing by 1
        /// </summary>
        [Test]
        public void Test_Add_ListAll()
        {
            Movie mov = new Movie() { Id = 20, Title = "Avengers: Age Of Ultron", Genre = new Genre() { Id = 2, Name = "Action" }, Price = 150, Year = DateTime.Now.Date, ImgUrl = "http://scaled.ysimag.es/movie/the-avengers-age-of-ultron", TrailerUrl = "https://www.youtube.com/watch?v=S2HIda5wSVU" };
            mov.Id = 1;
            mov.Title = "Alice in Wonderland";
            mov.Genre.Id = 2;
            mov.Genre.Name = "Action";
            mov.Price = 150;
            mov.ImgUrl = "http://scaled.ysimag.es/movie/the-avengers-age-of-ultron";
            mov.TrailerUrl = "https://www.youtube.com/watch?v=S2HIda5wSVU";
            mov.Year = DateTime.Now.Date;

            MovieRepository repository = new MovieRepository();

            int numberOfMovies = repository.GetAll().Count();

            Movie result = repository.Add(mov);
            Assert.NotNull(result);

            int finalNumberOfMovies = repository.GetAll().Count();

            Assert.AreEqual(numberOfMovies + 1, finalNumberOfMovies);
        }

        [Test]
        public void Test_Update()
        {
            MovieRepository repository = new MovieRepository();
            GenreRepository gr = new GenreRepository();

            Movie mov = repository.Get(1);
            Assert.NotNull(mov);

            mov.Title = "Red";
            mov.Genre = gr.Get(3);
            mov.Price = 20;
            mov.ImgUrl = "http://scaled.ysimag.es/movie/it-follows";
            mov.TrailerUrl = "https://www.youtube.com/watch?v=w0qQkSuWOS8";
            mov.Year = DateTime.Today.Date;
            Movie result = repository.Update(mov);

            Assert.AreEqual(result.Title,"Red");
            Assert.AreEqual(result.Genre.Id, 3);
            Assert.AreEqual(result.Price, 20);
            Assert.AreEqual(result.ImgUrl, "http://scaled.ysimag.es/movie/it-follows");
            Assert.AreEqual(result.TrailerUrl, "https://www.youtube.com/watch?v=w0qQkSuWOS8");
            Assert.AreEqual(result.Year, DateTime.Today.Date);
        }
    }
}
