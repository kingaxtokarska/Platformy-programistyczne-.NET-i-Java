using FirmaAplikacja.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Repositories
{
    public class WyjsciaRepository : IWyjsciaRepository
    {
        public async Task<List<Wyjscia>> PobierzWyjscia(string searchString, string sortOrder)
        {
            using (var db = new firmaContext())
            {
                var wyjscia = from wy in (db.Wyjscia.Include(wy => wy.IdPracownikNavigation))
                              select wy;

                if (!String.IsNullOrEmpty(searchString))
                {
                    wyjscia = wyjscia.Where(wy => wy.IdPracownikNavigation.Imie.Contains(searchString)
                                           || wy.IdPracownikNavigation.Nazwisko.Contains(searchString)
                                           || wy.DataWyjscia.ToString().Contains(searchString)
                                           || wy.GodzinaWyjscia.ToString().Contains(searchString));
                }

                switch (sortOrder)
                {
                    case "imie_desc":
                        wyjscia = wyjscia.OrderByDescending(wy => wy.IdPracownikNavigation.Imie);
                        break;
                    case "imie":
                        wyjscia = wyjscia.OrderBy(wy => wy.IdPracownikNavigation.Imie);
                        break;
                    case "nazwisko_desc":
                        wyjscia = wyjscia.OrderByDescending(wy => wy.IdPracownikNavigation.Nazwisko);
                        break;
                    case "nazwisko":
                        wyjscia = wyjscia.OrderBy(wy => wy.IdPracownikNavigation.Nazwisko);
                        break;
                    case "data_desc":
                        wyjscia = wyjscia.OrderByDescending(wy => wy.DataWyjscia);
                        break;
                    case "data":
                        wyjscia = wyjscia.OrderBy(wy => wy.DataWyjscia);
                        break;
                    case "godzina_desc":
                        wyjscia = wyjscia.OrderByDescending(wy => wy.GodzinaWyjscia);
                        break;
                    case "godzina":
                        wyjscia = wyjscia.OrderBy(wy => wy.GodzinaWyjscia);
                        break;
                    default:
                        wyjscia = wyjscia.OrderBy(wy => wy.idWyjscie);
                        break;
                }
                Log.Information("Wyświetlono wyjścia");
                return await wyjscia.ToListAsync();
            }
        }
        public async Task<Wyjscia> PobierzWyjscie(int? id)
        {
            using (var db = new firmaContext())
            {
                var wyjscie = await db.Wyjscia.Include(we => we.IdPracownikNavigation).ThenInclude(we => we.IdStanowiskoNavigation).ThenInclude(we => we.IdDzialNavigation)
                 .FirstOrDefaultAsync(m => m.idWyjscie == id);
                return wyjscie;
            }
        }
        public async Task DodajWyjscie(Wyjscia wyjscie)
        {
            using (var db = new firmaContext())
            {
                db.Add(wyjscie);
                wyjscie.DataWyjscia = DateTime.Now.Date;
                wyjscie.GodzinaWyjscia = DateTime.Now.TimeOfDay;
                wyjscie.DzienTygodnia = DateTime.Now.DayOfWeek.ToString();
                await db.SaveChangesAsync();
                Log.Information("Utworzono nowe wyjscie");
            }
        }
        public async Task<bool> EdytujWyjscie(Wyjscia wyjscie)
        {
            using (var db = new firmaContext())
                try
                {
                    db.Update(wyjscie);
                    Log.Information("Edytowano wyjscie " + wyjscie.idWyjscie);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    Log.Error("Próba edycji nieistniejącego wyjscia");
                    return false;
                }
            return true;
        }
        public async Task UsunWyjscie(Wyjscia wyjscie)
        {
            using (var db = new firmaContext())
            {
                db.Wyjscia.Remove(wyjscie);
                await db.SaveChangesAsync();
                Log.Information("Usunięto wyjscie " + wyjscie.idWyjscie);
            }
        }
        public async Task<List<Pracownik>> PobierzPracownikow()
        {
            using (var db = new firmaContext())
            {
                return await db.Pracownik.ToListAsync();
            }
        }
    }
}