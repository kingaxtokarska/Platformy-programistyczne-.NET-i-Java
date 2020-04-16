using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace FirmaAplikacja.Repositories
{
    interface IWyjsciaRepository
    {
        Task<List<Wyjscia>> PobierzWyjscia(string searchString, string sortOrder);
        Task<Wyjscia> PobierzWyjscie(int? id);
        Task DodajWyjscie(Wyjscia wyjscie);
        Task<bool> EdytujWyjscie(Wyjscia wyjscie);
        Task UsunWyjscie(Wyjscia wyjscie);
    }
}
