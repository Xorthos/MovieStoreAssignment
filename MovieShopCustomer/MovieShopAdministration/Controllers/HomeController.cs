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
            List<Movie> movies = facade.GetMovieRepository().GetAll();
            List<Genre> genres = facade.GetGenreRepository().GetAll();

            return View(new IndexViewModel() { Movies = movies, Genres = genres });
            
        }
        [HttpGet]
        public ActionResult Customer()
        {
            List<Customer> customers = facade.GetCustomerRepository().GetAll();

            return View(customers);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SeeOrders()
        {
            
            return View(new OrderStrongType());
        }
    }
}