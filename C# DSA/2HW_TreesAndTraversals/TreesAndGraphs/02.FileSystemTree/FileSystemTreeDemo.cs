using System;

namespace _02.FileSystemTree
{
    public class FileSystemTreeDemo
    {
        static void Main()
        {
            string folderPath = @"C:\Windows";
            Console.WriteLine("The size of all files in the folder {0} is:", folderPath);
            Folder testFolder = new Folder(folderPath);
            long filesSize = Folder.FileSizeInFolder(testFolder);
            Console.WriteLine(filesSize);
        }
    }
}
