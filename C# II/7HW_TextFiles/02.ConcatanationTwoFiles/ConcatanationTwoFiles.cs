using System;
using System.IO;

class ConcatanationTwoFiles
{
    static void Main()
    {

        using (StreamWriter output = new StreamWriter("../../output.txt"))
        {
            try
            {
                StreamReader reader = new StreamReader(@"..\..\FirstTextFile.txt");
                Console.WriteLine("File successfully opened.");
                using (reader)
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        line = reader.ReadLine();
                        output.WriteLine(line);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("Can't find first file.");
            }

            try
            {
                StreamReader reader = new StreamReader(@"..\..\SecondTextFile.txt");
                Console.WriteLine("File successfully opened.");
                using (reader)
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        line = reader.ReadLine();
                        output.WriteLine(line);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("Can't find second file.");
            }

        }
    }
}
