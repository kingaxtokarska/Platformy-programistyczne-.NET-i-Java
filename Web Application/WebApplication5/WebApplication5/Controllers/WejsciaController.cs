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

        public async Task<IActionResult> Delays(DateTime data)
        {

            var wejscia = from we in (_context.Wejscia.Include(we => we.IdPracownikNavigation).ThenInclude(we => we.IdStanowiskoNavigation).ThenInclude(we => we.IdDzialNavigation))
                          join g in (_context.Godzinypracy.Include(we => we.IdDzialNavigation)) on new
                          { X1 = we.IdPracownikNavigation.IdStanowiskoNavigation.IdDzialNavigation.IdDzial, X2 = we.DzienTygodnia }
                          equals new { X1 = g.IdDzialNavigation.IdDzial, X2 = g.DzienTygodnia }
                          where (TimeSpan.Compare(we.GodzinaWejscia, g.PoczatekPracy) == 1 && (we.DataWejscia == data || data == default)) 
                          select we;
            
            return View(await wejscia.ToListAsync());
        }

        public async Task<IActionResult> Worktime(DateTime data)
        {
            int rok = data.Year;
            int miesiac = data.Month;
            var godzinypracy = from we in (_context.Wejscia.Include(we => we.IdPracownikNavigation).
                                    ThenInclude(we => we.IdStanowiskoNavigation).
                                    ThenInclude(we => we.IdDzialNavigation))
                               join g in (_context.Godzinypracy) on
                               we.IdPracownikNavigation.IdStanowiskoNavigation.IdDzialNavigation.IdDzial
                               equals g.IdDzial
                               join wy in (_context.Wyjscia) on
                               we.IdPracownikNavigation.IdPracownik
                               equals wy.IdPracownik
                               where (we.DzienTygodnia == g.DzienTygodnia && wy.DzienTygodnia == g.DzienTygodnia && we.DataWejscia.Year == rok && we.DataWejscia.Month == miesiac)
                               select new { wejscia = we, godziny = g, wyjscia = wy };

            List<Podsumowanie> podsumowanielista = new List<Podsumowanie>();
            foreach (var praca in godzinypracy)
            {
                var poczatekpracy = praca.wejscia.GodzinaWejscia;
                if (praca.wejscia.GodzinaWejscia < praca.godziny.PoczatekPracy)
                {
                    poczatekpracy = praca.godziny.PoczatekPracy;
                }
                var koniecpracy = praca.wyjscia.GodzinaWyjscia;
                var nadgodziny = TimeSpan.Zero;
                if (praca.wyjscia.GodzinaWyjscia > praca.godziny.KoniecPracy)
                {
                    koniecpracy = praca.godziny.KoniecPracy;
                    nadgodziny = praca.wyjscia.GodzinaWyjscia - praca.godziny.KoniecPracy;
                }
                var czaspracy = koniecpracy - poczatekpracy;
                podsumowanielista.Add(new Podsumowanie()
                {
                    IdPracownik = praca.wejscia.IdPracownik,
                    Imie = praca.wejscia.IdPracownikNavigation.Imie,
                    Nazwisko = praca.wejscia.IdPracownikNavigation.Nazwisko,
                    CzasPracy = czaspracy.TotalHours,
                    Nadgodziny = nadgodziny.TotalHours,
                    Stawka = praca.wejscia.IdPracownikNavigation.IdStanowiskoNavigation.Wynagrodzenie
                }) ;
            }
            var podsumowanie = from p in podsumowanielista
                               group p by p.IdPracownik into p2
                               select new Podsumowanie()
                               {
                                   IdPracownik = p2.ElementAt(0).IdPracownik,
                                   Imie = p2.ElementAt(0).Imie,
                                   Nazwisko = p2.ElementAt(0).Nazwisko,
                                   CzasPracy = p2.Sum(x => x.CzasPracy),
                                   Nadgodziny = p2.Sum(x => x.Nadgodziny),
                                   Wynagrodzenie = p2.Sum(x => x.CzasPracy) * p2.ElementAt(0).Stawka + p2.Sum(x => x.Nadgodziny) * p2.ElementAt(0).Stawka * 1.5,
                                   WynagrodzenieEuro = p2.Sum(x => x.WynagrodzenieEuro)
                               };
                               
            return View(podsumowanie);
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
                wejscia.DataWejscia = DateTime.Now.Date;
                wejscia.GodzinaWejscia = DateTime.Now.TimeOfDay;
                wejscia.DzienTygodnia = DateTime.Now.DayOfWeek.ToString();
                await _context.SaveChangesAsync();
                Log.Information("Hfasfn afkla!");
                return RedirectToAction(nameof(Index), "Home");
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
