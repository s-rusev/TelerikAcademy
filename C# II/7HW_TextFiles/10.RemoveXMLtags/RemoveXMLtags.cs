using System;
using System.IO;
using System.Text;

class RemoveXMLtags
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"..\..\inputFile.txt");
            Console.WriteLine("File successfully opened.");
            Console.WriteLine("The text without the XML Tags is: ");
            using (reader)
            {
                int charToRead;
                do
                {
                    charToRead = reader.Read();
                    if (charToRead == '>')
                    {
                        StringBuilder resultText = new StringBuilder();
                        while ((charToRead = reader.Read()) != -1 && charToRead != '<')
                        {
                            resultText.Append((char)charToRead);
                        }
                        if (!String.IsNullOrWhiteSpace(resultText.ToString()))
                        {
                            Console.WriteLine(resultText.ToString().Trim());
                        }
                    }
                } while (charToRead != -1);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Input file not found!");
        }

    }
}