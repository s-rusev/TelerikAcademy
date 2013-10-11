using System;
using System.IO;
using System.Security;

class PrintTextFromFile
{
    static void ReadFile(string filePath)
    {
        try
        {
            string fileContent = File.ReadAllText(filePath);
            Console.WriteLine("The content of the file is: ");
            Console.WriteLine(fileContent);
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("The entered file path is too long!");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The file path contains a directory that cannot be found!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file '{0}' was not found!", filePath);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("No file path is given!");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The entered file path is not correct!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Unauthorized access to the file");
        }
        catch (SecurityException)
        {
            Console.WriteLine("You don't have the required permission to access this file!");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Invalid file path format!");
        }
        catch (IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
    }

    static void Main()
    {
        Console.Write("Enter the full path of the file you want to read: ");
        string filePath = Console.ReadLine();
        ReadFile(filePath);
    }
}