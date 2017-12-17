using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Library
{
    public class Value
    {
        private static readonly char delimiter = ';';
        private string _tags;

        [Key]
        public int Key { get; set; }

        public string Data { get; set; }

        [NotMapped]
        public string[] Tags
        {
            get { return _tags.Split(delimiter); }
            set
            {
                _tags = string.Join($"{delimiter}", value);
            }
        }
    }
}
