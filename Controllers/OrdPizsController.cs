using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Avesdo.Data;
using Avesdo.Models;

namespace Avesdo.Controllers
{
    public class OrdPizsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdPizsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrdPizs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrdPizs.Include(o => o.Order).Include(o => o.Pizza);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrdPizs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordPiz = await _context.OrdPizs
                .Include(o => o.Order)
                .Include(o => o.Pizza)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordPiz == null)
            {
                return NotFound();
            }

            return View(ordPiz);
        }

        // GET: OrdPizs/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "PizzaId", "PizzaId");
            return View();
        }

        // POST: OrdPizs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,PizzaId")] OrdPiz ordPiz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordPiz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", ordPiz.OrderId);
            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "PizzaId", "PizzaId", ordPiz.PizzaId);
            return View(ordPiz);
        }

        // GET: OrdPizs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordPiz = await _context.OrdPizs.FindAsync(id);
            if (ordPiz == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", ordPiz.OrderId);
            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "PizzaId", "PizzaId", ordPiz.PizzaId);
            return View(ordPiz);
        }

        // POST: OrdPizs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,PizzaId")] OrdPiz ordPiz)
        {
            if (id != ordPiz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordPiz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdPizExists(ordPiz.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", ordPiz.OrderId);
            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "PizzaId", "PizzaId", ordPiz.PizzaId);
            return View(ordPiz);
        }

        // GET: OrdPizs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordPiz = await _context.OrdPizs
                .Include(o => o.Order)
                .Include(o => o.Pizza)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordPiz == null)
            {
                return NotFound();
            }

            return View(ordPiz);
        }

        // POST: OrdPizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordPiz = await _context.OrdPizs.FindAsync(id);
            _context.OrdPizs.Remove(ordPiz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdPizExists(int id)
        {
            return _context.OrdPizs.Any(e => e.Id == id);
        }
    }
}
