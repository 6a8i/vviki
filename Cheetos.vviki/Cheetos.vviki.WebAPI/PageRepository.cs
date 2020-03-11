using Cheetos.vviki.WebAPI.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cheetos.vviki.WebAPI
{
    public class PageRepository : IPageRepository
    {
        private readonly VVikiContext _context; 

        public PageRepository(VVikiContext context)
        {
            _context = context;
        }

        private IQueryable<Page> PagesIncludeAll()
        {
            return _context.Page.Include(p => p.Tags).Include(p => p.Paragraphs);
        }

        public Page Select(Guid id)
        {
            return PagesIncludeAll().FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Page> SelectAll()
        {
            return PagesIncludeAll();
        }

        public void Insert(Page page)
        {
            _context.Page.Add(page);
            _context.SaveChanges();
        }

        public void Update(Page page)
        {
            _context.Page.Update(page);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var page = _context.Page.First(p => p.Id == id);
            _context.Page.Remove(page);
            _context.SaveChanges();
        }

        public IEnumerable<Page> SelectByTag(string tag)
        {
            return PagesIncludeAll().Where(p => p.Tags.Any(t => t.Key == tag));
        }

        public IEnumerable<Page> SelectByTag(string tag, string value)
        {
            return PagesIncludeAll().Where(p => p.Tags.Any(t => t.Key == tag && t.Value == value));
        }

        public IEnumerable<Page> SelectByText(string text)
        {
            return PagesIncludeAll().Where(p => p.Title.Contains(text) || p.Paragraphs.Any(pa => pa.Text.Contains(text))); 
        }

        public IEnumerable<string> SelectTags()
        {
            return _context.Tag.Select(t => t.Key).Distinct();
        }

        public IEnumerable<string> SelectTagValues(string tag)
        {
            return _context.Tag.Where(t => t.Key == tag).Select(t => t.Value).Distinct();
        }
    }
}
