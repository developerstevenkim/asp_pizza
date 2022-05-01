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
            if (!db.Customers.Any()) {
                db.Customers.Add(new Customers {
                    Customer_name = "Dohun Kim",
                    Phone_number = "604 679 4111",
                    Suite = 302,
                    Street = "609 Cottonwood Avenue",
                    Zip_code = "V3J 0H2"
                });
            }
            if (!db.Toppings.Any()) {
                db.Toppings.Add(new Toppings {
                    Title = "Mushroom",
                    Price = 2
                });
            }
            if (!db.Toppings.Any()) {
                db.Toppings.Add(new Toppings {
                    Title = "Olive",
                    Price = 2
                });
            }
            if (!db.Toppings.Any()) {
                db.Toppings.Add(new Toppings {
                    Title = "Sausage",
                    Price = 3
                });
            }
        }
    }
}