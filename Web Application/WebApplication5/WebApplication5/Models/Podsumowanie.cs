using System;

namespace WebApplication5.Models
{
    public class Podsumowanie
    {
        public int IdPracownik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public double Stawka { get; set; }
        public double CzasPracy { get; set; }
        public double Nadgodziny { get; set; }
        public double Wynagrodzenie { get; set; }
        public double WynagrodzenieEuro { get; set; }
        public DateTime Data { get; set; }

    }
}
