using System;
using System.Collections.Generic;

namespace Cheetos.vviki.WebAPI
{
    public class Page
    {
        public Guid Id { get; set; }
        public Dictionary<string, string> Tags { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> Paragraphs { get; set; }
    }
}
