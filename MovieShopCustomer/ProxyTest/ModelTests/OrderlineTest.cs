using NUnit.Framework;
using Proxy.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyTest.ModelTests
{
    [TestFixture]
    class OrderlineTest
    {
        [Test]
        public void Is_Movie_Valid_Test()
        {
            Movie mov = new Movie() { Id = 1, Title = "Avengers: Age Of Ultron", Genre = new Genre() { Id = 2, Name = "Action" }, Price = 150, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/the-avengers-age-of-ultron", TrailerUrl = "https://www.youtube.com/watch?v=S2HIda5wSVU" };

            Orderline OL = new Orderline();

            OL.Movie = mov;
            OL.Amount = 3;

            Assert.AreEqual(OL.Movie, mov, "The movies should be equal");
            Assert.AreEqual(OL.Amount, 3, "The amount should be equal");
        }

        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Amount_Out_Of_Range()
        {
            Movie mov = new Movie() { Id = 1, Title = "Avengers: Age Of Ultron", Genre = new Genre() { Id = 2, Name = "Action" }, Price = 150, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/the-avengers-age-of-ultron", TrailerUrl = "https://www.youtube.com/watch?v=S2HIda5wSVU" };

            Orderline OL = new Orderline();

            OL.Movie = mov;
            OL.Amount = 11;
        }
    }
}
