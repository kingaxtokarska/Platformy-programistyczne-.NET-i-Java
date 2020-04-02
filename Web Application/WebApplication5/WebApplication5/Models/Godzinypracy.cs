using System;
using System.Collections.Generic;

namespace WebApplication5.Models
{
    public partial class Godzinypracy
    {
        public string DzienTygodnia { get; set; }
        public int IdDzial { get; set; }
        public TimeSpan PoczatekPracy { get; set; }
        public TimeSpan KoniecPracy { get; set; }

        public virtual Dzial IdDzialNavigation { get; set; }
    }
}
