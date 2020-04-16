using System;

namespace WebApplication5.Models
{
    public partial class Wejscia
    {
        public int idWejscie { get; set; }
        public int IdPracownik { get; set; }
        public DateTime DataWejscia { get; set; }
        public TimeSpan GodzinaWejscia { get; set; }
        public virtual Pracownik IdPracownikNavigation { get; set; }
        public string DzienTygodnia { get; set; }
    }
}
