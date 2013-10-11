using System;
using System.IO;

class LineNumbersFile
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"..\..\inputfile.txt");
            Console.WriteLine("File successfully open.");

            using (StreamWriter output = new StreamWriter("../../output.txt"))
            {
                using (reader)
                {
                    int lineNumber = 1;
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        if (lineNumber % 2 != 0)
                        {
                            output.WriteLine("Line {0}: {1}", lineNumber, line);
                            line = reader.ReadLine();
                        }
                        lineNumber++;
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("Can't find 'somefile.txt'.");
        }

    }
}
