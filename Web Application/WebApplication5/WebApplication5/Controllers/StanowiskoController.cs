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
    public class StanowiskoController : Controller
    {
        private readonly firmaContext _context;

        public StanowiskoController(firmaContext context)
        {
            _context = context;
        }

        // GET: Stanowisko
            public async Task<IActionResult> Index(string sortOrder, string searchString)
            {
                ViewBag.EmplacementSortParm = sortOrder == "stanowisko" ? "stanowisko_desc" : "stanowisko";
                ViewBag.PaymentSortParm = sortOrder == "wynagrodzenie" ? "wynagrodzenie_desc" : "wynagrodzenie";
                ViewBag.SectionSortParm = sortOrder == "dzial" ? "dzial_desc" : "dzial";

                var stanowiska = from s in (_context.Stanowisko.Include(s => s.IdDzialNavigation))
                                 select s;

                if (!String.IsNullOrEmpty(searchString))
                {
                    stanowiska = stanowiska.Where(s => s.NazwaStanowisko.Contains(searchString)
                                           || s.Wynagrodzenie.ToString().Contains(searchString)
                                           || s.IdDzialNavigation.NazwaDzial.Contains(searchString));
                }

                switch (sortOrder)
                {
                    case "stanowisko_desc":
                        stanowiska = stanowiska.OrderByDescending(s => s.NazwaStanowisko);
                        break;
                    case "stanowisko":
                        stanowiska = stanowiska.OrderBy(s => s.NazwaStanowisko);
                        break;
                    case "wynarodzenie_desc":
                        stanowiska = stanowiska.OrderByDescending(s => s.Wynagrodzenie);
                        break;
                    case "wynagrodzenie":
                        stanowiska = stanowiska.OrderBy(s => s.Wynagrodzenie);
                        break;
                    case "dzial_desc":
                        stanowiska = stanowiska.OrderByDescending(s => s.IdDzialNavigation.NazwaDzial);
                        break;
                    case "dzial":
                        stanowiska = stanowiska.OrderBy(s => s.IdDzialNavigation.NazwaDzial);
                        break;
                    default:
                        stanowiska = stanowiska.OrderBy(s => s.IdStanowisko);
                        break;
                }
                return View(await stanowiska.ToListAsync());
            }

        // GET: Stanowisko/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stanowisko = await _context.Stanowisko
                .Include(s => s.IdDzialNavigation)
                .FirstOrDefaultAsync(m => m.IdStanowisko == id);
            if (stanowisko == null)
            {
                return NotFound();
            }

            return View(stanowisko);
        }

        // GET: Stanowisko/Create
        public IActionResult Create()
        {
            ViewData["IdDzial"] = new SelectList(_context.Dzial, "IdDzial", "NazwaDzial");
            return View();
        }

        // POST: Stanowisko/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStanowisko,NazwaStanowisko,Wynagrodzenie,IdDzial")] Stanowisko stanowisko)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stanowisko);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDzial"] = new SelectList(_context.Dzial, "IdDzial", "NazwaDzial", stanowisko.IdDzial);
            return View(stanowisko);
        }

        // GET: Stanowisko/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stanowisko = await _context.Stanowisko.FindAsync(id);
            if (stanowisko == null)
            {
                return NotFound();
            }
            ViewData["IdDzial"] = new SelectList(_context.Dzial, "IdDzial", "NazwaDzial", stanowisko.IdDzial);
            return View(stanowisko);
        }

        // POST: Stanowisko/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStanowisko,NazwaStanowisko,Wynagrodzenie,IdDzial")] Stanowisko stanowisko)
        {
            if (id != stanowisko.IdStanowisko)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stanowisko);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StanowiskoExists(stanowisko.IdStanowisko))
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
            ViewData["IdDzial"] = new SelectList(_context.Dzial, "IdDzial", "NazwaDzial", stanowisko.IdDzial);
            return View(stanowisko);
        }

        // GET: Stanowisko/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stanowisko = await _context.Stanowisko
                .Include(s => s.IdDzialNavigation)
                .FirstOrDefaultAsync(m => m.IdStanowisko == id);
            if (stanowisko == null)
            {
                return NotFound();
            }

            return View(stanowisko);
        }

        // POST: Stanowisko/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stanowisko = await _context.Stanowisko.FindAsync(id);
            _context.Stanowisko.Remove(stanowisko);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StanowiskoExists(int id)
        {
            return _context.Stanowisko.Any(e => e.IdStanowisko == id);
        }
    }
}
