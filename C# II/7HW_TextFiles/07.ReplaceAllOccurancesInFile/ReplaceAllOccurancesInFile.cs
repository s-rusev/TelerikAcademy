using System;
using System.IO;

class ReplaceAllOccurancesInFile
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"..\..\inputFile.txt");
            Console.WriteLine("File successfully opened.");
            using (reader)
            {
                using (StreamWriter output = new StreamWriter("../../output.txt"))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        output.WriteLine(line.Replace("start", "finish"));
                        line = reader.ReadLine();
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("Can't find first file.");
        }
        File.Replace("../../output.txt", "../../inputFile.txt", "../../backup.txt");
    }
}

