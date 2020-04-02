using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using WebApplication5.Models;
using WebApplication5.Repositories;

namespace WebApplication5.Controllers

{

    [Route("api/[controller]")]

    public class PracownikController : Controller

    {

        private IPracownikRepository pracownicy;

        public PracownikController(firmaContext context)

        {

            pracownicy = new PracownikRepository(context);

        }

        public IActionResult Index()

        {
            return Ok(pracownicy.GetPracownik());
        }
       
    }

}