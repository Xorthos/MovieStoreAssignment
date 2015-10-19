using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage ="Doesn't look like an email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage ="Doesn't look like an email")]
        public string Email { get; set; }
        
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The password needs to have a length of 6-20.")]
        public string Password { get; set; }

        /// <summary>
        /// Constructor:
        /// </summary>
        public Customer()
        {

        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
