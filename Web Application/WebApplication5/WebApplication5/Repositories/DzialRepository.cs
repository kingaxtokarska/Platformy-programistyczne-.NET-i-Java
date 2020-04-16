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
    public class DzialRepository : IDzialRepository
    {
        public async Task<List<Dzial>> PobierzDzialy(string searchString, string sortOrder)
        {
            using (var db = new firmaContext())
            {
                var dzialy = from d in (db.Dzial)
                             select d;
                if (!String.IsNullOrEmpty(searchString))
                {
                    dzialy = dzialy.Where(s => s.NazwaDzial.Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "dzial_desc":
                        dzialy = dzialy.OrderByDescending(d => d.NazwaDzial);
                        break;
                    case "dzial":
                        dzialy = dzialy.OrderBy(d => d.NazwaDzial);
                        break;
                    default:
                        dzialy = dzialy.OrderBy(d => d.IdDzial);
                        break;
                }

                Log.Information("Wyświetlono działy");
                return await dzialy.ToListAsync();
            }
        }
        public async Task<Dzial> PobierzDzial(int? id)
        {
            using (var db = new firmaContext())
            {
                var dzial = await db.Dzial.FirstOrDefaultAsync(m => m.IdDzial == id);
                return dzial;
            }
        }
        public async Task DodajDzial(Dzial dzial)
        {
            using (var db = new firmaContext())
            {
                db.Add(dzial);
                await db.SaveChangesAsync();
            }
            Log.Information("Utworzono nowy dział");
        }
        public async Task<bool> EdytujDzial(Dzial dzial)
        {
            using (var db = new firmaContext())
            {
                try
                {
                    db.Update(dzial);
                    Log.Information("Edytowano dział " + dzial.IdDzial);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    Log.Error("Próba edycji nieistniejącego działu");
                    return false;
                }
                return true;
            }
        }
        public async Task UsunDzial(Dzial dzial)
        {
            using (var db = new firmaContext())
            {
                db.Dzial.Remove(dzial);
                await db.SaveChangesAsync();
            }
            Log.Information("Usunięto dział " + dzial.IdDzial);
        }
    }
}