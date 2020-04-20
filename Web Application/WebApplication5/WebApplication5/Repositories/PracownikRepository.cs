using FirmaAplikacja.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Repositories
{
    public class PracownikRepository : IPracownikRepository
    {
        public async Task<List<Pracownik>> PobierzPracownikow(string searchString, string sortOrder)
        {
            using (var db = new firmaContext())
            {
                var pracownicy = from p in (db.Pracownik.Include(p => p.IdStanowiskoNavigation).ThenInclude(p => p.IdDzialNavigation))
                                 select p;

                if (!String.IsNullOrEmpty(searchString))
                {
                    pracownicy = pracownicy.Where(p => p.Nazwisko.Contains(searchString)
                                           || p.Imie.Contains(searchString)
                                           || p.Pesel.Contains(searchString)
                                           || p.DataZatrudnienia.Date.ToString().Contains(searchString)
                                           || p.StatusZatrudnienia.Contains(searchString)
                                           || p.IdStanowiskoNavigation.NazwaStanowisko.Contains(searchString)
                                           || p.IdStanowiskoNavigation.IdDzialNavigation.NazwaDzial.Contains(searchString));
                }

                switch (sortOrder)
                {
                    case "nazwisko_desc":
                        pracownicy = pracownicy.OrderByDescending(p => p.Nazwisko);
                        break;
                    case "nazwisko":
                        pracownicy = pracownicy.OrderBy(p => p.Nazwisko);
                        break;
                    case "imie_desc":
                        pracownicy = pracownicy.OrderByDescending(p => p.Imie);
                        break;
                    case "imie":
                        pracownicy = pracownicy.OrderBy(p => p.Imie);
                        break;
                    case "pesel_desc":
                        pracownicy = pracownicy.OrderByDescending(p => p.Pesel);
                        break;
                    case "pesel":
                        pracownicy = pracownicy.OrderBy(p => p.Pesel);
                        break;
                    case "datazatrudnienia":
                        pracownicy = pracownicy.OrderBy(p => p.DataZatrudnienia);
                        break;
                    case "datazatrudnienia_desc":
                        pracownicy = pracownicy.OrderByDescending(p => p.DataZatrudnienia);
                        break;
                    case "statuszatrudnienia":
                        pracownicy = pracownicy.OrderBy(p => p.StatusZatrudnienia);
                        break;
                    case "statuszatrudnienia_desc":
                        pracownicy = pracownicy.OrderByDescending(p => p.StatusZatrudnienia);
                        break;
                    case "stanowisko":
                        pracownicy = pracownicy.OrderBy(p => p.IdStanowiskoNavigation.NazwaStanowisko);
                        break;
                    case "stanowisko_desc":
                        pracownicy = pracownicy.OrderByDescending(p => p.IdStanowiskoNavigation.NazwaStanowisko);
                        break;
                    case "dzial":
                        pracownicy = pracownicy.OrderBy(p => p.IdStanowiskoNavigation.IdDzialNavigation.NazwaDzial);
                        break;
                    case "dzial_desc":
                        pracownicy = pracownicy.OrderByDescending(p => p.IdStanowiskoNavigation.IdDzialNavigation.NazwaDzial);
                        break;
                    default:
                        pracownicy = pracownicy.OrderBy(p => p.IdPracownik);
                        break;
                }
                Log.Information("Wyświetlono pracowników");
                return await pracownicy.ToListAsync();
            }
        }
        public async Task<Pracownik> PobierzPracownika(int? id)
        {
            using (var db = new firmaContext())
            {
                var pracownik = await db.Pracownik.Include(p => p.IdStanowiskoNavigation).ThenInclude(p => p.IdDzialNavigation)
                 .FirstOrDefaultAsync(m => m.IdPracownik == id);
                return pracownik;
            }
        }
        public async Task DodajPracownika(Pracownik pracownik)
        {
            using (var db = new firmaContext())
            {
                db.Add(pracownik);
                pracownik.DataZatrudnienia = DateTime.Now.Date;
                await db.SaveChangesAsync();
                Log.Information("Utworzono nowego pracownika");
            }
        }
        public async Task<bool> EdytujPracownika(Pracownik pracownik)
        {
            using (var db = new firmaContext())
                try
                {
                    db.Update(pracownik);
                    Log.Information("Edytowano pracownika " + pracownik.IdPracownik);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    Log.Error("Próba edycji nieistniejącego pracownika");
                    return false;
                }
            return true;
        }
        public async Task UsunPracownika(Pracownik pracownik)
        {
            using (var db = new firmaContext())
            {
                db.Pracownik.Remove(pracownik);
                await db.SaveChangesAsync();
                Log.Information("Usunięto pracownika " + pracownik.IdPracownik);
            }
        }
        public async Task<List<Stanowisko>> PobierzStanowiska()
        {
            using (var db = new firmaContext())
            {
                return await db.Stanowisko.ToListAsync();   
            }
        }
    }
}