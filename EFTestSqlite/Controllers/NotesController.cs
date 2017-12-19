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
                        key = x.Key,
                        categories = x.NoteCategories.Select(c => new { id = c.Category.Id, name = c.Category.Name })
                    })
            );
        }

        [HttpPost]
        public void Post([FromBody]Note note)
        {
            note.Key = Guid.NewGuid().ToString();
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        [HttpPost("links")]
        public void PostLink([FromBody]NoteCategory link)
        {
            _context.Links.Add(link);
            _context.SaveChanges();
        }

        [HttpDelete("links")]
        public void DeleteLink([FromBody]NoteCategory link)
        {
            _context.Links.Remove(link);
            _context.SaveChanges();
        }

        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            return Ok(
                _context.Categories
                    .Include(x => x.NoteCategories)
                    .Select(x => new
                    {
                        id = x.Id,
                        name = x.Name,
                        key = x.Key,
                        notes = x.NoteCategories.Select(n => new { id = n.Note.Id, text = n.Note.Text })
                    })
            );
        }

        [HttpPost("categories")]
        public void Post([FromBody]Category category)
        {
            category.Key = Guid.NewGuid().ToString();
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        [HttpPut("categories")]
        public void Put([FromBody]Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        [HttpDelete("categories/{categoryId}")]
        public void Delete(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
