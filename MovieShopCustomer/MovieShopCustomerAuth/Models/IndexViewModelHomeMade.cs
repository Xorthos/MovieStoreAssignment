using Proxy.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proxy.Facade.abstraction;
using Proxy.Facade.Implementation;

namespace MovieShopCustomerAuth.Models
{
    public class IndexViewModelHomeMade
    {
        public IndexViewModelHomeMade()
        {
            IFacade facade = new Facade();
            Movies = (List<Movie>)facade.GetMovieGateway().GetAll();
            Genres = (List<Genre>)facade.GetGenreGateway().GetAll();
        }

        public IndexViewModelHomeMade(FilterModel filters) : this()
        {
            if (filters.SearchToken != null)
            {
                Movies = Movies.Where(c => c.Title.ToLower().Contains(filters.SearchToken.ToLower())).ToList();
            }
            if (filters.UseGenre)
            {
                Movies = Movies.Where(c => c.Genre.Id == filters.GenreId).ToList();
            }
            
        }
        public List<Movie> Movies { get; private set; }
        public List<Genre> Genres { get; private set; }
    }
}