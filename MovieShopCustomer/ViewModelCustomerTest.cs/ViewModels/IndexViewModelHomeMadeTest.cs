using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopCustomerAuth.Models;
using NUnit.Core;
using NUnit.Framework;

namespace ViewModelCustomerTest.cs.ViewModels
{
    [TestFixture]
    class IndexViewModelHomeMadeTest
    {
        /// <summary>
        /// Tests if the Genres in the view model is set on create.
        /// </summary>
        [Test]
        public void Test_genres_not_null()
        {
            IndexViewModelHomeMade model = new IndexViewModelHomeMade();

            Assert.NotNull(model.Genres);
        }

        /// <summary>
        /// Tests if the Movies in the view model is set on create.
        /// </summary>
        [Test]
        public void Test_movies_not_null()
        {
            IndexViewModelHomeMade model = new IndexViewModelHomeMade();
            
            Assert.NotNull(model.Movies);
        }

        [Test]
        public void Test_Movie_Search_Phrase_Lowercase()
        {
            FilterModel filters = new FilterModel() {SearchToken = "horns"};

            IndexViewModelHomeMade model = new IndexViewModelHomeMade(filters);

            Assert.AreEqual(model.Movies.Count, 2);
        }

        [Test]
        public void Test_Movie_Search_Phrase_Uppercase()
        {
            FilterModel filters = new FilterModel() { SearchToken = "Horns" };

            IndexViewModelHomeMade model = new IndexViewModelHomeMade(filters);

            Assert.AreEqual(model.Movies.Count, 2);
        }

        [Test]
        public void Test_Movie_Search_Genre_True()
        {
            FilterModel filters = new FilterModel() { GenreId = 2, UseGenre = true};

            IndexViewModelHomeMade model = new IndexViewModelHomeMade(filters);

            Assert.AreEqual(model.Movies.Count, 6);
        }

        [Test]
        public void Test_Movie_Search_Genre_False()
        {
            FilterModel filters = new FilterModel() { GenreId = 2, UseGenre = false };

            IndexViewModelHomeMade model = new IndexViewModelHomeMade(filters);

            Assert.AreEqual(model.Movies.Count, 18);
        }
    }
}
