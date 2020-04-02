using WebApplication5.Models;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;



namespace WebApplication5.Repositories

{

    public class DzialRepository : IDzialRepository

    {

        private firmaContext _context;
        public DzialRepository(firmaContext context)

        {

            _context = context;

        }



        public Dzial[] GetDzial()

        {

            return _context.Dzial.ToArray();

        }



        public Dzial GetDzialById(int id)

        {

            var dzial = _context.Dzial.SingleOrDefault(a => a.IdDzial == id);
            return dzial;

        }

        public int UpdateDzialById(int id, Dzial dzial)

        {

            int updateSuccess = 0;

            var target = _context.Dzial.SingleOrDefault(a => a.IdDzial == id);

            if (target != null)

            {

                _context.Entry(target).CurrentValues.SetValues(dzial);

                updateSuccess = _context.SaveChanges();

            }

            return updateSuccess;

        }


        public int AddNewDzial(Dzial dzial)

        {

            int insertSuccess = 0;

            int maxId = _context.Pracownik.Max(p => p.IdPracownik);



            dzial.IdDzial = (short)(maxId + 1);

            _context.Dzial.Add(dzial);

            insertSuccess = _context.SaveChanges();

            return insertSuccess;



        }



        public int DeleteDzialById(int id)

        {

            int deleteSuccess = 0;

            var dzial = _context.Dzial.SingleOrDefault(a => a.IdDzial == id);

            if (dzial != null)

            {

                _context.Dzial.Remove(dzial);

                deleteSuccess = _context.SaveChanges();

            }

            return deleteSuccess;

        }

    }

}