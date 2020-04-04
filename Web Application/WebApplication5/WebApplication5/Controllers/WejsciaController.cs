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
    public class WejsciaController : Controller
    {
        private readonly firmaContext _context;

        public WejsciaController(firmaContext context)
        {
            _context = context;
        }

        // GET: Wejscia
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = sortOrder == "imie" ? "imie_desc" : "imie";
            ViewBag.SurnameSortParm = sortOrder == "nazwisko" ? "nazwisko_desc" : "nazwisko";
            ViewBag.DateSortParm = sortOrder == "data" ? "data_desc" : "data";
            ViewBag.TimeSortParm = sortOrder == "godzina" ? "godzina_desc" : "godzina";

            var wejscia = from we in (_context.Wejscia.Include(we => we.IdPracownikNavigation))
                             select we;

            if (!String.IsNullOrEmpty(searchString))
            {
                wejscia = wejscia.Where(we => we.IdPracownikNavigation.Imie.Contains(searchString)
                                       || we.IdPracownikNavigation.Nazwisko.Contains(searchString)
                                       || we.DataWejscia.ToString().Contains(searchString)
                                       || we.GodzinaWejscia.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "imie_desc":
                    wejscia = wejscia.OrderByDescending(we => we.IdPracownikNavigation.Imie);
                    break;
                case "imie":
                    wejscia = wejscia.OrderBy(we => we.IdPracownikNavigation.Imie);
                    break;
                case "nazwisko_desc":
                    wejscia = wejscia.OrderByDescending(we => we.IdPracownikNavigation.Nazwisko);
                    break;
                case "nazwisko":
                    wejscia = wejscia.OrderBy(we => we.IdPracownikNavigation.Nazwisko);
                    break;
                case "data_desc":
                    wejscia = wejscia.OrderByDescending(we => we.DataWejscia);
                    break;
                case "data":
                    wejscia = wejscia.OrderBy(we => we.DataWejscia);
                    break;
                case "godzina_desc":
                    wejscia = wejscia.OrderByDescending(we => we.GodzinaWejscia);
                    break;
                case "godzina":
                    wejscia = wejscia.OrderBy(we => we.GodzinaWejscia);
                    break;
                default:
                    wejscia = wejscia.OrderBy(we => we.idWejscie);
                    break;
            }
            return View(await wejscia.ToListAsync());
        }

        // GET: Wejscia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wejscia = await _context.Wejscia
                .Include(w => w.IdPracownikNavigation)
                .FirstOrDefaultAsync(m => m.idWejscie == id);
            if (wejscia == null)
            {
                return NotFound();
            }

            return View(wejscia);
        }

        // GET: Wejscia/Create
        public IActionResult Create()
        {
            ViewData["IdPracownik"] = new SelectList(_context.Pracownik, "IdPracownik", "Imie");
            return View();
        }

        // POST: Wejscia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idWejscie,IdPracownik,DataWejscia,GodzinaWejscia")] Wejscia wejscia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wejscia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPracownik"] = new SelectList(_context.Pracownik, "IdPracownik", "Imie", wejscia.IdPracownik);
            return View(wejscia);
        }

        // GET: Wejscia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wejscia = await _context.Wejscia.FindAsync(id);
            if (wejscia == null)
            {
                return NotFound();
            }
            ViewData["IdPracownik"] = new SelectList(_context.Pracownik, "IdPracownik", "Imie", wejscia.IdPracownik);
            return View(wejscia);
        }

        // POST: Wejscia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idWejscie,IdPracownik,DataWejscia,GodzinaWejscia")] Wejscia wejscia)
        {
            if (id != wejscia.idWejscie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wejscia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WejsciaExists(wejscia.idWejscie))
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
            ViewData["IdPracownik"] = new SelectList(_context.Pracownik, "IdPracownik", "Imie", wejscia.IdPracownik);
            return View(wejscia);
        }

        // GET: Wejscia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wejscia = await _context.Wejscia
                .Include(w => w.IdPracownikNavigation)
                .FirstOrDefaultAsync(m => m.idWejscie == id);
            if (wejscia == null)
            {
                return NotFound();
            }

            return View(wejscia);
        }

        // POST: Wejscia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wejscia = await _context.Wejscia.FindAsync(id);
            _context.Wejscia.Remove(wejscia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WejsciaExists(int id)
        {
            return _context.Wejscia.Any(e => e.idWejscie == id);
        }
    }
}
