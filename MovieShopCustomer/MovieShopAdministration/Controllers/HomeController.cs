using MovieShopAdministration.Models;
using Proxy.DomainModels;
using Proxy.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proxy.Facade.Implementation;

namespace MovieShopAdministration.Controllers
{

    public class HomeController : Controller
    {
        Facade facade = new Facade();
        #region Index 
        public ActionResult Index()
        {
            List<Movie> movies = facade.GetMovieRepository().GetAll();
            List<Genre> genres = facade.GetGenreRepository().GetAll();
            return View(new IndexViewModel() { Movies = movies, Genres = genres });
        }
        #endregion
        #region ViewCustomer
        [HttpGet]
        public ActionResult ViewCustomers()
        {
            List<Customer> customers = facade.GetCustomerRepository().GetAll();
            return View(customers);
        }
        #endregion

        #region ViewOrder
        public ActionResult ViewOrders()
        {
            
            return View(facade.GetOrderRepository().GetAll());
        }
        #endregion
    }
}