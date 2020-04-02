using WebApplication5.Models;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;



namespace WebApplication5.Repositories

{

    public class PracownikRepository : IPracownikRepository

    {

        private firmaContext _context;
        public PracownikRepository(firmaContext context)

        {

            _context = context;

        }



        public Pracownik[] GetPracownik()

        {

            return _context.Pracownik.ToArray();

        }



        public Pracownik GetPracownikById(int id)

        {

            var pracownik = _context.Pracownik.SingleOrDefault(a => a.IdPracownik == id);
            return pracownik;

        }

        public int UpdatePracownikById(int id, Pracownik pracownik)

        {

            int updateSuccess = 0;

            var target = _context.Pracownik.SingleOrDefault(a => a.IdPracownik == id);

            if (target != null)

            {

                _context.Entry(target).CurrentValues.SetValues(pracownik);

                updateSuccess = _context.SaveChanges();

            }

            return updateSuccess;

        }


        public int AddNewPracownik(Pracownik pracownik)

        {

            int insertSuccess = 0;

            int maxId = _context.Pracownik.Max(p => p.IdPracownik);



            pracownik.IdPracownik = (short)(maxId + 1);

            _context.Pracownik.Add(pracownik);

            insertSuccess = _context.SaveChanges();

            return insertSuccess;

        }



        public int DeletePracowikById(int id)

        {

            int deleteSuccess = 0;

            var pracownik = _context.Pracownik.SingleOrDefault(a => a.IdPracownik == id);

            if (pracownik != null)

            {

                _context.Pracownik.Remove(pracownik);

                deleteSuccess = _context.SaveChanges();

            }

            return deleteSuccess;

        }

    }

}