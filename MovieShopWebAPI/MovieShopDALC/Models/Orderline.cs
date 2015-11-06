using MovieShopDALC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDALC.Models
{
    public class Orderline
    {
        [Key]
        public int Id { get; set; }

        private int amount;

        [ForeignKey("Movie")]
        [Column(Order = 1)]
        public int MovieId { get; set; }
        public double Price { get; set; }

        public virtual Movie Movie { get; set; }

        [Column(Order = 2)]
        public int OrderId { get; set; }

        [Range(1, 10)]
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                if (1 <= value && value <= 10)
                {
                    amount = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public Orderline()
        {

        }

    }
}
