using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDALC.Models;
using MovieShopDALC.Repositories.Implementation;
using NUnit.Framework;

namespace MovieShopDALCTest.ReporitoriesTest
{
    [TestFixture]
   public class GenreRepositoryTest
    {
        [Test]
        public void Test_Add_ListAll()
        {
            Genre genre = new Genre()
            {
                Id = 1,
                Name = "Anime",
            };
            GenreRepository repository = new GenreRepository();

            int numberOfGenres = repository.GetAll().Count();

            Genre result = repository.Add(genre);
            Assert.NotNull(result);

            int finalNumberOfGenres = repository.GetAll().Count();

            Assert.AreEqual(numberOfGenres + 1, finalNumberOfGenres);

        }

        [Test]
        public void Test_Update_And_Get()
        {
            GenreRepository repository = new GenreRepository();

            Genre genre = repository.Get(1);
            Assert.NotNull(genre);

            genre.Name = "Krimi";
            Genre result = repository.Update(genre);
            Assert.AreEqual(result.Name, "Krimi");
        }

    }
}
