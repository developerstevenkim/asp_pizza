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
    public class PizzasApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PizzasApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PizzasApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizzas>>> GetPizzas()
        {
            return await _context.Pizzas.Include(o => o.OrdPizs).Include(t => t.PizTops).ToListAsync();
        }

        // GET: api/PizzasApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pizzas>> GetPizzas(int id)
        {
            var pizzas = await _context.Pizzas
                .Include(o => o.OrdPizs)
                .Include(t => t.PizTops)
                .FirstOrDefaultAsync(p => p.PizzaId == id);

            if (pizzas == null)
            {
                return NotFound();
            }

            return pizzas;
        }

        // PUT: api/PizzasApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzas(int id, Pizzas pizzas)
        {
            if (id != pizzas.PizzaId)
            {
                return BadRequest();
            }

            _context.Entry(pizzas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzasExists(id))
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

        // POST: api/PizzasApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pizzas>> PostPizzas(Pizzas pizzas)
        {
            _context.Pizzas.Add(pizzas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPizzas", new { id = pizzas.PizzaId }, pizzas);
        }

        // DELETE: api/PizzasApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzas(int id)
        {
            var pizzas = await _context.Pizzas.FindAsync(id);
            if (pizzas == null)
            {
                return NotFound();
            }

            _context.Pizzas.Remove(pizzas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzasExists(int id)
        {
            return _context.Pizzas.Any(e => e.PizzaId == id);
        }
    }
}
