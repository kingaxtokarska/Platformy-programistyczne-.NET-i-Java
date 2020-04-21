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
    public class GodzinypracyController : Controller
    {
        private readonly GodzinypracyService _godzinypracyService;
        private readonly GodzinypracyRepository _godzinypracyRepository;

        public GodzinypracyController(GodzinypracyService godzinypracyService, GodzinypracyRepository godzinypracyRepository)
        {
            _godzinypracyService = godzinypracyService;
            _godzinypracyRepository = godzinypracyRepository;
        }
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            var identity = HttpContext.User;
            var name = identity.Claims.Where(c => c.Type == "Role")
                               .Select(c => c.Value).SingleOrDefault();
            ViewData["Rola"] = name;
            ViewBag.DaynameSortParm = sortOrder == "dzientygodnia" ? "dzientygodnia_desc" : "dzientygodnia";
            ViewBag.StarttimeSortParm = sortOrder == "poczatekpracy" ? "poczatekpracy_desc" : "poczatekpracy";
            ViewBag.StoptimeSortParm = sortOrder == "koniecpracy" ? "koniecpracy_desc" : "koniecpracy";
            ViewBag.SectionSortParm = sortOrder == "dzial" ? "dzial_desc" : "dzial";
            var godzinypracy = await _godzinypracyService.PobierzGodzinypracy(searchString, sortOrder);
            return View(godzinypracy);
        }
        public async Task<IActionResult> Details(int? id)
        {
            var identity = HttpContext.User;
            var name = identity.Claims.Where(c => c.Type == "Role")
                               .Select(c => c.Value).SingleOrDefault();
            ViewData["Rola"] = name;
            if (id == null)
            {
                Log.Information("Nieudana próba wyświetlenia szczegółów godzin pracy");
                return NotFound();
            }
            var godzinypracy = await _godzinypracyRepository.PobierzGodzinypracy(id);
            if (godzinypracy == null)
            {
                Log.Information("Nieudana próba wyświetlenia szczegółów godzin pracy");
                return NotFound();
            }
            return View(godzinypracy);
        }

        public async Task<IActionResult> Create()
        {
            var dzialy = await _godzinypracyRepository.PobierzDzialy();
            ViewData["IdDzial"] = new SelectList(dzialy, "IdDzial", "NazwaDzial");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idGodzinyPracy,DzienTygodnia,IdDzial,PoczatekPracy,KoniecPracy")] Godzinypracy godzinypracy)
        {
            if (ModelState.IsValid)
            {
                await _godzinypracyRepository.DodajGodzinypracy(godzinypracy);
                return RedirectToAction(nameof(Index));
            }
            var dzialy = await _godzinypracyRepository.PobierzDzialy();
            ViewData["IdDzial"] = new SelectList(dzialy, "IdDzial", "NazwaDzial", godzinypracy.IdDzial);
            return View(godzinypracy);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                Log.Warning("Nieudana próba edycji godzin pracy");
                return NotFound();
            }
            var godzinypracy = await _godzinypracyRepository.PobierzGodzinypracy(id);
            if (godzinypracy == null)
            {
                Log.Warning("Nieudana próba edycji godzin pracy");
                return NotFound();
            }
            var dzialy = await _godzinypracyRepository.PobierzDzialy();
            ViewData["IdDzial"] = new SelectList(dzialy, "IdDzial", "NazwaDzial", godzinypracy.IdDzial);
            return View(godzinypracy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idGodzinyPracy, DzienTygodnia, IdDzial, PoczatekPracy, KoniecPracy")] Godzinypracy godzinypracy)
        {
            if (id != godzinypracy.idGodzinyPracy)
            {
                Log.Warning("Nieudana próba edycji godzin pracy");
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var czyZedytowano = await _godzinypracyRepository.EdytujGodzinypracy(godzinypracy);
                if (czyZedytowano == false)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            var dzialy = await _godzinypracyRepository.PobierzDzialy();
            ViewData["IdDzial"] = new SelectList(dzialy, "IdDzial", "NazwaDzial", godzinypracy.IdDzial);
            return View(godzinypracy);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                Log.Warning("Nieudana próba usunięcia godzin pracy");
                return NotFound();
            }
            var godzinypracy = await _godzinypracyRepository.PobierzGodzinypracy(id);
            if (godzinypracy == null)
            {
                Log.Warning("Nieudana próba usunięcia godzin pracy");
                return NotFound();
            }
            return View(godzinypracy);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var godzinypracy = await _godzinypracyService.UsunGodzinypracy(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Worktime(DateTime data)
        {
            var podsumowanie = await _godzinypracyService.PodsumowanieMiesieczne(data);
            return View(podsumowanie);
        }
    }
}