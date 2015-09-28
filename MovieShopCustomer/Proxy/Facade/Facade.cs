using Proxy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Facade
{
    public class Facade
    {
        public MovieRepository GetMovieRepository()
        {
            return new MovieRepository();
        }

        public GenreRepository GetGenreRepository()
        {
            return new GenreRepository();
        }
    }
}
