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
    public class WejsciaRepository : IWejsciaRepository
    {
        public async Task<List<Wejscia>> PobierzWejscia(string searchString, string sortOrder)
        {
            using (var db = new firmaContext())
            {
                var wejscia = from we in (db.Wejscia.Include(we => we.IdPracownikNavigation))
                              select we;

                if (!String.IsNullOrEmpty(searchString))
                {
                    wejscia = wejscia.Where(we => we.IdPracownikNavigation.Imie.Contains(searchString)
                                           || we.IdPracownikNavigation.Nazwisko.Contains(searchString)
                                           || we.DataWejscia.ToString().Contains(searchString)
                                           || we.GodzinaWejscia.ToString().Contains(searchString));
                }

                switch (sortOrder)
                {
                    case "imie_desc":
                        wejscia = wejscia.OrderByDescending(we => we.IdPracownikNavigation.Imie);
                        break;
                    case "imie":
                        wejscia = wejscia.OrderBy(we => we.IdPracownikNavigation.Imie);
                        break;
                    case "nazwisko_desc":
                        wejscia = wejscia.OrderByDescending(we => we.IdPracownikNavigation.Nazwisko);
                        break;
                    case "nazwisko":
                        wejscia = wejscia.OrderBy(we => we.IdPracownikNavigation.Nazwisko);
                        break;
                    case "data_desc":
                        wejscia = wejscia.OrderByDescending(we => we.DataWejscia);
                        break;
                    case "data":
                        wejscia = wejscia.OrderBy(we => we.DataWejscia);
                        break;
                    case "godzina_desc":
                        wejscia = wejscia.OrderByDescending(we => we.GodzinaWejscia);
                        break;
                    case "godzina":
                        wejscia = wejscia.OrderBy(we => we.GodzinaWejscia);
                        break;
                    default:
                        wejscia = wejscia.OrderBy(we => we.idWejscie);
                        break;
                }
                Log.Information("Wyświetlono wejścia");
                return await wejscia.ToListAsync();
            }
        }
        public async Task<Wejscia> PobierzWejscie(int? id)
        {
            using (var db = new firmaContext())
            {
                var wejscie = await db.Wejscia.Include(we => we.IdPracownikNavigation).ThenInclude(we => we.IdStanowiskoNavigation).ThenInclude(we => we.IdDzialNavigation)
                 .FirstOrDefaultAsync(we => we.idWejscie == id);
                return wejscie;
            }
        }
        public async Task DodajWejscie(Wejscia wejscie)
        {
            using (var db = new firmaContext())
            {
                db.Add(wejscie);
                wejscie.DataWejscia = DateTime.Now.Date;
                wejscie.GodzinaWejscia = DateTime.Now.TimeOfDay;
                wejscie.DzienTygodnia = DateTime.Now.DayOfWeek.ToString();
                await db.SaveChangesAsync();
                Log.Information("Utworzono nowe wejście");
            }
        }
        public async Task<bool> EdytujWejscie(Wejscia wejscie)
        {
            using (var db = new firmaContext())
                try
                {
                    db.Update(wejscie);
                    Log.Information("Edytowano wejscie " + wejscie.idWejscie);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    Log.Error("Próba edycji nieistniejącego wejscia");
                    return false;
                }
            return true;
        }
        public async Task UsunWejscie(Wejscia wejscie)
        {
            using (var db = new firmaContext())
            {
                db.Wejscia.Remove(wejscie);
                await db.SaveChangesAsync();
                Log.Information("Usunięto wejscie " + wejscie.idWejscie);
            }
        }
        public async Task<List<Wejscia>> Spoznienia(DateTime data)
        {
            using (var db = new firmaContext())
            {
                var wejscia = from we in (db.Wejscia.Include(we => we.IdPracownikNavigation).ThenInclude(we => we.IdStanowiskoNavigation).ThenInclude(we => we.IdDzialNavigation))
                              join g in (db.Godzinypracy.Include(we => we.IdDzialNavigation)) on new
                              { X1 = we.IdPracownikNavigation.IdStanowiskoNavigation.IdDzialNavigation.IdDzial, X2 = we.DzienTygodnia }
                              equals new { X1 = g.IdDzialNavigation.IdDzial, X2 = g.DzienTygodnia }
                              where (TimeSpan.Compare(we.GodzinaWejscia, g.PoczatekPracy) == 1 && (we.DataWejscia == data || data == default))
                              select we;

                Log.Information("Kontrola spóźnień");
                return await wejscia.ToListAsync();
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