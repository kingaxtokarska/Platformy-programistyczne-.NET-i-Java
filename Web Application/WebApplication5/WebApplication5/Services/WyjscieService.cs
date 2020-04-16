using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication5.Models;
using WebApplication5.Repositories;

namespace WebApplication5.Services
{
    public class WyjsciaService
    {
        private readonly WyjsciaRepository _wyjsciaRepository;

        public WyjsciaService(WyjsciaRepository wyjsciaRepository)
        {
            _wyjsciaRepository = wyjsciaRepository;
        }
        public async Task<List<Wyjscia>> PobierzWyjscia(string searchString, string sortOrder)
        {
            var wyjscia = await _wyjsciaRepository.PobierzWyjscia(searchString, sortOrder);
            return wyjscia;
        }
        public async Task<bool> EdytujWyjscie(Wyjscia input)
        {
            var wyjscie = await _wyjsciaRepository.PobierzWyjscie(input.idWyjscie);
            if (wyjscie == null)
            {
                return false;
            }
            await _wyjsciaRepository.EdytujWyjscie(wyjscie);
            return true;
        }

        public async Task<bool> UsunWyjscie(int? id)
        {
            var wyjscie = await _wyjsciaRepository.PobierzWyjscie(id);
            if (wyjscie == null)
            {
                return false;
            }
            await _wyjsciaRepository.UsunWyjscie(wyjscie);
            return true;
        }
    }
}