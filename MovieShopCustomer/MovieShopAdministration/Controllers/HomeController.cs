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

    public class HomeController : Controller
    {
        Facade facade = new Facade();

        public ActionResult Index()
        {
            return View();
            List<Movie> movies = facade.GetMovieRepository().GetAll();
            List<Genre> genres = facade.GetGenreRepository().GetAll();
            return View(new IndexViewModel() { Movies = movies, Genres = genres });
        }

        public ActionResult About()
        [HttpGet]
        public ActionResult Customer()
        {
            ViewBag.Message = "Your application description page.";
            List<Customer> customers = facade.GetCustomerRepository().GetAll();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
            return View(customers);
        }

        public ActionResult ViewOrders()
        {
            
            return View(facade.GetOrderRepository().GetAll());
        }
    }
}