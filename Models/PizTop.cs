using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avesdo.Models
{
    public class PizTop
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "PizTop ID")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Pizza ID")]
        public int PizzaId { get; set; }
        public Pizzas Pizza { get; set; }
        [Required]
        [Display(Name = "Topping ID")]
        public int ToppingId { get; set; }
        public Toppings Topping { get; set; }
        public int Quantity { get; set; }
    }
}