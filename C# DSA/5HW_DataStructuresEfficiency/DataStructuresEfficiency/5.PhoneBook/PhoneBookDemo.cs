using System;
using System.Collections.Generic;

namespace _5.PhoneBook
{
    public class PhoneBookDemo
    {
        static void Main()
        {
            //Actually we dont have this task for homework - downloaded the old presentation...
            //that's why it's almost finished (and this is the same task as the previous actually)
            //
            //Moral of the story - always update the source/presentations/docs before starting work :)))

            string filePath = "../../phones.txt";
            string[] fileLines = PhoneBookCommandManager.GetLinesFromTextFile(filePath);
            PhoneBook phonebook = PhoneBookCommandManager.CreatePhoneBook(fileLines);

            IEnumerable<string> phonesName = phonebook.PhonesByName("0888 12 34 56");
            foreach (var item in phonesName)
            {
                Console.WriteLine(item);
            }
        }
    }
}
