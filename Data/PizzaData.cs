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
                    Price = 9.99f
                });
                db.Pizzas.Add(new Pizzas {
                    Title = "Pepperoni",
                    Price = 8.99f
                });
                db.Pizzas.Add(new Pizzas {
                    Title = "Cheese",
                    Price = 12.99f
                });
                db.Pizzas.Add(new Pizzas {
                    Title = "Veggie",
                    Price = 13.99f
                });
                db.SaveChanges();
            }
        }
    }
}