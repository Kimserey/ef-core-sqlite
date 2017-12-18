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
    public class NotesController : Controller
    {
        private ValueDbContext _context;

        public NotesController(ValueDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _context.Notes
                    .Include(x => x.NoteCategories)
                    .Select(x => new
                    {
                        id = x.Id,
                        note = x.Text,
                        categories = x.NoteCategories.Select(c => c.CategoryId)
                    })
            );
        }

        [HttpPost]
        public void Post([FromBody]Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        [HttpPost("link")]
        public void Link([FromBody]NoteCategory link)
        {
            _context.Link.Add(link);
            _context.SaveChanges();
        }

        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            return Ok(
                _context.Categories
            );
        }

        [HttpPost("categories")]
        public void Post([FromBody]Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}
