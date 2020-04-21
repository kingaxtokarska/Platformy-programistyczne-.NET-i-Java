using System.Collections.Generic;
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

namespace WebApplication5.Controllers
{
    public class UzytkownikController : Controller
    {
        private HttpContext _httpContext;
        public UzytkownikController(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext.HttpContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AutherizeAsync(Uzytkownik uzytkownik)
        {
            using (var db = new firmaContext())
            {
                var userDetails = await db.Uzytkownik.Include(x => x.IdRolaNavigation).Where(x => x.Login == uzytkownik.Login && x.Haslo == uzytkownik.Haslo).FirstOrDefaultAsync();
                if (userDetails == null)
                {
                    uzytkownik.LoginErrorMessage = "Nieprawidłowe hasło albo login";
                    return View("Index", uzytkownik);
                }
                else
                {
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
            return RedirectToAction("Index", "Uzytkownik");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}