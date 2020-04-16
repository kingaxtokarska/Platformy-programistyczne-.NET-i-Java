using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1
{
    class BazadanychSetup
    {
        public BazadanychSetup()
        {
            DbContext db = new DbContext(new DbContextOptions("Server=localhost;Port=3306;Database=firma;Uid=root;Pwd=root;"));
        }
    }
}
