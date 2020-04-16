using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace FirmaAplikacja.Repositories
{
    interface IStanowiskoRepository
    {
        Task<List<Stanowisko>> PobierzStanowiska(string searchString, string sortOrder);
        Task<Stanowisko> PobierzStanowisko(int? id);
        Task DodajStanowisko(Stanowisko stanowisko);
        Task<bool> EdytujStanowisko(Stanowisko stanowisko);
        Task UsunStanowisko(Stanowisko stanowisko);
    }
}
