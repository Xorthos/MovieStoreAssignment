using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.DomainModels
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Constructor:
        /// </summary>
        public Order()
        {

        }
    }
}
