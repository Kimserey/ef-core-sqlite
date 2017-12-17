using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFTestSqlite.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private ValueDbContext _context;

        public ValuesController(ValueDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Values.ToList());
        }

        [HttpPost]
        public void Post()
        {
            var value = new Value
            {
                Data = "hello",
                Tags = new string[] {
                    "test1",
                    "test2"
                }
            };

            _context.Values.Add(value);
            _context.SaveChanges();
        }
    }
}
