using System;
using System.Collections.Generic;

namespace WebApplication5.Models
{
    public partial class Wyjscia
    {
        public int IdPracownik { get; set; }
        public DateTime? DataWyjscia { get; set; }
        public TimeSpan? GodzinaWyjscia { get; set; }

        public virtual Pracownik IdPracownikNavigation { get; set; }
    }
}
