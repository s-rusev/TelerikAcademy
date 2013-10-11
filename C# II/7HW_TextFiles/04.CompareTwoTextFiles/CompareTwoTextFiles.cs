using System;
using System.IO;

class CompareTwoTextFiles
{
    static void SameAndDifferentLines() 
    {
        string resultSame = "";
        string resultDifferent = "";
        try
        {
            StreamReader readerFirst = new StreamReader(@"..\..\FirstTextFile.txt");
            StreamReader readerSecond = new StreamReader(@"..\..\SecondTextFile.txt");
            Console.WriteLine("Files successfully opened.");
            using (readerFirst)
            {
                using (readerSecond)
                {
                    string lineFirst = readerFirst.ReadLine();
                    string lineSecond = readerSecond.ReadLine();
                    int counter = 1;
                    while (lineFirst != null)
                    {
                        if (lineFirst.Equals(lineSecond))
                        {
                            resultSame += counter + " ";
                        }
                        else
                        {
                            resultDifferent += counter + " ";
                        }
                        lineFirst = readerFirst.ReadLine();
                        lineSecond = readerSecond.ReadLine();
                        counter++;
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("Can't find one or more of the files.");
        }
        Console.WriteLine("The same lines are: " + resultSame + "and their count is {0}", resultSame.Split(' ').Length - 1);
        Console.WriteLine("The different lines are: " + resultDifferent + "and their count is {0}", resultDifferent.Split(' ').Length - 1);

    }

    static void Main()
    {
        SameAndDifferentLines();        
    }
}
