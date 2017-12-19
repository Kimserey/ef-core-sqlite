using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    public class Note
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Text { get; set; }

        public int FolderId { get; set; }
        [Required]
        public Folder Folder { get; set; }
        public ICollection<NoteCategory> NoteCategories { get; set; }
    }
}
