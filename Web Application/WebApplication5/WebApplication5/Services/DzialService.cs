using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication5.Models;
using WebApplication5.Repositories;

namespace WebApplication5.Services
{
    public class DzialService
    {
        private readonly DzialRepository _dzialRepository;

        public DzialService(DzialRepository dzialRepository)
        {
            _dzialRepository = dzialRepository;
        }
        public async Task<List<Dzial>> PobierzDzialy(string searchString, string sortOrder)
        {
            var dzialy = await _dzialRepository.PobierzDzialy(searchString, sortOrder);
            return dzialy;
        }
        public async Task<bool> EdytujDzial(Dzial input)
        {
            var dzial = await _dzialRepository.PobierzDzial(input.IdDzial);
            if (dzial == null)
            {
                return false;
            }
            await _dzialRepository.EdytujDzial(dzial);
            return true;
        }

        public async Task<bool> UsunDzial(int? id)
        {
            var dzial = await _dzialRepository.PobierzDzial(id);
            if (dzial == null)
            {
                return false;
            }
            await _dzialRepository.UsunDzial(dzial);
            return true;
        }
    }
}