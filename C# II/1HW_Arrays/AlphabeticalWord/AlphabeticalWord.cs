using System;

//Write a program that creates an array containing all letters from the alphabet 
//(A-Z). Read a word from the console and print the index of each of its letters in the array.

class AlphabeticalWord
{
    static void Main()
    {
        Console.WriteLine("A program to put char codes of the alphabet (a-z) in an array and then print the codes of the letters from a word");
        char[] alphabet = new char[26];
        for (int i = 0; i < alphabet.Length; i++)
        {
            alphabet[i] = (char)(i + (int)'a');
        }

        Console.WriteLine("Enter a word: ");
        string input = Console.ReadLine();
        char[] inputCharArr = input.ToCharArray();
        for (int i = 0; i < inputCharArr.Length; i++)
        {
            int index = inputCharArr[i] - (int)'a';
            Console.WriteLine("The letter '{0}' has index: {1} in the alphabetical array", inputCharArr[i], index);
        }
        
    }
}

