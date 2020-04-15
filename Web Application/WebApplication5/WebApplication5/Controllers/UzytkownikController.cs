using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class UzytkownikController : Controller
    {
        private readonly firmaContext _context;

        public UzytkownikController(firmaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Autherize(WebApplication5.Models.Uzytkownik uzytkownik)
        {
            var userDetails = _context.Uzytkownik.Where(x => x.NazwaUzytkownik == uzytkownik.NazwaUzytkownik && x.HasloUzytkownik == uzytkownik.HasloUzytkownik).FirstOrDefault();
            if (userDetails == null)
            {
                uzytkownik.LoginErrorMessage = "Nieprawidłowe hasło albo login";
                return View("Index", uzytkownik);
            }
            else
            {
                if (uzytkownik.NazwaUzytkownik == "Prezes") return RedirectToAction("Index", "Dzial");
                else if (uzytkownik.NazwaUzytkownik == "Specjalista") return RedirectToAction("Index", "Godzinypracy");
                else return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult LogOut ()
        {
            return RedirectToAction("Index", "Uzytkownik");
        }
    }
}