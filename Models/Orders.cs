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
        public DateTime Title { get; set; }
        public int Customer_id { get; set; }
        [ForeignKey("Customer_id")]
        public Customers Customer { get; set; }
        public List<OrdPiz> OrdPizs { get; set; }
    }
}