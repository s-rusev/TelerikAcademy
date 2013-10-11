using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace _4.DeleteAlbums
{
    public class DeleteAlbums
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalogue.xml");

            foreach (XmlNode node in doc.DocumentElement)
            {
                if (decimal.Parse(node["price"].InnerText) > 20)
                {
                    XmlNode parent = node.ParentNode;
                    parent.RemoveChild(node);
                }
            }

            Console.WriteLine("XML document modified.");
         //   Console.WriteLine(doc.OuterXml);

            doc.Save("../../newCatalogue.xml");

            XmlDocument newDoc = new XmlDocument();
            newDoc.Load("../../newCatalogue.xml");
            XmlNode rootNode = newDoc.DocumentElement;
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