using System;
using System.Xml.Linq;
using System.Linq;

namespace _6.ExtractSongsLinq
{
    public class ExtractSongs
    {
        static void Main()
        {
            XDocument xmlDoc = XDocument.Load("../../catalogue.xml");
            var songs =
                       from song in xmlDoc.Descendants("song")
                       select new
                       {
                           Title = song.Element("title").Value
                       };

            Console.WriteLine("All songs titles in the xml:");

            foreach (var song in songs)
            {
                Console.WriteLine("Song Title: {0}", song.Title);
            }
        }
    }
}