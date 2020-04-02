using WebApplication5.Models;

namespace WebApplication5.Repositories

{
    public interface IPracownikRepository

    {
        int AddNewPracownik(Pracownik pracownik);

        int DeletePracowikById(int id);

        Pracownik GetPracownikById(int id);

        Pracownik[] GetPracownik();

        int UpdatePracownikById(int id, Pracownik pracownik);

    }

}