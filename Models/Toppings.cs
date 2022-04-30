using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Avesdo.Models
{
    public class Toppings
    {
        [Key]
        public int ToppingId { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public List<PizTop> PizTops { get; set; }

    }
}