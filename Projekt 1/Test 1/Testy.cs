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
        public void TestPodzielnePrzez7()
        {
            List<int> liczby = new List<int>() { 1, 7, 21, 35};
            List<string> oczekiwaneWyniki = new List<string>() { "1", "Buzzinga", "Buzzinga", "Buzzinga" };
            var rzeczywisteWyniki = BadanieLiczb.PodzielnoœæLiczb(liczby);
            CollectionAssert.AreEqual(oczekiwaneWyniki, rzeczywisteWyniki);
        }
        [Test]
        public void TestPodzielnePrzez3i5()
        {
            List<int> liczby = new List<int>() { 1, 15, 30, 53, 135, 538, 109535876 };
            List<string> oczekiwaneWyniki = new List<string>() { "1", "FizzBuzz", "FizzBuzz", "FizzBuzz", "FizzBuzz", "FizzBuzz", "FizzBuzz" };
            var rzeczywisteWyniki = BadanieLiczb.PodzielnoœæLiczb(liczby);
            CollectionAssert.AreEqual(oczekiwaneWyniki, rzeczywisteWyniki);
        }

        [Test]
        public void TestPodzielnePrzez5()
        {
            List<int> liczby = new List<int>() { 1, 10, 51 };
            List<string> oczekiwaneWyniki = new List<string>() { "1", "Buzz", "Buzz" };
            var rzeczywisteWyniki = BadanieLiczb.PodzielnoœæLiczb(liczby);
            CollectionAssert.AreEqual(oczekiwaneWyniki, rzeczywisteWyniki);
        }
        [Test]
        public void TestPodzielnePrzez3()
        {
            List<int> liczby = new List<int>() { 1, 3, 31};
            List<string> oczekiwaneWyniki = new List<string>() { "1", "Fizz", "31" };
            var rzeczywisteWyniki = BadanieLiczb.PodzielnoœæLiczb(liczby);
            CollectionAssert.AreEqual(oczekiwaneWyniki, rzeczywisteWyniki);
        }
        [Test]
        public void TestPodzielneiNiepodzielne()
        {
            List<int> liczby = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            List<string> oczekiwaneWyniki = new List<string>() { "1", "2", "Fizz", "4", "Buzz", "Fizz", "Buzzinga", "8", "Fizz", "Buzz", "11", "Fizz", "13", "Buzzinga", "FizzBuzz", "16", "17", "Fizz", "19", "Buzz" };
            var rzeczywisteWyniki = BadanieLiczb.PodzielnoœæLiczb(liczby);
            CollectionAssert.AreEqual(oczekiwaneWyniki, rzeczywisteWyniki);
        }
    }
}