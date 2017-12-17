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

        public IEnumerable<string> GetTags()
        {
            return _tags.Split(delimiter);
        }

        public void AddTag(string tag)
        {
            _tags = _tags + (string.IsNullOrWhiteSpace(_tags) ? "" : delimiter.ToString()) + tag;
        }
    }
}
