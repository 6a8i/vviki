using System;
using System.Collections.Generic;

namespace Cheetos.vviki.WebAPI
{
    public interface IPageRepository
    {
        void Delete(Guid id);
        void Insert(Page page);
        Page Select(Guid id);
        IEnumerable<Page> SelectAll();
        IEnumerable<Page> SelectByTag(string tag);
        IEnumerable<Page> SelectByTag(string tag, string value);
        IEnumerable<Page> SelectByText(string text);
        IEnumerable<string> SelectTags();
        IEnumerable<string> SelectTagValues(string tag);
        void Update(Page page);
    }
}