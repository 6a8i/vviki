using System;
using System.Collections.Generic;

namespace Cheetos.vviki.WebAPI
{
    public class Page
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Paragraph> Paragraphs { get; set; }
    }

    public class Tag
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class Paragraph
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}
