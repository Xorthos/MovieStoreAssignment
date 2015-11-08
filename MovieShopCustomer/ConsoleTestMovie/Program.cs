using Proxy.DomainModels;
using Proxy.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxy.Facade.Implementation;

namespace ConsoleTestMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie mov = new Movie() { Id = 1, Title = "Title", Price = 2020, Year = DateTime.Now };
            Facade fac = new Facade();
            fac.GetMovieRepository().Add(mov);

        }
    }
}
