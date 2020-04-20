using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class Rola
    {
        public int IdRola { get; set; }
        public string NazwaRola { get; set; }
        public virtual ICollection<Uzytkownik> Uzytkownik { get; set; }
    }
}
