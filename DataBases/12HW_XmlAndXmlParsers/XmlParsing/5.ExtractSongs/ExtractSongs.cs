using System;
using System.Xml;

namespace _5.ExtractSongs
{
    public class ExtractSongs
    {
        static void Main()
        {
            Console.WriteLine("All songs titles in the xml:");
            using (XmlReader reader = XmlReader.Create("../../catalogue.xml"))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "title"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }
    }
}