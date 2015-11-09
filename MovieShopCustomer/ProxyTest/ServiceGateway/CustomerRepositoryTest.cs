using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Core;
using NUnit.Framework;
using System.Threading.Tasks;
using Proxy.DomainModels;
using Proxy.ServiceGateway;

namespace ProxyTest.ServiceGateway
{   
     [TestFixture]
    class CustomerRepositoryTest
    {

         [Test]

         public void Test_Add()
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

            repository.Add(cust);

         }
    }
}
