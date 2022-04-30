using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avesdo.Models
{
    public class PizTop
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Pizza_title { get; set; }
        public Pizzas Pizza { get; set; }
        [Required]
        public string Topping_title { get; set; }
        public Toppings Topping { get; set; }
    }
}