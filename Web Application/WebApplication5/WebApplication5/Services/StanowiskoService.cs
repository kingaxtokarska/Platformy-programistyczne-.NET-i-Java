using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication5.Models;
using WebApplication5.Repositories;

namespace WebApplication5.Services
{
    public class StanowiskoService
    {
        private readonly StanowiskoRepository _stanowiskoRepository;

        public StanowiskoService(StanowiskoRepository stanowiskoRepository)
        {
            _stanowiskoRepository = stanowiskoRepository;
        }
        public async Task<List<Stanowisko>> PobierzStanowiska(string searchString, string sortOrder)
        {
            var stanowiska = await _stanowiskoRepository.PobierzStanowiska(searchString, sortOrder);
            return stanowiska;
        }
        public async Task<bool> EdytujStanowisko(Stanowisko input)
        {
            var stanowisko = await _stanowiskoRepository.PobierzStanowisko(input.IdStanowisko);
            if (stanowisko == null)
            {
                return false;
            }
            await _stanowiskoRepository.EdytujStanowisko(stanowisko);
            return true;
        }

        public async Task<bool> UsunStanowisko(int? id)
        {
            var stanowisko = await _stanowiskoRepository.PobierzStanowisko(id);
            if (stanowisko == null)
            {
                return false;
            }
            await _stanowiskoRepository.UsunStanowisko(stanowisko);
            return true;
        }
    }
}