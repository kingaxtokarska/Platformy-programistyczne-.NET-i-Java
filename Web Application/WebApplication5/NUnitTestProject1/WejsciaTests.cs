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
    public class WejsciaTests
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
        public static WejsciaRepository wejsciarepository = new WejsciaRepository();
        public static WejsciaService wejsciaservice = new WejsciaService(wejsciarepository);
        public static WejsciaController wejsciacontroller = new WejsciaController(wejsciaservice, wejsciarepository);

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
        Wejscia testowewejscie = new Wejscia();

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
            testowewejscie.DataWejscia = DateTime.Now.Date;
            testowewejscie.GodzinaWejscia = DateTime.Now.TimeOfDay;
            testowewejscie.DzienTygodnia = DateTime.Now.DayOfWeek.ToString();
            testowewejscie.IdPracownik = 1;
            await wejsciacontroller.Create(testowewejscie);
            Wejscia result = await wejsciarepository.PobierzWejscie(1);
            Assert.AreEqual(testowewejscie.DataWejscia, result.DataWejscia);
            Assert.AreEqual(testowewejscie.DzienTygodnia, result.DzienTygodnia);
            Assert.AreEqual(testowewejscie.IdPracownik, result.IdPracownik);
            Assert.AreEqual(testowewejscie.idWejscie, result.idWejscie);
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
                testowewejscie.DataWejscia = DateTime.Now.Date;
                testowewejscie.GodzinaWejscia = DateTime.Now.TimeOfDay;
                testowewejscie.DzienTygodnia = DateTime.Now.DayOfWeek.ToString();
                testowewejscie.IdPracownik = 1;
                testowewejscie.IdPracownikNavigation = testowypracownik;
                db.Add(testowewejscie);
                db.SaveChanges();
            }
            testowewejscie.DzienTygodnia = "Sunday";
            await wejsciacontroller.Edit(1, testowewejscie);
            Wejscia result = await wejsciarepository.PobierzWejscie(1);
            Assert.AreEqual(testowewejscie.DataWejscia, result.DataWejscia);
            Assert.AreEqual(testowewejscie.DzienTygodnia, result.DzienTygodnia);
            Assert.AreEqual(testowewejscie.IdPracownik, result.IdPracownik);
            Assert.AreEqual(testowewejscie.idWejscie, result.idWejscie);
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
                testowewejscie.DataWejscia = DateTime.Now.Date;
                testowewejscie.GodzinaWejscia = DateTime.Now.TimeOfDay;
                testowewejscie.DzienTygodnia = DateTime.Now.DayOfWeek.ToString();
                testowewejscie.IdPracownik = 1;
                testowewejscie.IdPracownikNavigation = testowypracownik;
                db.Add(testowewejscie);
                db.SaveChanges();
            }
            await wejsciacontroller.Delete(1);
            List<Wejscia> result = await wejsciaservice.PobierzWejscia("", "");
            Assert.IsEmpty(result);
        }
       
       
    }
}