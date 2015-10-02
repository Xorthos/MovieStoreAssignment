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
        [DataType("Text")]
        public string FirstName { get; set; }
        [DataType("Text")]
        public string MiddleName { get; set; }
        [Required]
        [DataType("Text")]
        public string LastName { get; set; }
        [Required]
        [DataType("Text")]
        public string StreetName { get; set; }
        [Required]
        [DataType("Number")]
        public int StreetNumber { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        [DataType("Text")]
        public string Email { get; set; }

        /// <summary>
        /// Constructor:
        /// </summary>
        public Customer()
        {

        }
    }
}
