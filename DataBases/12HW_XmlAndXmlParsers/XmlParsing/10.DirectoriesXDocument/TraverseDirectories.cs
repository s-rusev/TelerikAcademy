using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace _10.DirectoriesXDocument
{
    public class TraverseDirectories
    {
        static void Main()
        {
            string folderLocation = "../../";
            DirectoryInfo dir = new DirectoryInfo(folderLocation);
            var doc = new XDocument(CreateXml(dir));

            Console.WriteLine(doc.ToString());
        }

        private static XElement CreateXml(DirectoryInfo dir)
        {
            var xmlInfo = new XElement("MyDirectories");

            foreach (var file in dir.GetFiles())
            {
                xmlInfo.Add(new XElement("file", new XAttribute("name", file.Name)));
            }

            var subdirectories = dir.GetDirectories().ToList().OrderBy(d => d.Name);

            foreach (var subDir in subdirectories)
            {
                xmlInfo.Add(CreateSubdirectoryXml(subDir));
            }

            return xmlInfo;
        }

        private static XElement CreateSubdirectoryXml(DirectoryInfo dir)
        {
            var xmlInfo = new XElement("dir", new XAttribute("name", dir.Name));

            foreach (var file in dir.GetFiles())
            {
                xmlInfo.Add(new XElement("file", new XAttribute("name", file.Name)));
            }

            var subdirectories = dir.GetDirectories().ToList().OrderBy(d => d.Name);
            foreach (var subDir in subdirectories)
            {
                xmlInfo.Add(CreateSubdirectoryXml(subDir));
            }

            return xmlInfo;
        }
    }
}