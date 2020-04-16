using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication5.Models;
using WebApplication5.Repositories;

namespace WebApplication5.Services
{
    public class PracownikService
    {
        private readonly PracownikRepository _pracownikRepository;

        public PracownikService(PracownikRepository pracownikRepository)
        {
            _pracownikRepository = pracownikRepository;
        }
        public async Task<List<Pracownik>> PobierzPracownikow(string searchString, string sortOrder)
        {
            var pracownicy = await _pracownikRepository.PobierzPracownikow(searchString, sortOrder);
            return pracownicy;
        }
        public async Task<bool> EdytujPracownika(Pracownik input)
        {
            var pracownik = await _pracownikRepository.PobierzPracownika(input.IdPracownik);
            if (pracownik == null)
            {
                return false;
            }
            await _pracownikRepository.EdytujPracownika(pracownik);
            return true;
        }

        public async Task<bool> UsunPracownika(int? id)
        {
            var pracownik = await _pracownikRepository.PobierzPracownika(id);
            if (pracownik == null)
            {
                return false;
            }
            await _pracownikRepository.UsunPracownika(pracownik);
            return true;
        }
    }
}