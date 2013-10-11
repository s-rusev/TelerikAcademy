using System;
using System.Collections.Generic;
using System.IO;

namespace _01.TraverseDirectories
{
    public class TraverseDirectories
    {
        static void Main()
        {
            TraverseDirsDFS(@"C:\WINDOWS");
        }

        static void TraverseDirsDFS(string directoryName)
        {
            try
            {
                foreach (string directory in Directory.GetDirectories(directoryName))
                {
                    foreach (string fileName in Directory.GetFiles(directory))
                    {
                        if (fileName.EndsWith(".exe"))
                        {
                            Console.WriteLine(fileName);
                        }
                    }

                    //recursively traverse all directories in each directory.
                    TraverseDirsDFS(directory);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}