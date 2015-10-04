using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.DomainModels
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="First name required")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage ="Last Name required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Street name required")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "Street number required")]
        [Range(0, int.MaxValue, ErrorMessage ="Must be positive")]
        public int StreetNumber { get; set; }

        [Required(ErrorMessage = "Email required")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage ="Doesn't look like an email"),]
        public string Email { get; set; }

        /// <summary>
        /// Constructor:
        /// </summary>
        public Customer()
        {

        }
    }
}
