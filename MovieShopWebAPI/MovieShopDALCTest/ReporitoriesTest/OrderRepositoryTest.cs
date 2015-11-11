using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using MovieShopDALC.Models;
using MovieShopDALC.Repositories.Implementation;
using NUnit.Framework;

namespace MovieShopDALCTest.ReporitoriesTest
{   
    [TestFixture]
    public class OrderRepositoryTest
    {
        [Test]
        public void Test_Add_ListAll()
        {
            Order order = new Order();
            List<Orderline> orderlines = new List<Orderline>();
            Orderline OL1 = new Orderline() { OrderId = 2, MovieId = 6, Amount = 6, Price = 30 };
            Orderline Ol2 = new Orderline() { OrderId = 2, MovieId = 17, Amount = 8, Price = 30 };
            orderlines.Add(Ol2);
            orderlines.Add(OL1);
            CustomerRepository custrepo = new CustomerRepository();

            Customer cust = custrepo.Get(3);
            Status stat = new Status() { Id = 1, Name = "Shipped" };
            Order ord = new Order() { Id = 2, Orderlines = orderlines, Customer = cust, OrderDate = DateTime.Now.Date, Status = stat };

            ord.Id = 2;
            ord.Orderlines = orderlines;
            ord.Customer = cust;
            ord.OrderDate = DateTime.Now.Date;
            ord.Status = stat;

            OrderRepository ordrepo= new OrderRepository();
            int numberOfOrders = ordrepo.GetAll().Count();

            Order result1 = ordrepo.Add(ord);
            Assert.NotNull(result1);

            Order result2 = ordrepo.Get(result1.Id);
            Assert.NotNull(result2);
            Assert.AreEqual(result1.Id, result2.Id);

            int finalNumberOfOrders = ordrepo.GetAll().Count();
            Assert.AreEqual(numberOfOrders + 1, finalNumberOfOrders);
        }

        [Test]
        public void Test_Get()
        {
            OrderRepository ordrepo = new OrderRepository();
            Order ord = ordrepo.Get(1);
            Assert.NotNull(ord);
        }

        /// <summary>
        /// Test to get a list of all orders by a given customer
        /// </summary>
        [Test]
        public void Test_GetOrders_By_CustomerId()
        {
            OrderRepository ordrepo = new OrderRepository();
            int ordNumberByCustomer = ordrepo.GetOrders(2).Count();
            Assert.AreEqual(ordNumberByCustomer,2);


        }


    }
}
