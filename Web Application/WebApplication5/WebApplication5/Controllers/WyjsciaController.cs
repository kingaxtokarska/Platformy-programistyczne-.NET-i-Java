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
    public class WyjsciaController : Controller
    {
        private readonly firmaContext _context;

        public WyjsciaController(firmaContext context)
        {
            _context = context;
        }

        // GET: Wyjscia
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = sortOrder == "imie" ? "imie_desc" : "imie";
            ViewBag.SurnameSortParm = sortOrder == "nazwisko" ? "nazwisko_desc" : "nazwisko";
            ViewBag.DateSortParm = sortOrder == "data" ? "data_desc" : "data";
            ViewBag.TimeSortParm = sortOrder == "godzina" ? "godzina_desc" : "godzina";

            var wyjscia = from wy in (_context.Wyjscia.Include(wy => wy.IdPracownikNavigation))
                          select wy;

            if (!String.IsNullOrEmpty(searchString))
            {
                wyjscia = wyjscia.Where(wy => wy.IdPracownikNavigation.Imie.Contains(searchString)
                                       || wy.IdPracownikNavigation.Nazwisko.Contains(searchString)
                                       || wy.DataWyjscia.ToString().Contains(searchString)
                                       || wy.GodzinaWyjscia.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "imie_desc":
                    wyjscia = wyjscia.OrderByDescending(wy => wy.IdPracownikNavigation.Imie);
                    break;
                case "imie":
                    wyjscia = wyjscia.OrderBy(wy => wy.IdPracownikNavigation.Imie);
                    break;
                case "nazwisko_desc":
                    wyjscia = wyjscia.OrderByDescending(wy => wy.IdPracownikNavigation.Nazwisko);
                    break;
                case "nazwisko":
                    wyjscia = wyjscia.OrderBy(wy => wy.IdPracownikNavigation.Nazwisko);
                    break;
                case "data_desc":
                    wyjscia = wyjscia.OrderByDescending(wy => wy.DataWyjscia);
                    break;
                case "data":
                    wyjscia = wyjscia.OrderBy(wy => wy.DataWyjscia);
                    break;
                case "godzina_desc":
                    wyjscia = wyjscia.OrderByDescending(wy => wy.GodzinaWyjscia);
                    break;
                case "godzina":
                    wyjscia = wyjscia.OrderBy(wy => wy.GodzinaWyjscia);
                    break;
                default:
                    wyjscia = wyjscia.OrderBy(wy => wy.idWyjscie);
                    break;
            }
            return View(await wyjscia.ToListAsync());
        }

        // GET: Wyjscia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wyjscia = await _context.Wyjscia
                .Include(w => w.IdPracownikNavigation)
                .FirstOrDefaultAsync(m => m.idWyjscie == id);
            if (wyjscia == null)
            {
                return NotFound();
            }

            return View(wyjscia);
        }

        // GET: Wyjscia/Create
        public IActionResult Create()
        {
            ViewData["IdPracownik"] = new SelectList(_context.Pracownik, "IdPracownik", "Imie");
            return View();
        }

        // POST: Wyjscia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idWyjscie,IdPracownik,DataWyjscia,GodzinaWyjscia")] Wyjscia wyjscia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wyjscia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPracownik"] = new SelectList(_context.Pracownik, "IdPracownik", "Imie", wyjscia.IdPracownik);
            return View(wyjscia);
        }

        // GET: Wyjscia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wyjscia = await _context.Wyjscia.FindAsync(id);
            if (wyjscia == null)
            {
                return NotFound();
            }
            ViewData["IdPracownik"] = new SelectList(_context.Pracownik, "IdPracownik", "Imie", wyjscia.IdPracownik);
            return View(wyjscia);
        }

        // POST: Wyjscia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idWyjscie,IdPracownik,DataWyjscia,GodzinaWyjscia")] Wyjscia wyjscia)
        {
            if (id != wyjscia.idWyjscie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wyjscia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WyjsciaExists(wyjscia.idWyjscie))
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
            ViewData["IdPracownik"] = new SelectList(_context.Pracownik, "IdPracownik", "Imie", wyjscia.IdPracownik);
            return View(wyjscia);
        }

        // GET: Wyjscia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wyjscia = await _context.Wyjscia
                .Include(w => w.IdPracownikNavigation)
                .FirstOrDefaultAsync(m => m.idWyjscie == id);
            if (wyjscia == null)
            {
                return NotFound();
            }

            return View(wyjscia);
        }

        // POST: Wyjscia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wyjscia = await _context.Wyjscia.FindAsync(id);
            _context.Wyjscia.Remove(wyjscia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WyjsciaExists(int id)
        {
            return _context.Wyjscia.Any(e => e.idWyjscie == id);
        }
    }
}
