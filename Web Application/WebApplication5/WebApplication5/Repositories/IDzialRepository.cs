using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace FirmaAplikacja.Repositories
{
    interface IDzialRepository
    {
        Task<List<Dzial>> PobierzDzialy(string searchString, string sortOrder);
        Task<Dzial> PobierzDzial(int? id);
        Task DodajDzial(Dzial dzial);
        Task<bool> EdytujDzial(Dzial dzial);
        Task UsunDzial(Dzial dzial);
    }
}
