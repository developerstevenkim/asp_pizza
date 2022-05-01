using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace Avesdo.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        [Display(Name = "Date & Time")]
        public DateTime dateTime { get; set; }

        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customers Customer { get; set; }
        public List<OrdPiz> OrdPizs { get; set; }
    }
}