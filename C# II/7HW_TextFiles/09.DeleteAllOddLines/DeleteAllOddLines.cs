using System;
using System.IO;

class DeleteAllOddLines
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"..\..\inputFile.txt");
            Console.WriteLine("File successfully opened.");

            using (reader)
            {
                using (StreamWriter output = new StreamWriter("../../outputFile.txt"))
                {
                    int lineNumber = 1;
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        line = reader.ReadLine();
                        if (lineNumber % 2 != 0)
                        {
                            output.WriteLine(line);
                        }
                        lineNumber++;
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("Can't find the input file!");
        }

        File.Replace("../../outputFile.txt", "../../inputFile.txt", "../../backup.txt");

    }
}

