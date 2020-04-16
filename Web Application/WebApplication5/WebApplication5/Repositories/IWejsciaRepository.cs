using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace FirmaAplikacja.Repositories
{
    interface IWejsciaRepository
    {
        Task<List<Wejscia>> PobierzWejscia(string searchString, string sortOrder);
        Task<Wejscia> PobierzWejscie(int? id);
        Task DodajWejscie(Wejscia wejscie);
        Task<bool> EdytujWejscie(Wejscia wejscie);
        Task UsunWejscie(Wejscia wejscie);
    }
}
