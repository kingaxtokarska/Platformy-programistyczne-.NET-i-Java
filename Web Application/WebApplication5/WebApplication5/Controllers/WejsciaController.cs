using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;
using WebApplication5.Models;
using WebApplication5.Repositories;
using WebApplication5.Services;

namespace WebApplication5.Controllers
{
    public class WejsciaController : Controller
    {
        private readonly WejsciaService _wejsciaService;
        private readonly WejsciaRepository _wejsciaRepository;

        public WejsciaController(WejsciaService wejsciaService, WejsciaRepository wejsciaRepository)
        {
            _wejsciaService = wejsciaService;
            _wejsciaRepository = wejsciaRepository;
        }
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            var identity = HttpContext.User;
            var name = identity.Claims.Where(c => c.Type == "Role")
                               .Select(c => c.Value).SingleOrDefault();
            ViewData["Rola"] = name;
            ViewBag.NameSortParm = sortOrder == "imie" ? "imie_desc" : "imie";
            ViewBag.SurnameSortParm = sortOrder == "nazwisko" ? "nazwisko_desc" : "nazwisko";
            ViewBag.DateSortParm = sortOrder == "data" ? "data_desc" : "data";
            ViewBag.TimeSortParm = sortOrder == "godzina" ? "godzina_desc" : "godzina";
            var wejscia = await _wejsciaService.PobierzWejscia(searchString, sortOrder);
            return View(wejscia);
        }
        public async Task<IActionResult> Details(int? id)
        {
            var identity = HttpContext.User;
            var name = identity.Claims.Where(c => c.Type == "Role")
                               .Select(c => c.Value).SingleOrDefault();
            ViewData["Rola"] = name;
            if (id == null)
            {
                Log.Information("Nieudana próba wyświetlenia szczegółów wejscia");
                return NotFound();
            }
            var wejscie = await _wejsciaRepository.PobierzWejscie(id);
            if (wejscie == null)
            {
                Log.Information("Nieudana próba wyświetlenia szczegółów wejscia");
                return NotFound();
            }
            return View(wejscie);
        }

        public async Task<IActionResult> Create()
        {
            var pracownicy = await _wejsciaRepository.PobierzPracownikow();
            ViewData["IdPracownik"] = new SelectList(pracownicy, "IdPracownik", "IdPracownik");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idWejscie,IdPracownik,DataWejscia,GodzinaWejscia")] Wejscia wejscie)
        {
            if (ModelState.IsValid)
            {
                await _wejsciaRepository.DodajWejscie(wejscie);
                return RedirectToAction(nameof(Create));
            }
            var pracownicy = await _wejsciaRepository.PobierzPracownikow();
            ViewData["IdPracownik"] = new SelectList(pracownicy, "IdPracownik", "IdPracownik", wejscie.IdPracownik);
            return View(wejscie);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                Log.Warning("Nieudana próba edycji wejscia");
                return NotFound();
            }
            var wejscie = await _wejsciaRepository.PobierzWejscie(id);
            if (wejscie == null)
            {
                Log.Warning("Nieudana próba edycji wejscia");
                return NotFound();
            }
            var pracownicy = await _wejsciaRepository.PobierzPracownikow();
            ViewData["IdPracownik"] = new SelectList(pracownicy, "IdPracownik", "IdPracownik", wejscie.IdPracownik);
            return View(wejscie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idWejscie,IdPracownik,DataWejscia,GodzinaWejscia")] Wejscia wejscie)
        {
            if (id != wejscie.idWejscie)
            {
                Log.Warning("Nieudana próba edycji wejscia");
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var czyZedytowano = await _wejsciaRepository.EdytujWejscie(wejscie);
                if (czyZedytowano == false)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            var pracownicy = await _wejsciaRepository.PobierzPracownikow();
            ViewData["IdPracownik"] = new SelectList(pracownicy, "IdPracownik", "IdPracownik", wejscie.IdPracownik);
            return View(wejscie);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                Log.Warning("Nieudana próba usunięcia wejscia");
                return NotFound();
            }
            var wejscie = await _wejsciaRepository.PobierzWejscie(id);
            if (wejscie == null)
            {
                Log.Warning("Nieudana próba usunięcia wejscia");
                return NotFound();
            }
            return View(wejscie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var wejscie = await _wejsciaService.UsunWejscie(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delays(DateTime data)
        {
            var wejscia = await _wejsciaService.Spoznienia(data);
            return View(wejscia);
        }
    }
}