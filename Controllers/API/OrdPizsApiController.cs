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
    public class OrdPizsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdPizsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/OrdPizsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdPiz>>> GetOrdPizs()
        {
            return await _context.OrdPizs.ToListAsync();
        }

        // GET: api/OrdPizsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdPiz>> GetOrdPiz(int id)
        {
            var ordPiz = await _context.OrdPizs.FindAsync(id);

            if (ordPiz == null)
            {
                return NotFound();
            }

            return ordPiz;
        }

        // PUT: api/OrdPizsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdPiz(int id, OrdPiz ordPiz)
        {
            if (id != ordPiz.Id)
            {
                return BadRequest();
            }

            _context.Entry(ordPiz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdPizExists(id))
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

        // POST: api/OrdPizsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdPiz>> PostOrdPiz(OrdPiz ordPiz)
        {
            _context.OrdPizs.Add(ordPiz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdPiz", new { id = ordPiz.Id }, ordPiz);
        }

        // DELETE: api/OrdPizsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdPiz(int id)
        {
            var ordPiz = await _context.OrdPizs.FindAsync(id);
            if (ordPiz == null)
            {
                return NotFound();
            }

            _context.OrdPizs.Remove(ordPiz);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdPizExists(int id)
        {
            return _context.OrdPizs.Any(e => e.Id == id);
        }
    }
}
