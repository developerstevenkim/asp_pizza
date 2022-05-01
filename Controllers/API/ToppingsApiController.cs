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
    public class ToppingsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToppingsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ToppingsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Toppings>>> GetToppings()
        {
            return await _context.Toppings.Include(p => p.PizTops).ToListAsync();
        }

        // GET: api/ToppingsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Toppings>> GetToppings(int id)
        {
            var toppings = await _context.Toppings.FindAsync(id);

            if (toppings == null)
            {
                return NotFound();
            }

            return toppings;
        }

        // PUT: api/ToppingsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToppings(int id, Toppings toppings)
        {
            if (id != toppings.ToppingId)
            {
                return BadRequest();
            }

            _context.Entry(toppings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToppingsExists(id))
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

        // POST: api/ToppingsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Toppings>> PostToppings(Toppings toppings)
        {
            _context.Toppings.Add(toppings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToppings", new { id = toppings.ToppingId }, toppings);
        }

        // DELETE: api/ToppingsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToppings(int id)
        {
            var toppings = await _context.Toppings.FindAsync(id);
            if (toppings == null)
            {
                return NotFound();
            }

            _context.Toppings.Remove(toppings);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToppingsExists(int id)
        {
            return _context.Toppings.Any(e => e.ToppingId == id);
        }
    }
}
