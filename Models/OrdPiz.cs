using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avesdo.Models
{
    public class OrdPiz
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        public Orders Order { get; set; }
        [Required]
        public int PizzaId { get; set; }
        public Pizzas Pizza { get; set; }
    }
}