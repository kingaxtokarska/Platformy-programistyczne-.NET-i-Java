using WebApplication5.Models;

namespace WebApplication5.Repositories

{
    public interface IDzialRepository

    {
        int AddNewDzial(Dzial dzal);

        int DeleteDzialById(int id);

        Dzial GetDzialById(int id);

        Dzial[] GetDzial();

        int UpdateDzialById(int id, Dzial dzial);

    }

}