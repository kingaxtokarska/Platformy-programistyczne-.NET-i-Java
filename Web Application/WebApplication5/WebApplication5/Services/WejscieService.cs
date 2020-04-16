using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication5.Models;
using WebApplication5.Repositories;

namespace WebApplication5.Services
{
    public class WejsciaService
    {
        private readonly WejsciaRepository _wejsciaRepository;

        public WejsciaService(WejsciaRepository wejsciaRepository)
        {
            _wejsciaRepository = wejsciaRepository;
        }
        public async Task<List<Wejscia>> PobierzWejscia(string searchString, string sortOrder)
        {
            var wejscia = await _wejsciaRepository.PobierzWejscia(searchString, sortOrder);
            return wejscia;
        }
        public async Task<bool> EdytujWejscie(Wejscia input)
        {
            var wejscie = await _wejsciaRepository.PobierzWejscie(input.idWejscie);
            if (wejscie == null)
            {
                return false;
            }
            await _wejsciaRepository.EdytujWejscie(wejscie);
            return true;
        }

        public async Task<bool> UsunWejscie(int? id)
        {
            var wejscie = await _wejsciaRepository.PobierzWejscie(id);
            if (wejscie == null)
            {
                return false;
            }
            await _wejsciaRepository.UsunWejscie(wejscie);
            return true;
        }
        public async Task<List<Wejscia>> Spoznienia(DateTime data)
        {
            var wejscia = await _wejsciaRepository.Spoznienia(data);
            return wejscia;
        }
    }
}