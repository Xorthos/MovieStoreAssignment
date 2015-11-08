using MovieShopAdministrationAuth.Models;
using Proxy.DomainModels;
using Proxy.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proxy.Facade.abstraction;
using Proxy.Facade.Implementation;

namespace MovieShopAdministrationAuth.Controllers
{
    public class GenreController : Controller
    {
        IFacade facade = new Facade();
        // GET: Genre
        #region Index Listing all genres
        [HttpGet]
        public ActionResult Index()
        {
            List<Genre> genres = (List<Genre>) facade.GetGenreGateway().GetAll();
            return View(new IndexViewModelHomeMade() {Genres = genres });
        }
        #endregion

        #region Create one Genre
        [HttpGet]
        public ActionResult Create() {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Genre genre) {
             facade.GetGenreGateway().Add(genre);
            return Redirect("Index");
        }
        #endregion

        #region Edit one Genre
        [HttpGet]
        public ActionResult Edit(int genreId) {
            try {
                Genre theGenre = facade.GetGenreGateway().Get(genreId);
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
            facade.GetGenreGateway().Update(genre);
            return Redirect("Index");
        }

        #endregion

       
    }

}