using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Avesdo.Models
{
    public class Toppings
    {
        [Key]
        [Display(Name = "Topping ID")]
        public int ToppingId { get; set; }
        [Display(Name = "Topping")]
        public string Title { get; set; }
        public float Price { get; set; }
        public List<PizTop> PizTops { get; set; }

    }
}