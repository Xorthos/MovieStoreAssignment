using MovieShopCustomerAuth.Models;
using Proxy.DomainModels;
using Proxy.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proxy.Facade.abstraction;
using Proxy.Facade.Implementation;

namespace MovieShopCustomerAuth.Controllers
{

    public class HomeController : Controller
    {
        IFacade facade = new Facade();

        #region Home Index
        public ActionResult Index()
        {
            return View(new IndexViewModelHomeMade());
        }
        #endregion

        #region Search between movies and filter option by genres
        [HttpGet]
        public ActionResult FilterMovies([Bind(Include = "SearchToken,GenreId,UseGenre")]FilterModel filters)
        {
            return View("Index", new IndexViewModelHomeMade(filters));
        }
        #endregion

        #region UserProfile
        [HttpGet]
        public ActionResult UserProfile()
        {
            return View();
        }
        #endregion

        #region Change a Customer Information
        [HttpGet]
        public ActionResult ChangeInfo()
        {
            return View(facade.GetCustomerGateway().Get((int)Session["UserId"]));
        }
        #endregion

        #region ViewOrders
        [HttpGet]
        public ActionResult ViewOrders()
        {
            return View(facade.GetOrderGateway().GetOrders((int)Session["UserId"]));
        }
        #endregion

    }
}