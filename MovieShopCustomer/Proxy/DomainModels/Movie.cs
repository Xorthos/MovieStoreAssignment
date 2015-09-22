using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.DomainModels
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public double price { get; set; }
        public DateTime Year { get; set; }
        public int RandomNumber { get; set; }

        public Movie()
        {

        }
    }
}
