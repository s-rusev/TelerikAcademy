using System;
using System.Collections.Generic;
using System.IO;

namespace _5.PhoneBook
{
    public static class PhoneBookCommandManager
    {
        public static PhoneBook CreatePhoneBook(string[] lines) 
        {
            PhoneBook phonebook = new PhoneBook(lines);
            return phonebook;
        }

        public static string[] GetLinesFromTextFile(string filePath)
        {
            string[] lines = null;

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string text = reader.ReadToEnd();
                    char[] seperators = new char[] { '\r', '\n' };
                    lines = text.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read: " + e.Message);
            }

            return lines;
        }
    }
}
