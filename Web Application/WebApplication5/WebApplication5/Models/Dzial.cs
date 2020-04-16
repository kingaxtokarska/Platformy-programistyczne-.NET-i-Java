using System.Collections.Generic;

namespace WebApplication5.Models
{
    public partial class Dzial
    {
        public Dzial()
        {
            Stanowisko = new HashSet<Stanowisko>();
        }
        public int IdDzial { get; set; }
        public string NazwaDzial { get; set; }

        public virtual ICollection<Stanowisko> Stanowisko { get; set; }
    }
}
