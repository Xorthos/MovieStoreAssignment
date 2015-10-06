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
        [Display(Name = "MovieId")]
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Keep the name under 50 chars")]
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType("number")]
        public double Price { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Year { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        [DataType("url")]
        public string ImgUrl { get; set; }
        [Required]
        [DataType("url")]
        public string TrailerUrl { get; set; }

        public Movie()
        {

        }
    }
}
