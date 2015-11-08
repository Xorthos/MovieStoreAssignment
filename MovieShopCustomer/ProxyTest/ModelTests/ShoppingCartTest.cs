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
    public class ShoppingCartTest
    {
        [Test]
        public void Test_Cart_Setup()
        {
            ShoppingCart cart = new ShoppingCart();

            Assert.NotNull(cart.Orderline, "Should be empty, not null");
        }

        /// <summary>
        /// Test getters and setters
        /// </summary>
        [Test]
        public void Test_Add_ShoppingCart()
        {
            ShoppingCart cart = new ShoppingCart();
            Orderline OL = new Orderline();
            Movie mov = new Movie() { Id = 1, Title = "Avengers: Age Of Ultron", Genre = new Genre() { Id = 2, Name = "Action" }, Price = 150, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/the-avengers-age-of-ultron", TrailerUrl = "https://www.youtube.com/watch?v=S2HIda5wSVU" };
            Customer cust = new Customer()
            {
                Id = 1,
                FirstName = "Someone",
                MiddleName = "Else",
                LastName = "Name",
                Email = "SomeWhere@else.dk",
                StreetName = "Bla Vej",
                StreetNumber = 1,
                Password = "111100"
            };

            OL.Movie = mov;
            OL.Amount = 3;
            cust.Id = 1;

            cart.CustomerId = 1;
            cart.Orderline.Add(OL);

            Assert.AreEqual(cart.CustomerId,1);
            Assert.AreEqual(cust.Id, 1);
            Assert.AreEqual(cart.Orderline.First(), OL, "The movies should be equal");
        }

    }
}
