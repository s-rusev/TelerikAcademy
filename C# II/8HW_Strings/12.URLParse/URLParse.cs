using System;

class ExtractsURL
{
    static void Main()
    {
        Console.WriteLine("A program that parses given URL address.");
        Console.WriteLine("Enter a valid URL addres in the format [protocol]://[server]/[resource] ");
        string urlString = Console.ReadLine();
        Uri uri = new Uri(urlString); //new Uri("http://www.devbg.org/forum/index.php");
        Console.WriteLine(uri.Scheme);
        Console.WriteLine(uri.Host);
        Console.WriteLine(uri.AbsolutePath);
    }
}