using System;
using System.Linq;

//You are given an array of strings. Write a method that sorts the 
//array by the length of its elements (the number of characters composing them).

class StringArraySort
{
    static void Main()
    {
        Console.WriteLine("A program that sorts an array of strings by their lenghts.");
        Console.WriteLine("Enter number of words: ");
        int n = int.Parse(Console.ReadLine());
        string[] words = new string[n];
        Console.WriteLine("Enter the words: ");
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = Console.ReadLine();
        }
        Array.Sort(words, delegate(string first, string second) { return first.Length.CompareTo(second.Length); });
        Console.WriteLine("The sorted words are: ");
        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}
