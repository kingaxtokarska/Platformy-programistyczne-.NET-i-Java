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
    public class GodzinypracyRepository : IGodzinypracyRepository
    {
        public async Task<List<Godzinypracy>> PobierzGodzinypracy(string searchString, string sortOrder)
        {
            using (var db = new firmaContext())
            {
                var godzinypracy = from g in (db.Godzinypracy.Include(g => g.IdDzialNavigation))
                                   select g;

                if (!String.IsNullOrEmpty(searchString))
                {
                    godzinypracy = godzinypracy.Where(g => g.DzienTygodnia.Contains(searchString)
                                           || g.PoczatekPracy.ToString().Contains(searchString)
                                           || g.KoniecPracy.ToString().Contains(searchString)
                                           || g.IdDzialNavigation.NazwaDzial.Contains(searchString));
                }

                switch (sortOrder)
                {
                    case "dzientygodnia_desc":
                        godzinypracy = godzinypracy.OrderByDescending(g => g.DzienTygodnia);
                        break;
                    case "dzientygodnia":
                        godzinypracy = godzinypracy.OrderBy(g => g.DzienTygodnia);
                        break;
                    case "poczatekpracy_desc":
                        godzinypracy = godzinypracy.OrderByDescending(g => g.PoczatekPracy);
                        break;
                    case "poczatekpracy":
                        godzinypracy = godzinypracy.OrderBy(g => g.PoczatekPracy);
                        break;
                    case "koniecpracy_desc":
                        godzinypracy = godzinypracy.OrderByDescending(g => g.KoniecPracy);
                        break;
                    case "koniecpracy":
                        godzinypracy = godzinypracy.OrderBy(g => g.KoniecPracy);
                        break;
                    case "dzial_desc":
                        godzinypracy = godzinypracy.OrderByDescending(g => g.IdDzialNavigation.NazwaDzial);
                        break;
                    case "dzial":
                        godzinypracy = godzinypracy.OrderBy(g => g.IdDzialNavigation.NazwaDzial);
                        break;
                    default:
                        godzinypracy = godzinypracy.OrderBy(g => g.idGodzinyPracy);
                        break;
                }
                Log.Information("Wyświetlono godziny pracy");
                return await godzinypracy.ToListAsync();
            }
        }
        public async Task<Godzinypracy> PobierzGodzinypracy(int? id)
        {
            using (var db = new firmaContext())
            {
                var godzinypracy = await db.Godzinypracy.Include(g => g.IdDzialNavigation)
                 .FirstOrDefaultAsync(m => m.idGodzinyPracy == id);
                return godzinypracy;
            }
        }
        public async Task DodajGodzinypracy(Godzinypracy godzinypracy)
        {
            using (var db = new firmaContext())
            {
                db.Add(godzinypracy);
                await db.SaveChangesAsync();
                Log.Information("Utworzono nowe godziny pracy");
            }
        }
        public async Task<bool> EdytujGodzinypracy(Godzinypracy godzinypracy)
        {
            using (var db = new firmaContext())
                try
                {
                    db.Update(godzinypracy);
                    Log.Information("Edytowano godziny pracay " + godzinypracy.idGodzinyPracy);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    Log.Error("Próba edycji nieistniejących godzin pracy");
                    return false;
                }
            return true;
        }
        public async Task UsunGodzinypracy(Godzinypracy godzinypracy)
        {
            using (var db = new firmaContext())
            {
                db.Godzinypracy.Remove(godzinypracy);
                await db.SaveChangesAsync();
                Log.Information("Usunięto godziny pracy " + godzinypracy.idGodzinyPracy);
            }
        }

        public async Task<IEnumerable<Podsumowanie>> Podsumowaniemiesieczne(DateTime data)
        {
            using (var db = new firmaContext())
            {
                double kursEuro = await HttpGrabber.KursEuro();
                int rok = data.Year;
                int miesiac = data.Month;
                var godzinypracy = from we in (db.Wejscia.Include(we => we.IdPracownikNavigation).
                                        ThenInclude(we => we.IdStanowiskoNavigation).
                                        ThenInclude(we => we.IdDzialNavigation))
                                   join g in (db.Godzinypracy) on
                                   we.IdPracownikNavigation.IdStanowiskoNavigation.IdDzialNavigation.IdDzial
                                   equals g.IdDzial
                                   join wy in (db.Wyjscia) on
                                   we.IdPracownikNavigation.IdPracownik
                                   equals wy.IdPracownik
                                   where (we.DzienTygodnia == g.DzienTygodnia && wy.DzienTygodnia == g.DzienTygodnia && we.DataWejscia.Year == rok && we.DataWejscia.Month == miesiac)
                                   select new { wejscia = we, godziny = g, wyjscia = wy };

                List<Podsumowanie> podsumowanielista = new List<Podsumowanie>();
                foreach (var praca in godzinypracy)
                {
                    var poczatekpracy = praca.wejscia.GodzinaWejscia;
                    if (praca.wejscia.GodzinaWejscia < praca.godziny.PoczatekPracy)
                    {
                        poczatekpracy = praca.godziny.PoczatekPracy;
                    }
                    var koniecpracy = praca.wyjscia.GodzinaWyjscia;
                    var nadgodziny = TimeSpan.Zero;
                    if (praca.wyjscia.GodzinaWyjscia > praca.godziny.KoniecPracy)
                    {
                        koniecpracy = praca.godziny.KoniecPracy;
                        nadgodziny = praca.wyjscia.GodzinaWyjscia - praca.godziny.KoniecPracy;
                    }
                    var czaspracy = koniecpracy - poczatekpracy;
                    podsumowanielista.Add(new Podsumowanie()
                    {
                        IdPracownik = praca.wejscia.IdPracownik,
                        Imie = praca.wejscia.IdPracownikNavigation.Imie,
                        Nazwisko = praca.wejscia.IdPracownikNavigation.Nazwisko,
                        CzasPracy = czaspracy.TotalHours,
                        Nadgodziny = nadgodziny.TotalHours,
                        Stawka = praca.wejscia.IdPracownikNavigation.IdStanowiskoNavigation.Wynagrodzenie
                    });
                }
                var podsumowanie = from p in podsumowanielista
                                   group p by p.IdPracownik into p2
                                   select new Podsumowanie()
                                   {
                                       IdPracownik = p2.ElementAt(0).IdPracownik,
                                       Imie = p2.ElementAt(0).Imie,
                                       Nazwisko = p2.ElementAt(0).Nazwisko,
                                       CzasPracy = p2.Sum(x => x.CzasPracy),
                                       Nadgodziny = p2.Sum(x => x.Nadgodziny),
                                       Wynagrodzenie = p2.Sum(x => x.CzasPracy) * p2.ElementAt(0).Stawka + p2.Sum(x => x.Nadgodziny) * p2.ElementAt(0).Stawka * 1.5,
                                       WynagrodzenieEuro = (p2.Sum(x => x.CzasPracy) * p2.ElementAt(0).Stawka + p2.Sum(x => x.Nadgodziny) * p2.ElementAt(0).Stawka * 1.5) / kursEuro
                                   };
                Log.Information("Podsumowanie miesięczne");
                return podsumowanie;
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