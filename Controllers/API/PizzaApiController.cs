using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Avesdo.Data;
using Avesdo.Models;

namespace Avesdo.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PizzaApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PizzaApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas()
        {
            return await _context.Pizzas.ToListAsync();
        }

        // GET: api/PizzaApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> GetPizza(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);

            if (pizza == null)
            {
                return NotFound();
            }

            return pizza;
        }

        // PUT: api/PizzaApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizza(int id, Pizza pizza)
        {
            if (id != pizza.PizzaId)
            {
                return BadRequest();
            }

            _context.Entry(pizza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PizzaApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pizza>> PostPizza(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPizza", new { id = pizza.PizzaId }, pizza);
        }

        // DELETE: api/PizzaApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizza(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }

            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaExists(int id)
        {
            return _context.Pizzas.Any(e => e.PizzaId == id);
        }
    }
}
