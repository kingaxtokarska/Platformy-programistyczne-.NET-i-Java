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
    public class PracownikTests
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

        [Test]
        public async Task Test1()
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
                db.SaveChanges();
            }
            testowypracownik.Imie = "Ryszard";
            testowypracownik.Nazwisko = "Tester";
            testowypracownik.Pesel = "621112582346";
            testowypracownik.StatusZatrudnienia = "zatrudniony";
            testowypracownik.DataZatrudnienia = DateTime.Now.Date;
            testowypracownik.IdStanowisko = 1;
            await pracownikcontroller.Create(testowypracownik);
            Pracownik result = await pracownikrepository.PobierzPracownika(1);
            Assert.AreEqual(testowypracownik.Imie, result.Imie);
            Assert.AreEqual(testowypracownik.Nazwisko, result.Nazwisko);
            Assert.AreEqual(testowypracownik.Pesel, result.Pesel);
            Assert.AreEqual(testowypracownik.IdStanowisko, result.IdStanowisko);
            Assert.AreEqual(testowypracownik.StatusZatrudnienia, result.StatusZatrudnienia);
            Assert.AreEqual(testowypracownik.DataZatrudnienia, result.DataZatrudnienia);
            Assert.AreEqual(testowypracownik.IdPracownik, result.IdPracownik);

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
                db.SaveChanges();
            }

            testowypracownik.Imie = "Zbigniew";
            await pracownikcontroller.Edit(1, testowypracownik);
            Pracownik result = await pracownikrepository.PobierzPracownika(1);
            Assert.AreEqual(testowypracownik.Imie, result.Imie);
            Assert.AreEqual(testowypracownik.Nazwisko, result.Nazwisko);
            Assert.AreEqual(testowypracownik.Pesel, result.Pesel);
            Assert.AreEqual(testowypracownik.IdStanowisko, result.IdStanowisko);
            Assert.AreEqual(testowypracownik.StatusZatrudnienia, result.StatusZatrudnienia);
            Assert.AreEqual(testowypracownik.DataZatrudnienia, result.DataZatrudnienia);
            Assert.AreEqual(testowypracownik.IdPracownik, result.IdPracownik);
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
                db.SaveChanges();
            }
            await pracownikcontroller.Delete(1);
            List<Pracownik> result = await pracownikservice.PobierzPracownikow("", "");
            Assert.IsEmpty(result);
        }
    }
}