using System;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    public class Value
    {
        [Key]
        public Guid Key { get; set; }

        public string Data { get; set; }
    }
}
