using System;
using System.Linq;
using NUnit.Framework;
using MovieShopDALC.Models;
using MovieShopDALC.Repositories.Implementation;

namespace MovieShopDALCTest.ReporitoriesTest
{
    [TestFixture]
    public class CustomerRepositoryTest
    {   
        /// <summary>
        /// This method is testing if I add a customer the list of all customer is increasing by 1
        /// </summary>
        [Test]
        public void Test_Add_ListAll()
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

            CustomerRepository repository = new CustomerRepository();

            int numberOfCustomers = repository.GetAll().Count();

            Customer result = repository.Add(cust);
            Assert.NotNull(result);

            int finalNumberOfCustomers = repository.GetAll().Count();

            Assert.AreEqual(numberOfCustomers + 1, finalNumberOfCustomers);
        }

        [Test]
        public void Test_Update()
        {
            CustomerRepository repository = new CustomerRepository();

            Customer cust = repository.Get(1);
            Assert.NotNull(cust);

            cust.FirstName = "Borso";
            cust.MiddleName = "Green";
            cust.LastName = "Varga";
            cust.StreetName = "Blue";
            cust.StreetNumber = 185;
            cust.Email = "dadf@gad.com";
            cust.Password = "001100";
            Customer result = repository.Update(cust);

            Assert.AreEqual(result.FirstName, "Borso");
            Assert.AreEqual(result.MiddleName, "Green");
            Assert.AreEqual(result.LastName,"Varga");
            Assert.AreEqual(result.StreetName,"Blue");
            Assert.AreEqual(result.StreetNumber,185);
            Assert.AreEqual(result.Email, "dadf@gad.com");
            Assert.AreEqual(result.Password, "001100");
        }

        [Test]
        public void Test_Get_By_Email()
        {
            CustomerRepository repository = new CustomerRepository();

            Customer cust = repository.Get("mads@minimads.com");
            Assert.NotNull(cust);
        }
    }
}
