using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class DzialController : Controller
    {
        private readonly firmaContext _context;

        public DzialController(firmaContext context)
        {
            _context = context;
        }

        // GET: Dzial
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewBag.SectionSortParm = sortOrder == "dzial" ? "dzial_desc" : "dzial";

            var dzialy = from d in (_context.Dzial)
                             select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                dzialy = dzialy.Where(s => s.NazwaDzial.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "dzial_desc":
                    dzialy = dzialy.OrderByDescending(d => d.NazwaDzial);
                    break;
                case "dzial":
                    dzialy = dzialy.OrderBy(d => d.NazwaDzial);
                    break;
                default:
                    dzialy = dzialy.OrderBy(d => d.IdDzial);
                    break;
            }
            return View(await dzialy.ToListAsync());
        }

        // GET: Dzial/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dzial = await _context.Dzial
                .FirstOrDefaultAsync(m => m.IdDzial == id);
            if (dzial == null)
            {
                return NotFound();
            }

            return View(dzial);
        }

        // GET: Dzial/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dzial/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDzial,NazwaDzial")] Dzial dzial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dzial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dzial);
        }

        // GET: Dzial/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dzial = await _context.Dzial.FindAsync(id);
            if (dzial == null)
            {
                return NotFound();
            }
            return View(dzial);
        }

        // POST: Dzial/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDzial,NazwaDzial")] Dzial dzial)
        {
            if (id != dzial.IdDzial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dzial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DzialExists(dzial.IdDzial))
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
            return View(dzial);
        }

        // GET: Dzial/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dzial = await _context.Dzial
                .FirstOrDefaultAsync(m => m.IdDzial == id);
            if (dzial == null)
            {
                return NotFound();
            }

            return View(dzial);
        }

        // POST: Dzial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dzial = await _context.Dzial.FindAsync(id);
            _context.Dzial.Remove(dzial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DzialExists(int id)
        {
            return _context.Dzial.Any(e => e.IdDzial == id);
        }
    }
}
