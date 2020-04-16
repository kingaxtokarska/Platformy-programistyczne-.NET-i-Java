using System;

namespace WebApplication5.Models
{
    public partial class Wyjscia
    {
        public int idWyjscie { get; set; }
        public int IdPracownik { get; set; }
        public DateTime DataWyjscia { get; set; }
        public TimeSpan GodzinaWyjscia { get; set; }

        public string DzienTygodnia { get; set; }

        public virtual Pracownik IdPracownikNavigation { get; set; }
    }
}
