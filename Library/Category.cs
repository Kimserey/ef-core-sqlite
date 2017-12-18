using System.Collections.Generic;

namespace Library
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<NoteCategory> NoteCategories { get; set; }
    }
}
