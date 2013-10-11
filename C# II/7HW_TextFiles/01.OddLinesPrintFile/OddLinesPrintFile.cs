using System;
using System.IO;

class OddLinesPrintFile
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"..\..\somefile.txt");
            Console.WriteLine("File successfully opened.");

            using (reader)
            {
                int lineNumber = 1;
                string line = reader.ReadLine();
                while (line != null)
                {

                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine("Line {0}: {1}", lineNumber, line);
                        line = reader.ReadLine();
                    }
                    lineNumber++;
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("Can't find 'somefile.txt'.");
        }

    }
}

