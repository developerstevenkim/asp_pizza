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
    public class PizTopsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PizTopsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PizTopsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizTop>>> GetPizTops()
        {
            return await _context.PizTops.ToListAsync();
        }

        // GET: api/PizTopsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizTop>> GetPizTop(int id)
        {
            var pizTop = await _context.PizTops.FindAsync(id);

            if (pizTop == null)
            {
                return NotFound();
            }

            return pizTop;
        }

        // PUT: api/PizTopsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizTop(int id, PizTop pizTop)
        {
            if (id != pizTop.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizTop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizTopExists(id))
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

        // POST: api/PizTopsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PizTop>> PostPizTop(PizTop pizTop)
        {
            _context.PizTops.Add(pizTop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPizTop", new { id = pizTop.Id }, pizTop);
        }

        // DELETE: api/PizTopsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizTop(int id)
        {
            var pizTop = await _context.PizTops.FindAsync(id);
            if (pizTop == null)
            {
                return NotFound();
            }

            _context.PizTops.Remove(pizTop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizTopExists(int id)
        {
            return _context.PizTops.Any(e => e.Id == id);
        }
    }
}
