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

    public class DzialController : Controller

    {

        private IDzialRepository dzialy;

        public DzialController(firmaContext context)

        {

            dzialy = new DzialRepository(context);

        }

        public IActionResult Index()

        {
            return Ok(dzialy.GetDzial());
        }

    }

}