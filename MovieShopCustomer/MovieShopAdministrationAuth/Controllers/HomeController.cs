using MovieShopAdministrationAuth.Models;
using Proxy.DomainModels;
using Proxy.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proxy.Facade.Implementation;

namespace MovieShopAdministrationAuth.Controllers
{

    public class HomeController : Controller
    {
        Facade facade = new Facade();
        #region Index 
        public ActionResult Index()
        {
            //could this be done in a view model?
            List<Movie> movies = (List<Movie>) facade.GetMovieGateway().GetAll();
            List<Genre> genres = (List<Genre>) facade.GetGenreGateway().GetAll();
            return View(new IndexViewModelHomeMade() { Movies = movies, Genres = genres });
        }
        #endregion
        #region ViewCustomer
        [HttpGet]
        public ActionResult ViewCustomers()
        {
            List<Customer> customers = (List<Customer>) facade.GetCustomerGateway().GetAll();
            return View(customers);
        }
        #endregion

        #region ViewOrder
        public ActionResult ViewOrders()
        {
            
            return View(facade.GetOrderGateway().GetAll());
        }
        #endregion
    }
}