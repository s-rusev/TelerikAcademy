using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace ExtractingArtists
{
    class DomParser
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalogue.xml");
            XmlNode rootNode = doc.DocumentElement;
            Dictionary<string, int> artistDict = new Dictionary<string, int>();

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var artistName = node["artist"].InnerText;

                if (artistDict.ContainsKey(artistName))
                {
                    artistDict[artistName]++;
                }
                else
                {
                    artistDict.Add(artistName, 1);
                }
            }

            foreach (var item in artistDict)
            {
                Console.WriteLine("Artist: {0} \nNumber of Albums: {1}",
                    item.Key, item.Value);
            }
        }
    }
}