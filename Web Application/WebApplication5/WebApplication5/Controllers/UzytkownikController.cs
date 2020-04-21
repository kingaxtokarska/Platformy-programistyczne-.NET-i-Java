<<<<<<< HEAD
﻿using System;
//<<<<<<< HEAD

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using WebApplication5.Models;

=======
﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;


>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445
namespace WebApplication5.Controllers
{
    public class UzytkownikController : Controller
<<<<<<< HEAD
    {
=======

    {
        private HttpContext _httpContext;

        public UzytkownikController(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext.HttpContext;

        }

>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
<<<<<<< HEAD
        public IActionResult Autherize(Uzytkownik uzytkownik)
        {
            using (var db = new firmaContext())
            {
                var userDetails = db.Uzytkownik.Where(x => x.NazwaUzytkownik == uzytkownik.NazwaUzytkownik && x.HasloUzytkownik == uzytkownik.HasloUzytkownik).FirstOrDefault();
=======
        public async Task<IActionResult> AutherizeAsync(Uzytkownik uzytkownik)

        {
            using (var db = new firmaContext())
            {

                var userDetails = await db.Uzytkownik.Include(x => x.IdRolaNavigation).Where(x => x.Login == uzytkownik.Login && x.Haslo == uzytkownik.Haslo).FirstOrDefaultAsync();


>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445
                if (userDetails == null)
                {
                    uzytkownik.LoginErrorMessage = "Nieprawidłowe hasło albo login";
                    return View("Index", uzytkownik);
                }
                else
                {
<<<<<<< HEAD
                    if (uzytkownik.NazwaUzytkownik == "Prezes") return View("Prezes");
                    else if (uzytkownik.NazwaUzytkownik == "Specjalista") return View("Prezes");
                    else if (uzytkownik.NazwaUzytkownik == "Pracownik") return View("Pracownik");
                    else return RedirectToAction("Index", "Uzytkownik");
                }
            }
        }
        public IActionResult LogOut()
        {
=======
                    var claims = new List<Claim> { new Claim("Role", userDetails.IdRolaNavigation.NazwaRola, ClaimValueTypes.String) };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(identity);
                    Thread.CurrentPrincipal = claimsPrincipal;
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                    _httpContext.User = claimsPrincipal;
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445
            return RedirectToAction("Index", "Uzytkownik");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
<<<<<<< HEAD
    }
}
//=======
/*
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
    */
//>>>>>>> 741e27babacfcacb23ceda90c234e9a2065303f8
=======
    }
}
>>>>>>> adb636e43b8618eb9d95b447a05a85a3f685e445
