using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avesdo.Models
{
    public class Customers
    {
        [Key]
        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }
        [Display(Name = "Name")]
        public string Customer_name { get; set; }
        [Display(Name = "Phone #")]
        public string Phone_number { get; set; }
        [Display(Name = "Suite #")]
        public int Suite { get; set; }
        [Display(Name = "Street")]
        public string Street { get; set; }
        [Display(Name = "Zip code")]
        public string Zip_code { get; set; }

        public List<Orders> Orders { get; set; }
    }
}