using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace Avesdo.Models
{
    public class Pizzas
    {
        [Key]
        [Display(Name = "Pizza ID")]
        public int PizzaId { get; set; }
        [Display(Name = "Pizza")]
        public string Title { get; set; }
        public float Price { get; set; }
        public List<OrdPiz> OrdPizs { get; set; }
        public List<PizTop> PizTops { get; set; }


    }
}