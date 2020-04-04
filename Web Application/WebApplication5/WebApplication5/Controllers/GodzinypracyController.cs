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
    public class GodzinypracyController : Controller
    {
        private readonly firmaContext _context;

        public GodzinypracyController(firmaContext context)
        {
            _context = context;
        }

        // GET: Godzinypracy
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewBag.DaynameSortParm = sortOrder == "dzientygodnia" ? "dzientygodnia_desc" : "dzientygodnia";
            ViewBag.StarttimeSortParm = sortOrder == "poczatekpracy" ? "poczatekpracy_desc" : "poczatekpracy";
            ViewBag.StoptimeSortParm = sortOrder == "koniecpracy" ? "koniecpracy_desc" : "koniecpracy";
            ViewBag.SectionSortParm = sortOrder == "dzial" ? "dzial_desc" : "dzial";


            var godzinypracy = from g in (_context.Godzinypracy.Include(g => g.IdDzialNavigation))
                             select g;

            if (!String.IsNullOrEmpty(searchString))
            {
                godzinypracy = godzinypracy.Where(g => g.DzienTygodnia.Contains(searchString)
                                       || g.PoczatekPracy.ToString().Contains(searchString)
                                       || g.KoniecPracy.ToString().Contains(searchString)
                                       || g.IdDzialNavigation.NazwaDzial.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "dzientygodnia_desc":
                    godzinypracy = godzinypracy.OrderByDescending(g => g.DzienTygodnia);
                    break;
                case "dzientygodnia":
                    godzinypracy = godzinypracy.OrderBy(g => g.DzienTygodnia);
                    break;
                case "poczatekpracy_desc":
                    godzinypracy = godzinypracy.OrderByDescending(g => g.PoczatekPracy);
                    break;
                case "poczatekpracy":
                    godzinypracy = godzinypracy.OrderBy(g => g.PoczatekPracy);
                    break;
                case "koniecpracy_desc":
                    godzinypracy = godzinypracy.OrderByDescending(g => g.KoniecPracy);
                    break;
                case "koniecpracy":
                    godzinypracy = godzinypracy.OrderBy(g => g.KoniecPracy);
                    break;
                case "dzial_desc":
                    godzinypracy = godzinypracy.OrderByDescending(g => g.IdDzialNavigation.NazwaDzial);
                    break;
                case "dzial":
                    godzinypracy = godzinypracy.OrderBy(g => g.IdDzialNavigation.NazwaDzial);
                    break;
                default:
                    godzinypracy = godzinypracy.OrderBy(g => g.idGodzinyPracy);
                    break;
            }
            return View(await godzinypracy.ToListAsync());
        }

        // GET: Godzinypracy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var godzinypracy = await _context.Godzinypracy
                .Include(g => g.IdDzialNavigation)
                .FirstOrDefaultAsync(m => m.idGodzinyPracy == id);
            if (godzinypracy == null)
            {
                return NotFound();
            }

            return View(godzinypracy);
        }

        // GET: Godzinypracy/Create
        public IActionResult Create()
        {
            ViewData["IdDzial"] = new SelectList(_context.Dzial, "IdDzial", "NazwaDzial");
            return View();
        }

        // POST: Godzinypracy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idGodzinyPracy,DzienTygodnia,IdDzial,PoczatekPracy,KoniecPracy")] Godzinypracy godzinypracy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(godzinypracy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDzial"] = new SelectList(_context.Dzial, "IdDzial", "NazwaDzial", godzinypracy.IdDzial);
            return View(godzinypracy);
        }

        // GET: Godzinypracy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var godzinypracy = await _context.Godzinypracy.FindAsync(id);
            if (godzinypracy == null)
            {
                return NotFound();
            }
            ViewData["IdDzial"] = new SelectList(_context.Dzial, "IdDzial", "NazwaDzial", godzinypracy.IdDzial);
            return View(godzinypracy);
        }

        // POST: Godzinypracy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idGodzinyPracy,DzienTygodnia,IdDzial,PoczatekPracy,KoniecPracy")] Godzinypracy godzinypracy)
        {
            if (id != godzinypracy.idGodzinyPracy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(godzinypracy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GodzinypracyExists(godzinypracy.idGodzinyPracy))
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
            ViewData["IdDzial"] = new SelectList(_context.Dzial, "IdDzial", "NazwaDzial", godzinypracy.IdDzial);
            return View(godzinypracy);
        }

        // GET: Godzinypracy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var godzinypracy = await _context.Godzinypracy
                .Include(g => g.IdDzialNavigation)
                .FirstOrDefaultAsync(m => m.idGodzinyPracy == id);
            if (godzinypracy == null)
            {
                return NotFound();
            }

            return View(godzinypracy);
        }

        // POST: Godzinypracy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var godzinypracy = await _context.Godzinypracy.FindAsync(id);
            _context.Godzinypracy.Remove(godzinypracy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GodzinypracyExists(int id)
        {
            return _context.Godzinypracy.Any(e => e.idGodzinyPracy == id);
        }
    }
}
