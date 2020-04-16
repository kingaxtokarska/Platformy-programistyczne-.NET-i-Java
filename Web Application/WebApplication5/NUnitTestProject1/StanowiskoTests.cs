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
    public class StanowiskoTests
    {
        public static StanowiskoRepository stanowiskorepository = new StanowiskoRepository();
        public static StanowiskoService stanowiskoservice = new StanowiskoService(stanowiskorepository);
        public static StanowiskoController stanowiskocontroller = new StanowiskoController(stanowiskoservice, stanowiskorepository);
        public static DzialRepository dzialrepository = new DzialRepository();
        public static DzialService dzialservice = new DzialService(dzialrepository);
        public static DzialController dzialcontroller = new DzialController(dzialservice, dzialrepository);

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

        [Test]
        public async Task Test1()
        {
            using (var db = new firmaContext())
            {
                testowydzial.NazwaDzial = "Tworzenie dzia³u";
                db.Add(testowydzial);
                db.SaveChanges();
            }

            testowestanowisko.NazwaStanowisko = "Tworzenie stanowiska";
            testowestanowisko.Wynagrodzenie = 50;
            testowestanowisko.IdDzial = 1;
            await stanowiskocontroller.Create(testowestanowisko);
            Stanowisko result = await stanowiskorepository.PobierzStanowisko(1);
            Assert.AreEqual(testowestanowisko.NazwaStanowisko, result.NazwaStanowisko);
            Assert.AreEqual(testowestanowisko.IdStanowisko, result.IdStanowisko);
            Assert.AreEqual(testowestanowisko.Wynagrodzenie, result.Wynagrodzenie);
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
                db.SaveChanges();
            }

            testowestanowisko.NazwaStanowisko = "Edytowanie stanowiska";
            await stanowiskocontroller.Edit(1, testowestanowisko);
            Stanowisko result = await stanowiskorepository.PobierzStanowisko(1);
            Assert.AreEqual(testowestanowisko.NazwaStanowisko, result.NazwaStanowisko);
            Assert.AreEqual(testowestanowisko.IdStanowisko, result.IdStanowisko);
            Assert.AreEqual(testowestanowisko.Wynagrodzenie, result.Wynagrodzenie);
            Assert.AreEqual(testowestanowisko.IdDzial, result.IdDzial);
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
                db.SaveChanges();
            }

            await stanowiskocontroller.Delete(1);
            List<Stanowisko> result = await stanowiskoservice.PobierzStanowiska("", "");
            Assert.IsEmpty(result);
        }
    }
}
