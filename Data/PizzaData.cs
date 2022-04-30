using Avesdo.Models;
using System.Linq;
namespace Avesdo.Data
{
    public class PizzaData
    {
        public static void Initialize(ApplicationDbContext db)
        {
            if (!db.Pizzas.Any()) {
                db.Pizzas.Add(new Pizzas {
                    Title = "Hawaian",
                    Price = 9.99f,
                    Topping = "PineApple"
                });
                db.Pizzas.Add(new Pizzas {
                    Title = "Pepperoni",
                    Price = 8.99f,
                    Topping = "Peppers"
                });
                db.Pizzas.Add(new Pizzas {
                    Title = "Cheese",
                    Price = 12.99f,
                    Topping = "mozzarella"
                });
                db.Pizzas.Add(new Pizzas {
                    Title = "Veggie",
                    Price = 13.99f,
                    Topping = "Mushroom"
                });
                db.SaveChanges();
            }
        }
    }
}