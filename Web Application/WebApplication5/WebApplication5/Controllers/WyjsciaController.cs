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
    public class WyjsciaController : Controller
    {
        private readonly WyjsciaService _wyjsciaService;
        private readonly WyjsciaRepository _wyjsciaRepository;

        public WyjsciaController(WyjsciaService wyjsciaService, WyjsciaRepository wyjsciaRepository)
        {
            _wyjsciaService = wyjsciaService;
            _wyjsciaRepository = wyjsciaRepository;
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
            var wyjscia = await _wyjsciaService.PobierzWyjscia(searchString, sortOrder);
            return View(wyjscia);
        }
        public async Task<IActionResult> Details(int? id)
        {
            var identity = HttpContext.User;
            var name = identity.Claims.Where(c => c.Type == "Role")
                               .Select(c => c.Value).SingleOrDefault();
            ViewData["Rola"] = name;
            if (id == null)
            {
                Log.Information("Nieudana próba wyświetlenia szczegółów wyjscia");
                return NotFound();
            }
            var wyjscie = await _wyjsciaRepository.PobierzWyjscie(id);
            if (wyjscie == null)
            {
                Log.Information("Nieudana próba wyświetlenia szczegółów wyjscia");
                return NotFound();
            }
            return View(wyjscie);
        }

        public async Task<IActionResult> Create()
        {
            var pracownicy = await _wyjsciaRepository.PobierzPracownikow();
            ViewData["IdPracownik"] = new SelectList(pracownicy, "IdPracownik", "IdPracownik");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idWyjscie,IdPracownik,DataWyjscia,GodzinaWyjscia")] Wyjscia wyjscie)
        {
            if (ModelState.IsValid)
            {
                await _wyjsciaRepository.DodajWyjscie(wyjscie);
                return RedirectToAction(nameof(Create));
            }
            var pracownicy = await _wyjsciaRepository.PobierzPracownikow();
            ViewData["IdPracownik"] = new SelectList(pracownicy, "IdPracownik", "IdPracownik", wyjscie.IdPracownik);
            return View(wyjscie);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                Log.Warning("Nieudana próba edycji wyjscia");
                return NotFound();
            }
            var wyjscie = await _wyjsciaRepository.PobierzWyjscie(id);
            if (wyjscie == null)
            {
                Log.Warning("Nieudana próba edycji wyjscia");
                return NotFound();
            }
            var pracownicy = await _wyjsciaRepository.PobierzPracownikow();
            ViewData["IdPracownik"] = new SelectList(pracownicy, "IdPracownik", "IdPracownik", wyjscie.IdPracownik);
            return View(wyjscie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idWyjscie,IdPracownik,DataWyjscia,GodzinaWyjscia")] Wyjscia wyjscie)
        {
            if (id != wyjscie.idWyjscie)
            {
                Log.Warning("Nieudana próba edycji wyjscia");
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var czyZedytowano = await _wyjsciaRepository.EdytujWyjscie(wyjscie);
                if (czyZedytowano == false)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            var pracownicy = await _wyjsciaRepository.PobierzPracownikow();
            ViewData["IdPracownik"] = new SelectList(pracownicy, "IdPracownik", "IdPracownik", wyjscie.IdPracownik);
            return View(wyjscie);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                Log.Warning("Nieudana próba usunięcia wyjscia");
                return NotFound();
            }
            var wyjscie = await _wyjsciaRepository.PobierzWyjscie(id);
            if (wyjscie == null)
            {
                Log.Warning("Nieudana próba usunięcia wyjscia");
                return NotFound();
            }
            return View(wyjscie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var wyjscie = await _wyjsciaService.UsunWyjscie(id);
            return RedirectToAction(nameof(Index));
        }
    }
}