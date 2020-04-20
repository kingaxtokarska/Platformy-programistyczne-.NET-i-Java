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
    public class StanowiskoRepository : IStanowiskoRepository
    {
        public async Task<List<Stanowisko>> PobierzStanowiska(string searchString, string sortOrder)
        {
            using (var db = new firmaContext())
            {
                var stanowiska = from s in (db.Stanowisko.Include(s => s.IdDzialNavigation))
                                 select s;

                if (!String.IsNullOrEmpty(searchString))
                {
                    stanowiska = stanowiska.Where(s => s.NazwaStanowisko.Contains(searchString)
                                           || s.Wynagrodzenie.ToString().Contains(searchString)
                                           || s.IdDzialNavigation.NazwaDzial.Contains(searchString));
                }

                switch (sortOrder)
                {
                    case "stanowisko_desc":
                        stanowiska = stanowiska.OrderByDescending(s => s.NazwaStanowisko);
                        break;
                    case "stanowisko":
                        stanowiska = stanowiska.OrderBy(s => s.NazwaStanowisko);
                        break;
                    case "wynarodzenie_desc":
                        stanowiska = stanowiska.OrderByDescending(s => s.Wynagrodzenie);
                        break;
                    case "wynagrodzenie":
                        stanowiska = stanowiska.OrderBy(s => s.Wynagrodzenie);
                        break;
                    case "dzial_desc":
                        stanowiska = stanowiska.OrderByDescending(s => s.IdDzialNavigation.NazwaDzial);
                        break;
                    case "dzial":
                        stanowiska = stanowiska.OrderBy(s => s.IdDzialNavigation.NazwaDzial);
                        break;
                    default:
                        stanowiska = stanowiska.OrderBy(s => s.IdStanowisko);
                        break;
                }
                Log.Information("Wyświetlono stanowiska");
                return await stanowiska.ToListAsync();
            }
        }
        public async Task<Stanowisko> PobierzStanowisko(int? id)
        {
            using (var db = new firmaContext())
            {
                var stanowisko = await db.Stanowisko.Include(s => s.IdDzialNavigation)
                 .FirstOrDefaultAsync(m => m.IdStanowisko == id);
                return stanowisko;
            }
        }
        public async Task DodajStanowisko(Stanowisko stanowisko)
        {
            using (var db = new firmaContext())
            {
                db.Add(stanowisko);
                await db.SaveChangesAsync();
                Log.Information("Utworzono nowe stanowisko");
            }
        }
        public async Task<bool> EdytujStanowisko(Stanowisko stanowisko)
        {
            using (var db = new firmaContext())
                try
                {
                    db.Update(stanowisko);
                    Log.Information("Edytowano stanowisko " + stanowisko.IdStanowisko);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    Log.Error("Próba edycji nieistniejącego stanowiska");
                    return false;
                }
            return true;
        }
        public async Task UsunStanowisko(Stanowisko stanowisko)
        {
            using (var db = new firmaContext())
            {
                db.Stanowisko.Remove(stanowisko);
                await db.SaveChangesAsync();
                Log.Information("Usunięto stanowisko " + stanowisko.IdStanowisko);
            }
        }
        public async Task<List<Dzial>> PobierzDzialy()
        {
            using (var db = new firmaContext())
            {
                return await db.Dzial.ToListAsync();
            }
        }
    }
}