using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.DomainModels
{
    public class Orderline
    {   [Key]
         [ForeignKey("Id")]
        public Movie Movie { get; set; }
        [Key]
        [ForeignKey("Id")]
        public Order Order { get; set; }
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
     
    }
}
