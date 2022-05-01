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
    public class PizTopsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PizTopsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PizTops
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PizTops.Include(p => p.Pizza).Include(p => p.Topping);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PizTops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizTop = await _context.PizTops
                .Include(p => p.Pizza)
                .Include(p => p.Topping)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pizTop == null)
            {
                return NotFound();
            }

            return View(pizTop);
        }

        // GET: PizTops/Create
        public IActionResult Create()
        {
            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "PizzaId", "PizzaId");
            ViewData["ToppingId"] = new SelectList(_context.Toppings, "ToppingId", "ToppingId");
            ViewBag.ListOfToppings = getToppingsSelectList();
            ViewBag.ListOfPizzas = getPizzasSelectList();
            return View();
        }

        // POST: PizTops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PizzaId,ToppingId,Quantity")] PizTop pizTop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pizTop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "PizzaId", "PizzaId", pizTop.PizzaId);
            ViewData["ToppingId"] = new SelectList(_context.Toppings, "ToppingId", "ToppingId", pizTop.ToppingId);
            return View(pizTop);
        }

        // GET: PizTops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizTop = await _context.PizTops.FindAsync(id);
            if (pizTop == null)
            {
                return NotFound();
            }
            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "PizzaId", "PizzaId", pizTop.PizzaId);
            ViewData["ToppingId"] = new SelectList(_context.Toppings, "ToppingId", "ToppingId", pizTop.ToppingId);
            ViewBag.ListOfToppings = getToppingsSelectList();
            ViewBag.ListOfPizzas = getPizzasSelectList();
            return View(pizTop);
        }

        // POST: PizTops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PizzaId,ToppingId,Quantity")] PizTop pizTop)
        {
            if (id != pizTop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pizTop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizTopExists(pizTop.Id))
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
            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "PizzaId", "PizzaId", pizTop.PizzaId);
            ViewData["ToppingId"] = new SelectList(_context.Toppings, "ToppingId", "ToppingId", pizTop.ToppingId);
            return View(pizTop);
        }

        // GET: PizTops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizTop = await _context.PizTops
                .Include(p => p.Pizza)
                .Include(p => p.Topping)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pizTop == null)
            {
                return NotFound();
            }

            return View(pizTop);
        }

        // POST: PizTops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pizTop = await _context.PizTops.FindAsync(id);
            _context.PizTops.Remove(pizTop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizTopExists(int id)
        {
            return _context.PizTops.Any(e => e.Id == id);
        }

        private List<SelectListItem> getToppingsSelectList()
        {
            List<Toppings> toppingList = _context.Toppings.ToList();
            List<SelectListItem> list = toppingList.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Title,
                    Value = a.ToppingId.ToString(),
                    Selected = false
                };
            });
            return list;
        }

        private List<SelectListItem> getPizzasSelectList()
        {
            List<Pizzas> pizzaList = _context.Pizzas.ToList();
            List<SelectListItem> list = pizzaList.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Title,
                    Value = a.PizzaId.ToString(),
                    Selected = false
                };
            });
            return list;
        }
    }
}
