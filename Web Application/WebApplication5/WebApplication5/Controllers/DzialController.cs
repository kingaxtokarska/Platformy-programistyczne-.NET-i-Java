using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebApplication5.Models;
using WebApplication5.Repositories;
using WebApplication5.Services;

namespace WebApplication5.Controllers
{
    public class DzialController : Controller
    {
        private readonly DzialService _dzialService;
        private readonly DzialRepository _dzialRepository;

        public DzialController(DzialService dzialService, DzialRepository dzialRepository)
        {
            _dzialService = dzialService;
            _dzialRepository = dzialRepository;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            var identity = HttpContext.User;
            var name = identity.Claims.Where(c => c.Type == "Role")
                               .Select(c => c.Value).SingleOrDefault();
            ViewData["Rola"] = name;
            ViewBag.SectionSortParm = sortOrder == "dzial" ? "dzial_desc" : "dzial";
            var dzialy = await _dzialService.PobierzDzialy(searchString, sortOrder);
            return View(dzialy);
        }
        public async Task<IActionResult> Details(int? id)
        {
            var identity = HttpContext.User;
            var name = identity.Claims.Where(c => c.Type == "Role")
                               .Select(c => c.Value).SingleOrDefault();
            ViewData["Rola"] = name;
            if (id == null)
            {
                Log.Information("Nieudana próba wyświetlenia szczegółów działu");
                return NotFound();
            }
            var dzial = await _dzialRepository.PobierzDzial(id);
            if (dzial == null)
            {
                Log.Information("Nieudana próba wyświetlenia szczegółów działu");
                return NotFound();
            }
            return View(dzial);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDzial,NazwaDzial")] Dzial dzial)
        {
            if (ModelState.IsValid)
            {
                await _dzialRepository.DodajDzial(dzial);
                return RedirectToAction(nameof(Index));
            }
            return View(dzial);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                Log.Warning("Nieudana próba edycji działu");
                return NotFound();
            }
            var dzial = await _dzialRepository.PobierzDzial(id);
            if (dzial == null)
            {
                Log.Warning("Nieudana próba edycji działu");
                return NotFound();
            }
            return View(dzial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDzial,NazwaDzial")] Dzial dzial)
        {
            if (id != dzial.IdDzial)
            {
                Log.Warning("Nieudana próba edycji działu");
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var czyZedytowano = await _dzialRepository.EdytujDzial(dzial);
                if (czyZedytowano == false)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dzial);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                Log.Warning("Nieudana próba usunięcia działu");
                return NotFound();
            }
            var dzial = await _dzialRepository.PobierzDzial(id);
            if (dzial == null)
            {
                Log.Warning("Nieudana próba usunięcia działu");
                return NotFound();
            }
            return View(dzial);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var dzial = await _dzialService.UsunDzial(id);
            return RedirectToAction(nameof(Index));
        }

    }
}