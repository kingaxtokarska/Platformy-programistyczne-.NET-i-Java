using NUnit.Framework;
using Projekt_1;
using System.Collections.Generic;

namespace Test_1
{
    public class Testy
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestPodzielnePrzez3i5()
        {
            List<int> liczby = new List<int>() { 15 };
            List<string> oczekiwaneWyniki = new List<string>() { "FizzBuzz" };
            var rzeczywisteWyniki = BadanieLiczb.PodzielnoœæLiczb(liczby);
            Assert.AreEqual(oczekiwaneWyniki, rzeczywisteWyniki);
        }
        [Test]
        public void TestPodzielnePrzez5()
        {
            List<int> liczby = new List<int>() { 1, 5 };
            List<string> oczekiwaneWyniki = new List<string>() { "1", "Buzz" };
            var rzeczywisteWyniki = BadanieLiczb.PodzielnoœæLiczb(liczby);
            CollectionAssert.AreEqual(oczekiwaneWyniki, rzeczywisteWyniki);
        }

        [Test]
        public void TestPodzielnePrzez3()
        {
            List<int> liczby = new List<int>() { 1, 3 };
            List<string> oczekiwaneWyniki = new List<string>() { "1", "Fizz" };
            var rzeczywisteWyniki = BadanieLiczb.PodzielnoœæLiczb(liczby);
            CollectionAssert.AreEqual(oczekiwaneWyniki, rzeczywisteWyniki);
        }

        [Test]
        public void TestPodzielneiNiepodzielne()
        {
            List<int> liczby = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            List<string> oczekiwaneWyniki = new List<string>() { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz", "16", "17", "Fizz", "19", "Buzz" };
            var rzeczywisteWyniki = BadanieLiczb.PodzielnoœæLiczb(liczby);
            CollectionAssert.AreEqual(oczekiwaneWyniki, rzeczywisteWyniki);
        }
    }
}