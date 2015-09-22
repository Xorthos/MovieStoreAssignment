using Proxy.DomainModels;
using Proxy.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie mov = new Movie() { ID = 1, Title = "Title", price = 2020, Year = DateTime.Now, RandomNumber = 45 };
            Facade fac = new Facade();
            fac.GetMovieRepository().Add(mov);

        }
    }
}
