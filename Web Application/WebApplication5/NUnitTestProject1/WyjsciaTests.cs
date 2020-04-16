using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication5;
using WebApplication5.Controllers;
using WebApplication5.Models;
using WebApplication5.Repositories;
using WebApplication5.Services;

namespace NUnitTestProject1
{
    public class WyjsciaTests
    {
        public static StanowiskoRepository stanowiskorepository = new StanowiskoRepository();
        public static StanowiskoService stanowiskoservice = new StanowiskoService(stanowiskorepository);
        public static StanowiskoController stanowiskocontroller = new StanowiskoController(stanowiskoservice, stanowiskorepository);
        public static DzialRepository dzialrepository = new DzialRepository();
        public static DzialService dzialservice = new DzialService(dzialrepository);
        public static DzialController dzialcontroller = new DzialController(dzialservice, dzialrepository);
        public static PracownikRepository pracownikrepository = new PracownikRepository();
        public static PracownikService pracownikservice = new PracownikService(pracownikrepository);
        public static PracownikController pracownikcontroller = new PracownikController(pracownikservice, pracownikrepository);
        public static WyjsciaRepository wyjsciarepository = new WyjsciaRepository();
        public static WyjsciaService wyjsciaservice = new WyjsciaService(wyjsciarepository);
        public static WyjsciaController wyjsciacontroller = new WyjsciaController(wyjsciaservice, wyjsciarepository);

        [SetUp]
        public void Setup()
        {
            ConfigurationSettings.ConnectionSettings = "Server=localhost;Port=3306;Database=test;Uid=root;Pwd=root;";

            using (var db = new firmaContext())
            {
                db.Database.EnsureCreated();
            }
        }
        [TearDown]
        public void TearDown()
        {
            using (var db = new firmaContext())
            {
                db.Database.EnsureDeleted();
            }
        }
        Dzial testowydzial = new Dzial();
        Stanowisko testowestanowisko = new Stanowisko();
        Pracownik testowypracownik = new Pracownik();
        Wyjscia testowewyjscie = new Wyjscia();

        [Test]
        public async Task Test()
        {
            using (var db = new firmaContext())
            {
                testowydzial.NazwaDzial = "Tworzenie dzia³u";
                db.Dzial.Add(testowydzial);
                testowestanowisko.NazwaStanowisko = "Tworzenie stanowiska";
                testowestanowisko.Wynagrodzenie = 50;
                testowestanowisko.IdDzial = 1;
                testowestanowisko.IdDzialNavigation = testowydzial;
                db.Stanowisko.Add(testowestanowisko);
                testowypracownik.Imie = "Ryszard";
                testowypracownik.Nazwisko = "Tester";
                testowypracownik.Pesel = "621112582346";
                testowypracownik.StatusZatrudnienia = "zatrudniony";
                testowypracownik.DataZatrudnienia = DateTime.Now.Date;
                testowypracownik.IdStanowisko = 1;
                testowypracownik.IdStanowiskoNavigation = testowestanowisko;
                db.Pracownik.Add(testowypracownik);
                db.SaveChanges();
            }
            testowewyjscie.DataWyjscia = DateTime.Now.Date;
            testowewyjscie.GodzinaWyjscia = DateTime.Now.TimeOfDay;
            testowewyjscie.DzienTygodnia = DateTime.Now.DayOfWeek.ToString();
            testowewyjscie.IdPracownik = 1;
            await wyjsciacontroller.Create(testowewyjscie);
            Wyjscia result = await wyjsciarepository.PobierzWyjscie(1);
            Assert.AreEqual(testowewyjscie.DataWyjscia, result.DataWyjscia);
            Assert.AreEqual(testowewyjscie.DzienTygodnia, result.DzienTygodnia);
            Assert.AreEqual(testowewyjscie.IdPracownik, result.IdPracownik);
            Assert.AreEqual(testowewyjscie.idWyjscie, result.idWyjscie);
        }
        [Test]
        public async Task Test2()
        {
            using (var db = new firmaContext())
            {
                testowydzial.NazwaDzial = "Tworzenie dzia³u";
                db.Add(testowydzial);
                testowestanowisko.NazwaStanowisko = "Tworzenie stanowiska";
                testowestanowisko.Wynagrodzenie = 50;
                testowestanowisko.IdDzial = 1;
                testowestanowisko.IdDzialNavigation = testowydzial;
                db.Add(testowestanowisko);
                testowypracownik.Imie = "Ryszard";
                testowypracownik.Nazwisko = "Tester";
                testowypracownik.Pesel = "621112582346";
                testowypracownik.StatusZatrudnienia = "zatrudniony";
                testowypracownik.DataZatrudnienia = DateTime.Now.Date;
                testowypracownik.IdStanowisko = 1;
                testowypracownik.IdStanowiskoNavigation = testowestanowisko;
                db.Add(testowypracownik);
                testowewyjscie.DataWyjscia = DateTime.Now.Date;
                testowewyjscie.GodzinaWyjscia = DateTime.Now.TimeOfDay;
                testowewyjscie.DzienTygodnia = DateTime.Now.DayOfWeek.ToString();
                testowewyjscie.IdPracownik = 1;
                testowewyjscie.IdPracownikNavigation = testowypracownik;
                db.Add(testowewyjscie);
                db.SaveChanges();
            }
            testowewyjscie.DzienTygodnia = "Sunday";
            await wyjsciacontroller.Edit(1, testowewyjscie);
            Wyjscia result = await wyjsciarepository.PobierzWyjscie(1);
            Assert.AreEqual(testowewyjscie.DataWyjscia, result.DataWyjscia);
            Assert.AreEqual(testowewyjscie.DzienTygodnia, result.DzienTygodnia);
            Assert.AreEqual(testowewyjscie.IdPracownik, result.IdPracownik);
            Assert.AreEqual(testowewyjscie.idWyjscie, result.idWyjscie);
        }
        [Test]
        public async Task Test3()
        {
            using (var db = new firmaContext())
            {
                testowydzial.NazwaDzial = "Tworzenie dzia³u";
                db.Add(testowydzial);
                testowestanowisko.NazwaStanowisko = "Tworzenie stanowiska";
                testowestanowisko.Wynagrodzenie = 50;
                testowestanowisko.IdDzial = 1;
                testowestanowisko.IdDzialNavigation = testowydzial;
                db.Add(testowestanowisko);
                testowypracownik.Imie = "Ryszard";
                testowypracownik.Nazwisko = "Tester";
                testowypracownik.Pesel = "621112582346";
                testowypracownik.StatusZatrudnienia = "zatrudniony";
                testowypracownik.DataZatrudnienia = DateTime.Now.Date;
                testowypracownik.IdStanowisko = 1;
                testowypracownik.IdStanowiskoNavigation = testowestanowisko;
                db.Add(testowypracownik);
                testowewyjscie.DataWyjscia = DateTime.Now.Date;
                testowewyjscie.GodzinaWyjscia = DateTime.Now.TimeOfDay;
                testowewyjscie.DzienTygodnia = DateTime.Now.DayOfWeek.ToString();
                testowewyjscie.IdPracownik = 1;
                testowewyjscie.IdPracownikNavigation = testowypracownik;
                db.Add(testowewyjscie);
                db.SaveChanges();
            }
            await wyjsciacontroller.Delete(1);
            List<Wyjscia> result = await wyjsciaservice.PobierzWyjscia("", "");
            Assert.IsEmpty(result);
        }
       
       
    }
}