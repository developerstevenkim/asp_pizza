using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avesdo.Models
{
    public class OrdPiz
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "OrdPiz ID")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }
        public Orders Order { get; set; }
        [Required]
        [Display(Name = "Pizza ID")]
        public int PizzaId { get; set; }
        public Pizzas Pizza { get; set; }
        public int Quantity { get; set; }
    }
}