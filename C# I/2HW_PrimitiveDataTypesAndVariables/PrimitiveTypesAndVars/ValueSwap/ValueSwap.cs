using System;

namespace ValueSwap
{
    public class ValueSwap
    {
        static void Main()
        {
            int num1 = 5;
            int num2 = 10;
            //swapping two variables without a third one
            num1 = num1 + num2;
            num2 = num1 - num2;
            num1 = num1 - num2;
            Console.WriteLine("Swapped values are: " + num1 + " " + num2);
            /* variables for employees:
            string firstName;
            string lastName;
            byte age;
            char gender; // m or f
            uint emplNumber;  
            */
        }
    }
}
