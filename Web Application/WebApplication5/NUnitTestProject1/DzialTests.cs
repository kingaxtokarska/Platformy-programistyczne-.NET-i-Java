using NUnit.Framework;
using Serilog;
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
    public class DzialTests
    {
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

        [Test]
        public async Task Test1()
        {
            testowydzial.NazwaDzial = "Tworzenie dzia³u";
            await dzialcontroller.Create(testowydzial);
            Dzial result = await dzialrepository.PobierzDzial(1);
            Assert.AreEqual(testowydzial.NazwaDzial, result.NazwaDzial);
            Assert.AreEqual(testowydzial.IdDzial, result.IdDzial);
        }
        [Test]
        public async Task Test2()
        {
            using (var db = new firmaContext())
            {
                testowydzial.NazwaDzial = "Tworzenie dzia³u";
                db.Add(testowydzial);
                db.SaveChanges();
            }
           
            testowydzial.NazwaDzial = "Edytowanie dzia³u";
            await dzialcontroller.Edit(1, testowydzial);
            Dzial result = await dzialrepository.PobierzDzial(1);
            Assert.AreEqual(testowydzial.NazwaDzial, result.NazwaDzial);
            Assert.AreEqual(testowydzial.IdDzial, result.IdDzial);
        }
        [Test]
        public async Task Test3()
        {
            using (var db = new firmaContext())
            {
                testowydzial.NazwaDzial = "Tworzenie dzia³u";
                db.Add(testowydzial);
                db.SaveChanges();
            }

            await dzialcontroller.Delete(1);
            List<Dzial> result = await dzialservice.PobierzDzialy("", "");
            Assert.IsEmpty(result);
        }
    }
}