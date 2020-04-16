using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace FirmaAplikacja.Repositories
{
    interface IPracownikRepository
    {
        Task<List<Pracownik>> PobierzPracownikow(string searchString, string sortOrder);
        Task<Pracownik> PobierzPracownika(int? id);
        Task DodajPracownika(Pracownik pracownik);
        Task<bool> EdytujPracownika(Pracownik pracownik);
        Task UsunPracownika(Pracownik pracownik);
    }
}
