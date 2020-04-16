using System;

namespace WebApplication5.Models
{
    public partial class Pracownik
    {
        public int IdPracownik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        public string StatusZatrudnienia { get; set; }
        public int IdStanowisko { get; set; }

        public virtual Stanowisko IdStanowiskoNavigation { get; set; }
    }
}
