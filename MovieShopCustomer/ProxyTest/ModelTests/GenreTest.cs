using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Proxy.DomainModels;

namespace ProxyTest.ModelTests
{    
    [TestFixture]
    class GenreTest
    {   
        /// <summary>
        /// Test getters and setters 
        /// </summary>
        [Test]
        public  void Test_Getters_And_Setters()
        {
            Genre genre = new Genre() {Id = 1, Name ="Horror"};

            genre.Id = 1;
            genre.Name ="Horror";

            Assert.AreEqual(genre.Id, 1);
            Assert.AreEqual(genre.Name,"Horror");
        }
        }
    }

