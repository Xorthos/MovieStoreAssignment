using Proxy.DomainModels;
using Proxy.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopAdministrationAuth.Models
{
    public class EditMovieModel
    {
        Facade facade = new Facade();

        public EditMovieModel() {
            GetGenres();
            }
        public EditMovieModel(int Id): this()
        {   
            GetMovie(Id);
            
        }
        private void GetGenres() {
            Genres = facade.GetGenreRepository().GetAll();
        }
        private void GetMovie(int Id)
        {
            Movie = facade.GetMovieRepository().GetMovie(Id);
        }
        public Movie Movie { get; set; }

        public List<Genre> Genres { get; set; }
    }


}