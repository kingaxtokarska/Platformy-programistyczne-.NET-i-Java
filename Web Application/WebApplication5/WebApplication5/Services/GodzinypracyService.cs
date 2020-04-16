using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication5.Models;
using WebApplication5.Repositories;

namespace WebApplication5.Services
{
    public class GodzinypracyService
    {
        private readonly GodzinypracyRepository _godzinypracyRepository;

        public GodzinypracyService(GodzinypracyRepository godzinypracyRepository)
        {
            _godzinypracyRepository = godzinypracyRepository;
        }
        public async Task<List<Godzinypracy>> PobierzGodzinypracy(string searchString, string sortOrder)
        {
            var godzinypracy = await _godzinypracyRepository.PobierzGodzinypracy(searchString, sortOrder);
            return godzinypracy;
        }
        public async Task<bool> EdytujGodzinypracy(Godzinypracy input)
        {
            var godzinypracy = await _godzinypracyRepository.PobierzGodzinypracy(input.idGodzinyPracy);
            if (godzinypracy == null)
            {
                return false;
            }
            await _godzinypracyRepository.EdytujGodzinypracy(godzinypracy);
            return true;
        }

        public async Task<bool> UsunGodzinypracy(int? id)
        {
            var godzinypracy = await _godzinypracyRepository.PobierzGodzinypracy(id);
            if (godzinypracy == null)
            {
                return false;
            }
            await _godzinypracyRepository.UsunGodzinypracy(godzinypracy);
            return true;
        }
        public async Task<IEnumerable<Podsumowanie>> PodsumowanieMiesieczne(DateTime data)
        {
            var podsumowanie = await _godzinypracyRepository.Podsumowaniemiesieczne(data);
            return podsumowanie;
        }
    }
}