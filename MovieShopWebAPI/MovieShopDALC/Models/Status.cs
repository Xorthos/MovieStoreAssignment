using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDALC.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string Name { get; set; }
    }
}
