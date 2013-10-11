using System;
using System.Collections.Generic;
using System.IO;

class SortStringsInFile
{
    public static List<string> GetStringArray()
    {
        List<string> result = new List<string>();

        try
        {
            StreamReader reader = new StreamReader(@"..\..\inputFile.txt");
            Console.WriteLine("File successfully opened.");
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Add(line);
                    line = reader.ReadLine();
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("Can't find first file.");
        }

        return result;
    }
    static void Main()
    {
        List<string> linesToSort = GetStringArray();
        linesToSort.Sort();
        using (StreamWriter output = new StreamWriter("../../output.txt"))
        {
            foreach (var line in linesToSort)
            {
                output.WriteLine(line);
            }
        }
    }
}
