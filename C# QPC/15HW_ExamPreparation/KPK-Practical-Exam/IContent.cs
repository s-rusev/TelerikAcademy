using System;

namespace CatalogFreeContent
{
    public interface IContent : IComparable
    {
        string Title { get; set; }

        string Author { get; set; }

        Int64 Size { get; set; }

        string Url { get; set; }

        ContentType Type { get; set; }

        string TextRepresentation { get; set; }
    }
}
