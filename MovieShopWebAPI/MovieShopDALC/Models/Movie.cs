using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDALC.Models
{
        public class Movie
        {
            [Key]
            public int Id { get; set; }
            public string Title { get; set; }
            public double Price { get; set; }
            public DateTime Year { get; set; }
            public Genre Genre { get; set; }
            public string ImgUrl { get; set; }
            public string TrailerUrl { get; set; }
    }
    
}
