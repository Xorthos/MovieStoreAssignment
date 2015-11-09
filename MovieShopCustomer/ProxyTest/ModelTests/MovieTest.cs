using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Proxy.DomainModels;

namespace ProxyTest.ModelTests
{
    [TestFixture]
    class MovieTest
    {  

        /// <summary>
        /// Test all the getters and setters
        /// </summary>
        [Test]
        public void Test_Getters_And_Setters() { 
        Movie mov = new Movie() { Id = 1, Title = "Avengers: Age Of Ultron", Genre = new Genre() { Id = 2, Name = "Action" }, Price = 150, Year = DateTime.Now.Date, ImgUrl = "http://scaled.ysimag.es/movie/the-avengers-age-of-ultron", TrailerUrl = "https://www.youtube.com/watch?v=S2HIda5wSVU" };
            mov.Id = 1;
            mov.Title = "Avengers: Age Of Ultron";
            mov.Genre.Id = 2;
            mov.Genre.Name = "Action";
            mov.Price = 150;
            mov.ImgUrl = "http://scaled.ysimag.es/movie/the-avengers-age-of-ultron";
            mov.TrailerUrl = "https://www.youtube.com/watch?v=S2HIda5wSVU";
            mov.Year= DateTime.Now.Date;

            Assert.AreEqual(mov.Id,1);
            Assert.AreEqual(mov.Title, "Avengers: Age Of Ultron");
            Assert.AreEqual(mov.Genre.Id,2);
            Assert.AreEqual(mov.Genre.Name,"Action");
            Assert.AreEqual(mov.Price,150);
            Assert.AreEqual(mov.ImgUrl,"http://scaled.ysimag.es/movie/the-avengers-age-of-ultron");
            Assert.AreEqual(mov.TrailerUrl, "https://www.youtube.com/watch?v=S2HIda5wSVU");
            Assert.AreEqual(mov.Year,DateTime.Now.Date);
        }
    }
}
