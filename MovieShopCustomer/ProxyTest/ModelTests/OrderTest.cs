using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Core;
using NUnit.Framework;
using Proxy.DomainModels;

namespace ProxyTest.ModelTests
{
    [TestFixture]
    class OrderTest
    {
        /// <summary>
        /// Test getters and setters 
        /// </summary>
        [Test]
        public void Test_Getters_And_Setters()
        {
            List<Orderline> orderlines = new List<Orderline>();
            Orderline OL1= new Orderline() {OrderId = 2, MovieId = 6, Amount = 6, Price = 30};
            Orderline Ol2= new Orderline() {OrderId = 2, MovieId = 17, Amount = 8, Price = 30};
            orderlines.Add(Ol2);
            orderlines.Add(OL1);
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
            Status stat = new Status() { Id = 1, Name = "Shipped" };
            Order Ord = new Order() {Id=1,Orderlines = orderlines, Customer = cust, OrderDate = DateTime.Now.Date, Status = stat};

            Ord.Id = 1;
            Ord.Orderlines = orderlines;
            Ord.Customer = cust;
            Ord.OrderDate=DateTime.Now.Date;
            Ord.Status = stat;

            Assert.AreEqual(Ord.Id,1);
            Assert.AreEqual(Ord.Orderlines,orderlines);
            Assert.AreEqual(Ord.Customer,cust);
            Assert.AreEqual(Ord.OrderDate, DateTime.Now.Date);
            Assert.AreEqual(Ord.Status,stat);



        }


        /// <summary>
        /// Test constructor
        /// </summary>
        [Test]
        public void Test_Constructor()
        {
            List<Orderline> orderlines = new List<Orderline>();
            Orderline OL1 = new Orderline() { OrderId = 2, MovieId = 6, Amount = 6, Price = 30 };
            Orderline Ol2 = new Orderline() { OrderId = 2, MovieId = 17, Amount = 8, Price = 30 };
            orderlines.Add(Ol2);
            orderlines.Add(OL1);
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

            Order Ord = new Order(orderlines, cust);
            
            Assert.NotNull(Ord);
            Assert.NotNull(orderlines);
            Assert.NotNull(cust);
        }


    }
    }

