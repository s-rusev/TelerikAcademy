using System;

namespace _1.BinaryPasswords
{
    class Program
    {
        static void Main()
        {
            string password = Console.ReadLine();
            int unknownDigitsCount = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] == '*')
                {
                    ++unknownDigitsCount;
                }
            }

            long answer = 1;
            for (int i = 1; i <= unknownDigitsCount; i++)
            {
                answer *= 2;
            }

            Console.WriteLine(answer);
        }
    }
}
