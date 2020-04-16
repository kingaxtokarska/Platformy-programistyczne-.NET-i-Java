using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WebApplication5;
using WebApplication5.Controllers;
using WebApplication5.Models;
using WebApplication5.Repositories;
using WebApplication5.Services;

namespace NUnitTestProject1
{
    public class GodzinypracyTests
    {
        public static GodzinypracyRepository godzinypracyrepository = new GodzinypracyRepository();
        public static GodzinypracyService godzinypracyservice = new GodzinypracyService(godzinypracyrepository);
        public static GodzinypracyController godzinypracycontroller = new GodzinypracyController(godzinypracyservice, godzinypracyrepository);
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
        Godzinypracy testowegodzinypracy = new Godzinypracy();

        [Test]
        public async Task Test1()
        {
            using (var db = new firmaContext())
            {
                testowydzial.NazwaDzial = "Tworzenie dzia³u";
                db.Add(testowydzial);
                db.SaveChanges();
            }
            
            testowegodzinypracy.IdDzial = 1;
            testowegodzinypracy.PoczatekPracy = TimeSpan.Parse("06:00:00");
            testowegodzinypracy.KoniecPracy = TimeSpan.Parse("14:00:00");
            testowegodzinypracy.DzienTygodnia = "Saturday";
            await godzinypracycontroller.Create(testowegodzinypracy);

            Godzinypracy result = await godzinypracyrepository.PobierzGodzinypracy(1);
            Assert.AreEqual(testowegodzinypracy.PoczatekPracy, result.PoczatekPracy);
            Assert.AreEqual(testowegodzinypracy.KoniecPracy, result.KoniecPracy);
            Assert.AreEqual(testowegodzinypracy.DzienTygodnia, result.DzienTygodnia);
            Assert.AreEqual(testowegodzinypracy.idGodzinyPracy, result.idGodzinyPracy);
            Assert.AreEqual(testowegodzinypracy.IdDzial, result.IdDzial);  
        }
        [Test]
        public async Task Test2()
        {
            using (var db = new firmaContext())
            {
                testowydzial.NazwaDzial = "Tworzenie dzia³u";
                db.Add(testowydzial);
                testowegodzinypracy.IdDzial = 1;
                testowegodzinypracy.PoczatekPracy = TimeSpan.Parse("06:00:00");
                testowegodzinypracy.KoniecPracy = TimeSpan.Parse("14:00:00");
                testowegodzinypracy.DzienTygodnia = "Saturday";
                testowegodzinypracy.IdDzialNavigation = testowydzial;
                db.Add(testowegodzinypracy);
                db.SaveChanges();
            }

            testowegodzinypracy.DzienTygodnia = "Sunday";
            await godzinypracycontroller.Edit(1, testowegodzinypracy);
            Godzinypracy result = await godzinypracyrepository.PobierzGodzinypracy(1);
            Assert.AreEqual(testowegodzinypracy.PoczatekPracy, result.PoczatekPracy);
            Assert.AreEqual(testowegodzinypracy.KoniecPracy, result.KoniecPracy);
            Assert.AreEqual(testowegodzinypracy.DzienTygodnia, result.DzienTygodnia);
            Assert.AreEqual(testowegodzinypracy.idGodzinyPracy, result.idGodzinyPracy);
            Assert.AreEqual(testowegodzinypracy.IdDzial, result.IdDzial);
        }
        [Test]
        public async Task Test3()
        {
            using (var db = new firmaContext())
            {
                testowydzial.NazwaDzial = "Tworzenie dzia³u";
                db.Add(testowydzial);
                testowegodzinypracy.IdDzial = 1;
                testowegodzinypracy.IdDzialNavigation = testowydzial;
                testowegodzinypracy.PoczatekPracy = TimeSpan.Parse("06:00:00");
                testowegodzinypracy.KoniecPracy = TimeSpan.Parse("14:00:00");
                testowegodzinypracy.DzienTygodnia = "Saturday";
                db.Add(testowegodzinypracy);
                db.SaveChanges();
            }
            await godzinypracycontroller.Delete(1);
            List<Godzinypracy> result = await godzinypracyservice.PobierzGodzinypracy("", "");
            Assert.IsEmpty(result);
        }
    }
}