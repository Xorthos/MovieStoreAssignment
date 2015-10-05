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

        [Test]
        public void Test_Add_Orderline()
        {
            ShoppingCart cart = new ShoppingCart();
            Orderline OL = new Orderline();
            Movie mov = new Movie() { Id = 1, Title = "Avengers: Age Of Ultron", Genre = new Genre() { Id = 2, Name = "Action" }, Price = 150, Year = DateTime.Now, ImgUrl = "http://scaled.ysimag.es/movie/the-avengers-age-of-ultron", TrailerUrl = "https://www.youtube.com/watch?v=S2HIda5wSVU" };
            
            OL.Movie = mov;
            OL.Amount = 3;

            cart.Orderline.Add(OL);


            Assert.AreEqual(cart.Orderline.First(), OL, "The movies should be equal");
        }

    }
}
