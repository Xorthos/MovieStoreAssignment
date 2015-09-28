using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.DomainModels
{
    public class Movie
    {
        [Key]
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public virtual Genre Genre { get; set; }

        public Movie()
        {

        }
    }
}
