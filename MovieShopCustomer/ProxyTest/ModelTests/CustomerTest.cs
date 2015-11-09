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
    internal class CustomerTest
    {
        /// <summary>
        /// Test all the getters and setters
        /// </summary>
        [Test]
        public void Test_Getters_And_Setters()
        {
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

            cust.Id = 1;
            cust.FirstName = "Someone";
            cust.MiddleName = "Else";
            cust.LastName = "Name";
            cust.Email = "SomeWhere@else.dk";
            cust.StreetName = "Bla Vej";
            cust.StreetNumber = 1;
            cust.Password = "111100";

            Assert.AreEqual(cust.Id, 1);
            Assert.AreEqual(cust.FirstName, "Someone");
            Assert.AreEqual(cust.MiddleName, "Else");
            Assert.AreEqual(cust.LastName, "Name");
            Assert.AreEqual(cust.Email, "SomeWhere@else.dk");
            Assert.AreEqual(cust.StreetName, "Bla Vej");
            Assert.AreEqual(cust.StreetNumber, 1);
            Assert.AreEqual(cust.Password, "111100");
            Assert.AreEqual(cust.ToString(), "Someone Name");
        }

        [Test]
        public void Test_ModelBinding()
        {
            Customer cust = new Customer()
            {
                Id = 1,
                FirstName = "Someone",
                MiddleName = "Else",
                LastName = "Name",
                Email = "SomeWhere@else.dk",
                StreetName = "Bla Vej",
                StreetNumber = -1,
                Password = "111100"
            };
            cust.StreetNumber = -1;
            Assert.AreEqual(cust.StreetNumber, -1);
        }
    }
}

