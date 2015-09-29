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
        public int Id { get; set; }
        [StringLength(100, ErrorMessage = "Keep the name under 100 chars")]
        public string Title { get; set; }
        public double Price { get; set; }
        public DateTime Year { get; set; }
        public Genre Genre { get; set; }
        public string ImgUrl { get; set; }
        public string TrailerUrl { get; set; }

        public Movie()
        {

        }
    }
}
