using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTestSqlite
{
    public class NoteService
    {
        public Task AddNote(string text)
        {
            return Task.CompletedTask;
        }

        public Task DeleteNote(int id)
        {
            return Task.CompletedTask;
        }
    }
}
