using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace FirmaAplikacja.Repositories
{
    interface IGodzinypracyRepository
    {
        Task<List<Godzinypracy>> PobierzGodzinypracy(string searchString, string sortOrder);
        Task<Godzinypracy> PobierzGodzinypracy(int? id);
        Task DodajGodzinypracy(Godzinypracy godzinypracy);
        Task<bool> EdytujGodzinypracy(Godzinypracy godzinypracy);
        Task UsunGodzinypracy(Godzinypracy godzinypracy);
    }
}
