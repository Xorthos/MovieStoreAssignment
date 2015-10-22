using MovieShopAdministration.Models;
using Proxy.DomainModels;
using Proxy.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShopAdministration.Controllers
{
    public class GenreController : Controller
    {
        Facade facade = new Facade();
        // GET: Genre
        #region Index Listing all genres
        [HttpGet]
        public ActionResult Index()
        {
            List<Genre> genres = facade.GetGenreRepository().GetAll();
            return View(new IndexViewModel() {Genres = genres });
        }
        #endregion

        #region Create one Genre
        [HttpGet]
        public ActionResult Create() {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Genre genre) {
             facade.GetGenreRepository().Add(genre);
            return Redirect("Index");
        }
        #endregion

        #region Edit one Genre
        [HttpGet]
        public ActionResult Edit(int genreId) {
            try {
                Genre theGenre = facade.GetGenreRepository().GetGenre(genreId);
                return View(theGenre);
            }
            catch
            {
                return Redirect("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            facade.GetGenreRepository().EditGenre(genre);
            return Redirect("Index");
        }

        #endregion

       
    }

}