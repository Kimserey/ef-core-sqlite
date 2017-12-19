﻿using System.Collections;
using System.Collections.Generic;

namespace Library
{
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
