using System.Collections.Generic;

namespace WebApplication5.Models
{
    public partial class Stanowisko
    {
        public Stanowisko()
        {
            Pracownik = new HashSet<Pracownik>();
        }
        public int IdStanowisko { get; set; }
        public string NazwaStanowisko { get; set; }
        public double Wynagrodzenie { get; set; }
        public int IdDzial { get; set; }

        public virtual Dzial IdDzialNavigation { get; set; }
        public virtual ICollection<Pracownik> Pracownik { get; set; }
    }
}
