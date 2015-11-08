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
        /// <summary>
        /// Testing all the getters and setters in the Orderline class
        /// </summary>
        [Test]
        public void TestGetters()
        {
            Movie mov = new Movie() { Id = 1, Title = "Avengers: Age Of Ultron", Genre = new Genre() { Id = 2, Name = "Action" }, Price = 150, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/the-avengers-age-of-ultron", TrailerUrl = "https://www.youtube.com/watch?v=S2HIda5wSVU" };

            Orderline OL = new Orderline();
            OL.MovieId = 1;
            OL.OrderId = 2;
            OL.Price = 150;
            OL.Id = 2;
            OL.Movie = mov;
            OL.Amount = 3;
            
            Assert.AreEqual(OL.Id, 2);
            Assert.AreEqual(OL.MovieId, 1);
            Assert.AreEqual(OL.OrderId, 2);
            Assert.AreEqual(OL.Price, 150);
            Assert.AreEqual(OL.Movie, mov, "The movies should be equal");
            Assert.AreEqual(OL.Amount, 3, "The amount should be equal");
        }

        /// <summary>
        /// Test the amount limit (Cannot be more than 10)
        /// </summary>
        [Test]
        public void Amount_Out_Of_Range()
        {
            Movie mov = new Movie() { Id = 1, Title = "Avengers: Age Of Ultron", Genre = new Genre() { Id = 2, Name = "Action" }, Price = 150, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/the-avengers-age-of-ultron", TrailerUrl = "https://www.youtube.com/watch?v=S2HIda5wSVU" };

            Orderline OL = new Orderline();

            OL.Movie = mov;

            Assert.Throws<IndexOutOfRangeException>(() => OL.Amount = 11);
        }

        /// <summary>
        ///Test the amount is less then 1
        /// </summary>
        [Test]
        public void Test_Amount_Is_Zero()
        {
            Movie mov = new Movie()
            {
                Id = 1,
                Title = "Avengers: Age Of Ultron",
                Genre = new Genre() { Id = 2, Name = "Action" },
                Price = 150,
                Year = DateTime.Now,
                ImgUrl = "http://scaled.ysimag.es/movie/the-avengers-age-of-ultron",
                TrailerUrl = "https://www.youtube.com/watch?v=S2HIda5wSVU"
            };

            Orderline OL = new Orderline();

            OL.Movie = mov;
            Assert.Throws<IndexOutOfRangeException>(() => OL.Amount = 0);
        }
    }
}
