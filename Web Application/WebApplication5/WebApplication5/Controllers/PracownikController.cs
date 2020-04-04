using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class PracownikController : Controller
    {
        private readonly firmaContext _context;

        public PracownikController(firmaContext context)
        {
            _context = context;
        }

        // GET: Pracownik
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = sortOrder == "imie" ? "imie_desc" : "imie";
            ViewBag.SurnameSortParm = sortOrder == "nazwisko" ? "nazwisko_desc" : "nazwisko";
            ViewBag.PeselSortParm = sortOrder == "pesel" ? "pesel_desc" : "pesel";
            ViewBag.DateSortParm = sortOrder == "datazatrudnienia" ? "datazatrudnienia_desc" : "datazatrudnienia";
            ViewBag.StatusSortParm = sortOrder == "statuszatrudnienia" ? "statuszatrudnienia_desc" : "statuszatrudnienia";
            ViewBag.EmplacementSortParm = sortOrder == "stanowisko" ? "stanowisko_desc" : "stanowisko";
            ViewBag.SectionSortParm = sortOrder == "dzial" ? "dzial_desc" : "dzial";

            var pracownicy = from p in (_context.Pracownik.Include(p => p.IdStanowiskoNavigation))
                select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                pracownicy = pracownicy.Where(p => p.Nazwisko.Contains(searchString)
                                       || p.Imie.Contains(searchString)
                                       || p.Pesel.Contains(searchString)
                                       || p.DataZatrudnienia.Date.ToString().Contains(searchString)
                                       || p.StatusZatrudnienia.Contains(searchString)
                                       || p.IdStanowiskoNavigation.NazwaStanowisko.Contains(searchString)
                                       || p.IdStanowiskoNavigation.IdDzialNavigation.NazwaDzial.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "nazwisko_desc":
                    pracownicy = pracownicy.OrderByDescending(p => p.Nazwisko);
                    break;
                case "nazwisko":
                    pracownicy = pracownicy.OrderBy(p => p.Nazwisko);
                    break;
                case "imie_desc":
                    pracownicy = pracownicy.OrderByDescending(p => p.Imie);
                    break;
                case "imie":
                    pracownicy = pracownicy.OrderBy(p => p.Imie);
                    break;
                case "pesel_desc":
                    pracownicy = pracownicy.OrderByDescending(p => p.Pesel);
                    break;
                case "pesel":
                    pracownicy = pracownicy.OrderBy(p => p.Pesel);
                    break;
                case "datazatrudnienia":
                    pracownicy = pracownicy.OrderBy(p => p.DataZatrudnienia);
                    break;
                case "datazatrudnienia_desc":
                    pracownicy = pracownicy.OrderByDescending(p => p.DataZatrudnienia);
                    break;
                case "statuszatrudnienia":
                    pracownicy = pracownicy.OrderBy(p => p.StatusZatrudnienia);
                    break;
                case "statuszatrudnienia_desc":
                    pracownicy = pracownicy.OrderByDescending(p => p.StatusZatrudnienia);
                    break;
                case "stanowisko":
                    pracownicy = pracownicy.OrderBy(p => p.IdStanowiskoNavigation.NazwaStanowisko);
                    break;
                case "stanowisko_desc":
                    pracownicy = pracownicy.OrderByDescending(p => p.IdStanowiskoNavigation.NazwaStanowisko);
                    break;
                case "dzial":
                    pracownicy = pracownicy.OrderBy(p => p.IdStanowiskoNavigation.IdDzialNavigation.NazwaDzial);
                    break;
                case "dzial_desc":
                    pracownicy = pracownicy.OrderByDescending(p => p.IdStanowiskoNavigation.IdDzialNavigation.NazwaDzial);
                    break;
                default:
                    pracownicy = pracownicy.OrderBy(p => p.IdPracownik);
                    break;
            }
            return View(await pracownicy.ToListAsync()); 
            
            //var firmaContext = _context.Pracownik.Include(p => p.IdStanowiskoNavigation);
                //return View(await firmaContext.ToListAsync());
        }


        // GET: Pracownik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pracownik = await _context.Pracownik
                .Include(p => p.IdStanowiskoNavigation)
                .FirstOrDefaultAsync(m => m.IdPracownik == id);
            if (pracownik == null)
            {
                return NotFound();
            }

            return View(pracownik);
        }

        // GET: Pracownik/Create
        public IActionResult Create()
        {
            ViewData["IdStanowisko"] = new SelectList(_context.Stanowisko, "IdStanowisko", "NazwaStanowisko");
            return View();
        }

        // POST: Pracownik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPracownik,Imie,Nazwisko,Pesel,DataZatrudnienia,StatusZatrudnienia,IdStanowisko")] Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pracownik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdStanowisko"] = new SelectList(_context.Stanowisko, "IdStanowisko", "NazwaStanowisko", pracownik.IdStanowisko);
            return View(pracownik);
        }

        // GET: Pracownik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pracownik = await _context.Pracownik.FindAsync(id);
            if (pracownik == null)
            {
                return NotFound();
            }
            ViewData["IdStanowisko"] = new SelectList(_context.Stanowisko, "IdStanowisko", "NazwaStanowisko", pracownik.IdStanowisko);
            return View(pracownik);
        }

        // POST: Pracownik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPracownik,Imie,Nazwisko,Pesel,DataZatrudnienia,StatusZatrudnienia,IdStanowisko")] Pracownik pracownik)
        {
            if (id != pracownik.IdPracownik)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pracownik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PracownikExists(pracownik.IdPracownik))
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
            ViewData["IdStanowisko"] = new SelectList(_context.Stanowisko, "IdStanowisko", "NazwaStanowisko", pracownik.IdStanowisko);
            return View(pracownik);
        }

        // GET: Pracownik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pracownik = await _context.Pracownik
                .Include(p => p.IdStanowiskoNavigation)
                .FirstOrDefaultAsync(m => m.IdPracownik == id);
            if (pracownik == null)
            {
                return NotFound();
            }

            return View(pracownik);
        }

        // POST: Pracownik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pracownik = await _context.Pracownik.FindAsync(id);
            _context.Pracownik.Remove(pracownik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PracownikExists(int id)
        {
            return _context.Pracownik.Any(e => e.IdPracownik == id);
        }
    }
}
