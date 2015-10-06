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

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage ="Must be positive")]
        public int StreetNumber { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The password needs to has a length of 6-20.")]
        public string Password { get; set; }

        /// <summary>
        /// Constructor:
        /// </summary>
        public Customer()
        {

        }
    }
}
