using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFTestSqlite.Controllers
{
    [Route("api/notes")]
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

        [HttpGet("categories/int/{categoryId}")]
        public IActionResult GetCategory(int categoryId)
        {
            return Ok(
                _context.Categories.Find(categoryId)
            );
        }

        [HttpGet("categories/guid/{categoryId}")]
        public IActionResult GetCategoryByGuid([FromRoute]Guid categoryId)
        {
            return Ok(
                _context.Categories
                    .Single(x => x.Key == categoryId.ToString())
            );
        }

        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            return Ok(
                _context.Categories
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

        [HttpDelete("categories/dictionary")]
        public void DeleteDictionary([FromBody]Guid[] categories)
        {
            // Test deletion using dictionary
            var dict = categories.ToDictionary(x => x.ToString());
            using (var transaction = _context.Database.BeginTransaction())
            {
                _context.Categories.RemoveRange(
                    _context.Categories.Where(c => dict.Keys.Contains(c.Key))
                );
                _context.SaveChanges();
            }
        }

        [HttpPost("notes/multi")]
        public void AddNoteMulti()
        {
            var folder = new Folder {
                Id = 1,
                Name = "Notes"
            };
            var notes = Enumerable.Range(0, 10).Select(x => new Note
            {
                Folder = folder,
                Key = Guid.NewGuid().ToString(),
                Text = $"test {x}"
            });

            _context.AddRange(notes);
            _context.SaveChanges();
        }

        [HttpDelete("folders/{folderId}")]
        public void DeleteFolder(int folderId)
        {
            _context.Folders.Remove(
                _context.Folders
                    .Single(f => f.Id == folderId)
            );
            _context.SaveChanges();
        }

    }
}
