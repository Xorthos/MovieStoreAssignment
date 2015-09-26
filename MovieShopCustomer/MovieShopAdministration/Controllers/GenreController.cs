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
        public ActionResult Index()
        {
           // List<Genre> genres = facade.GetGenreRepository().getAll();
            return View();
        }
        [HttpGet]
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Genre genre) {
            // facade.GetGenreRepository().AddGenre(genre);
            return Redirect("Index");
        }
        [HttpGet]
        public ActionResult Edit(int genreId) {
           // Genre = facade.GetGenreRepository().FindGenre(genreId);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
          //  facade.GetGenreRepository().Update(genre);
            return Redirect("Index");
        }

        //If the movie is already has this genre what the user want to delete ?
        /**
        TODO
        */

        [HttpGet]
        public ActionResult Delete(int genreId) {
            return View(genreId);
        }
        [HttpPost]

        public ActionResult DeleteAccepted(int genreId) {
            //facade.GetGenreRepository().DeleteGenre(genreId);
            return Redirect("Index");
        }
    }
  
}