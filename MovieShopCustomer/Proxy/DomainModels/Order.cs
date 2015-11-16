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
        //[Required]
        //public Customer Customer { get; set; }

        [Required]
        public string Email { get; set; }

        public List<Orderline> Orderlines{ get; set;}

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime OrderDate { get; set; }
        
        public Status Status { get; set; }
        public Order()
        {

        }

        /// <summary>
        /// Constructor:
        /// </summary>
        public Order(List<Orderline> orderLines, string email)
        {
            Orderlines = orderLines;
            Email = email;
            OrderDate = DateTime.Now;
        }
    }
}
