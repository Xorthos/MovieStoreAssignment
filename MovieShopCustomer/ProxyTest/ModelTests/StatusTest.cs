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

class StatusTest
    {   
        /// <summary>
        /// Test all getters and setters
        /// </summary>
        [Test]
         public  void Test_Getters_And_Setters()
        {
            Status stat = new Status() {Id = 1, Name = "Shipped"};


            stat.Id = 1;
            stat.Name = "Shipped";

            Assert.AreEqual(stat.Id,1);
            Assert.AreEqual(stat.Name, "Shipped");
        }
    }
}
