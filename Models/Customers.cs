using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avesdo.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string Customer_name { get; set; }
        public string Phone_number { get; set; }
        public int Suite { get; set; }
        public string Street { get; set; }
        public string Zip_code { get; set; }

        public List<Orders> Orders { get; set; }
    }
}