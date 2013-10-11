using System;
using System.IO;

namespace _02.FileSystemTree
{
    public class Folder
    {
        private string name;
        private File[] files;
        private Folder[] childFolders;

        public Folder(string path)
        {
            DirectoryInfo directoryPath = null;

            try
            {
                directoryPath = new DirectoryInfo(path);
            }
            catch (Exception exc)
            {
                throw new ArgumentException("Invalid path for creating folder! " + exc.Message);
            }

            this.name = directoryPath.Name;
            this.files = GetFiles(directoryPath);
            this.childFolders = GetFolders(directoryPath);
        }

        private File[] GetFiles(DirectoryInfo directory)
        {
            FileInfo[] filesInFolder = directory.GetFiles();
            File[] filesInDirectory = new File[filesInFolder.Length];

            for (int index = 0; index < filesInFolder.Length; index++)
            {
                filesInDirectory[index] = new File(filesInFolder[index].FullName, filesInFolder[index].Length);
            }

            return filesInDirectory;
        }

        private Folder[] GetFolders(DirectoryInfo directory)
        {
            Folder[] foldersInDirectory;

            try
            {
                DirectoryInfo[] childDirectories = directory.GetDirectories();
                foldersInDirectory = new Folder[childDirectories.Length];
                for (int index = 0; index < childDirectories.Length; index++)
                {
                    foldersInDirectory[index] = new Folder(childDirectories[index].FullName);
                }
            }
            catch (UnauthorizedAccessException) //unauthorized to view folder contents, don't generate children for it then
            {
                foldersInDirectory = null;
            }

            return foldersInDirectory;
        }

        public static long FileSizeInFolder(Folder folder)
        {
            long result = folder.GetFilesSizes();

            if (folder.childFolders != null)
            {
                foreach (var childFolder in folder.childFolders)
                {
                    //recursively get the sizes of the child folders
                    result += FileSizeInFolder(childFolder);
                }
            }

            return result;
        }

        private long GetFilesSizes()
        {
            long filesSize = 0;

            foreach (File file in this.files)
            {
                filesSize += file.Size;
            }

            return filesSize;
        }
    }
}