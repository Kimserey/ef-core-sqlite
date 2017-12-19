using System.Collections.Generic;

namespace Library
{
    public class Note
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Text { get; set; }
        public ICollection<NoteCategory> NoteCategories { get; set; }
    }
}
