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
    public class StanowiskoController : Controller
    {
        private readonly StanowiskoService _stanowiskoService;
        private readonly StanowiskoRepository _stanowiskoRepository;

        public StanowiskoController(StanowiskoService stanowiskoService, StanowiskoRepository stanowiskoRepository)
        {
            _stanowiskoService = stanowiskoService;
            _stanowiskoRepository = stanowiskoRepository;
        }
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            var identity = HttpContext.User;
            var name = identity.Claims.Where(c => c.Type == "Role")
                               .Select(c => c.Value).SingleOrDefault();
            ViewData["Rola"] = name;
            ViewBag.EmplacementSortParm = sortOrder == "stanowisko" ? "stanowisko_desc" : "stanowisko";
            ViewBag.PaymentSortParm = sortOrder == "wynagrodzenie" ? "wynagrodzenie_desc" : "wynagrodzenie";
            ViewBag.SectionSortParm = sortOrder == "dzial" ? "dzial_desc" : "dzial";
            var stanowiska = await _stanowiskoService.PobierzStanowiska(searchString, sortOrder);
            return View(stanowiska);
        }
        public async Task<IActionResult> Details(int? id)
        {
            var identity = HttpContext.User;
            var name = identity.Claims.Where(c => c.Type == "Role")
                               .Select(c => c.Value).SingleOrDefault();
            ViewData["Rola"] = name;
            if (id == null)
            {
                Log.Information("Nieudana próba wyświetlenia szczegółów stanowiska");
                return NotFound();
            }
            var stanowisko = await _stanowiskoRepository.PobierzStanowisko(id);
            if (stanowisko == null)
            {
                Log.Information("Nieudana próba wyświetlenia szczegółów stanowiska");
                return NotFound();
            }
            return View(stanowisko);
        }

        public async Task<IActionResult> Create()
        {
            var dzialy = await _stanowiskoRepository.PobierzDzialy();
            ViewData["IdDzial"] = new SelectList(dzialy, "IdDzial", "NazwaDzial");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStanowisko,NazwaStanowisko,Wynagrodzenie,IdDzial")] Stanowisko stanowisko)
        {
            if (ModelState.IsValid)
            {
                await _stanowiskoRepository.DodajStanowisko(stanowisko);
                return RedirectToAction(nameof(Index));
            }
            var dzialy = await _stanowiskoRepository.PobierzDzialy();
            ViewData["IdDzial"] = new SelectList(dzialy, "IdDzial", "NazwaDzial", stanowisko.IdDzial);
            return View(stanowisko);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                Log.Warning("Nieudana próba edycji stanowiska");
                return NotFound();
            }
            var stanowisko = await _stanowiskoRepository.PobierzStanowisko(id);
            if (stanowisko == null)
            {
                Log.Warning("Nieudana próba edycji stanowiska");
                return NotFound();
            }
            var dzialy = await _stanowiskoRepository.PobierzDzialy();
            ViewData["IdDzial"] = new SelectList(dzialy, "IdDzial", "NazwaDzial", stanowisko.IdDzial);
            return View(stanowisko);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStanowisko,NazwaStanowisko,Wynagrodzenie,IdDzial")] Stanowisko stanowisko)
        {
            if (id != stanowisko.IdStanowisko)
            {
                Log.Warning("Nieudana próba edycji stanowiska");
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var czyZedytowano = await _stanowiskoRepository.EdytujStanowisko(stanowisko);
                if (czyZedytowano == false)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            var dzialy = await _stanowiskoRepository.PobierzDzialy();
            ViewData["IdDzial"] = new SelectList(dzialy, "IdDzial", "NazwaDzial", stanowisko.IdDzial);
            return View(stanowisko);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                Log.Warning("Nieudana próba usunięcia stanowiska");
                return NotFound();
            }
            var stanowisko = await _stanowiskoRepository.PobierzStanowisko(id);
            if (stanowisko == null)
            {
                Log.Warning("Nieudana próba usunięcia stanowiska");
                return NotFound();
            }
            return View(stanowisko);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var stanowisko = await _stanowiskoService.UsunStanowisko(id);
            return RedirectToAction(nameof(Index));
        }
    }
}