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
    public class PracownikController : Controller
    {
        private readonly PracownikService _pracownikService;
        private readonly PracownikRepository _pracownikRepository;

        public PracownikController(PracownikService pracownikService, PracownikRepository pracownikRepository)
        {
            _pracownikService = pracownikService;
            _pracownikRepository = pracownikRepository;
        }
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            var identity = HttpContext.User;
            var name = identity.Claims.Where(c => c.Type == "Role")
                               .Select(c => c.Value).SingleOrDefault();
            ViewData["Rola"] = name;
            ViewBag.NameSortParm = sortOrder == "imie" ? "imie_desc" : "imie";
            ViewBag.SurnameSortParm = sortOrder == "nazwisko" ? "nazwisko_desc" : "nazwisko";
            ViewBag.PeselSortParm = sortOrder == "pesel" ? "pesel_desc" : "pesel";
            ViewBag.DateSortParm = sortOrder == "datazatrudnienia" ? "datazatrudnienia_desc" : "datazatrudnienia";
            ViewBag.StatusSortParm = sortOrder == "statuszatrudnienia" ? "statuszatrudnienia_desc" : "statuszatrudnienia";
            ViewBag.EmplacementSortParm = sortOrder == "stanowisko" ? "stanowisko_desc" : "stanowisko";
            ViewBag.SectionSortParm = sortOrder == "dzial" ? "dzial_desc" : "dzial";
            var pracownicy = await _pracownikService.PobierzPracownikow(searchString, sortOrder);
            return View(pracownicy);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                Log.Information("Nieudana próba wyświetlenia szczegółów pracownika");
                return NotFound();
            }
            var pracownik = await _pracownikRepository.PobierzPracownika(id);
            if (pracownik == null)
            {
                Log.Information("Nieudana próba wyświetlenia szczegółów pracownika");
                return NotFound();
            }
            return View(pracownik);
        }

        public async Task<IActionResult> Create()
        {
            var stanowiska = await _pracownikRepository.PobierzStanowiska();
            ViewData["IdStanowisko"] = new SelectList(stanowiska, "IdStanowisko", "NazwaStanowisko");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPracownik,Imie,Nazwisko,Pesel,DataZatrudnienia,StatusZatrudnienia,IdStanowisko")] Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                await _pracownikRepository.DodajPracownika(pracownik);
                return RedirectToAction(nameof(Index));
            }
            var stanowiska = await _pracownikRepository.PobierzStanowiska();
            ViewData["IdStanowisko"] = new SelectList(stanowiska, "IdStanowisko", "NazwaStanowisko", pracownik.IdStanowisko);
            return View(pracownik);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                Log.Warning("Nieudana próba edycji pracownika");
                return NotFound();
            }
            var pracownik = await _pracownikRepository.PobierzPracownika(id);
            if (pracownik == null)
            {
                Log.Warning("Nieudana próba edycji pracownika");
                return NotFound();
            }
            var stanowiska = await _pracownikRepository.PobierzStanowiska();
            ViewData["IdStanowisko"] = new SelectList(stanowiska, "IdStanowisko", "NazwaStanowisko", pracownik.IdStanowisko);
            return View(pracownik);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPracownik,Imie,Nazwisko,Pesel,DataZatrudnienia,StatusZatrudnienia,IdStanowisko")] Pracownik pracownik)
        {
            if (id != pracownik.IdPracownik)
            {
                Log.Warning("Nieudana próba edycji pracownika");
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var czyZedytowano = await _pracownikRepository.EdytujPracownika(pracownik);
                if (czyZedytowano == false)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            var stanowiska = await _pracownikRepository.PobierzStanowiska();
            ViewData["IdStanowisko"] = new SelectList(stanowiska, "IdStanowisko", "NazwaStanowisko", pracownik.IdStanowisko);
            return View(pracownik);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                Log.Warning("Nieudana próba usunięcia pracownika");
                return NotFound();
            }
            var pracownik = await _pracownikRepository.PobierzPracownika(id);
            if (pracownik == null)
            {
                Log.Warning("Nieudana próba usunięcia pracownika");
                return NotFound();
            }
            return View(pracownik);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var dzial = await _pracownikService.UsunPracownika(id);
            return RedirectToAction(nameof(Index));
        }
    }
}