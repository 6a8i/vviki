using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cheetos.vviki.WebAPI
{
    public class PageRepository
    {
        private string _repoFolder => "repo";

        private string FormatFileName(string id) => $"{_repoFolder}\\{id}.json";

        public Page Select(string id)
        {
            using StreamReader file = File.OpenText(FormatFileName(id));
            JsonSerializer serializer = new JsonSerializer();
            return (Page)serializer.Deserialize(file, typeof(Page));
        }

        public IEnumerable<Page> SelectAll()
        {
            var loadedPages = new List<Page>();

            var files = Directory.GetFiles(_repoFolder);

            foreach(string f in files)
            {
                string id = Path.GetFileNameWithoutExtension(f);
                loadedPages.Add(Select(id));
            }

            return loadedPages;
        }

        private void InsertAsIs(Page page)
        {
            using StreamWriter file = File.CreateText(FormatFileName(page.Id.ToString()));
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.Serialize(file, page);
        }

        public void Insert(Page page)
        {
            page.Id = Guid.NewGuid().ToString();
            InsertAsIs(page);
        }

        public void Update(Page page)
        {
            Delete(page.Id);
            InsertAsIs(page);
        }

        public void Delete(string id)
        {
            File.Delete(FormatFileName(id));
        }

        public IEnumerable<Page> SelectByTag(string tag)
        {
            return SelectAll().Where(p => p.Tags.ContainsKey(tag));
        }

        public IEnumerable<Page> SelectByTag(string tag, string value)
        {
            return SelectAll().Where(p => p.Tags.ContainsKey(tag) && p.Tags[tag].Contains(value));
        }

        public IEnumerable<Page> SelectByText(string text)
        {
            return SelectAll().Where(p => p.Title.Contains(text) || p.Paragraphs.Any(pa => pa.Contains(text)));
        }

        public IEnumerable<string> SelectTags()
        {
            return SelectAll().SelectMany(p => p.Tags.Keys).Distinct();
        }

        public IEnumerable<string> SelectTagValues(string tag)
        {
            return SelectAll().Where(p => p.Tags.ContainsKey(tag)).Select(p => p.Tags[tag]).Distinct();
        }



        //Repository.Clone("https://github.com/EdiWang/EnvSetup.git", @"D:\EnvSetup");

        //using (var repo = new Repository(@"D:\GitHub\Moonglade"))
        //{
        //    repo.Commit("bla bla", new Signature(), new Signature());

        //        repo.Network.Pull

        //}

    }
}
