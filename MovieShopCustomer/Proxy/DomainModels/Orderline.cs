using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.DomainModels
{
    public class Orderline
    {
        [Key]
        public int OrderId { get; set; }

        private int amount;

        [Required]
        [Range(1,10)]
        public int Amount {
            get
            {
                return amount;
            }
            set
            {
                if(1 <= value && value <= 10)
                {
                    amount = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        public Movie Movie { get; set; }
    }
}
