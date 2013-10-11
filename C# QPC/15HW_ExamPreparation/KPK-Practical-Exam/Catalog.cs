using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace CatalogFreeContent
{
    class Catalog : ICatalog
    {
        private readonly MultiDictionary<string, IContent> url;
        private readonly OrderedMultiDictionary<string, IContent> title;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.title = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.url = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        public void Add(IContent content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.Url, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            IEnumerable<IContent> contentToList = from c in this.title[title] select c;

            return contentToList.Take(numberOfContentElementsToList);
        }

        public int UpdateContent(string old, string newUrl)
        {
            int elementsCount = 0;

            List<IContent> contentToList = this.url[old].ToList();

            foreach (Content content in contentToList)
            {
                this.title.Remove(content.Title, content);
                elementsCount++;
            }
            this.url.Remove(old);

            foreach (IContent content in contentToList)
            {
                content.Url = newUrl;
            }

            foreach (IContent content in contentToList)
            {
                this.title.Add(content.Title, content);
                this.url.Add(content.Url, content);
            }

            return elementsCount;
        }
    }
}