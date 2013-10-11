using System;
using System.Linq;
using System.Text;

class CalculationMenu
{
    static void PrintMenu()
    {
        Console.WriteLine("Choose a number: ");
        Console.WriteLine("1. Reverse the digits of a number.");
        Console.WriteLine("2. Calculate the avarage of a sequence of integers.");
        Console.WriteLine("3. Solve a linear equation a * x + b = 0 .");
        Console.WriteLine("4. Exit.");
    }

    static void ProcessTask(int task)
    {
        if (task <= 0 || task > 4)
        {
            Console.WriteLine("The chosen task is invalid.");
        }
        else if (task == 1)
        {
            int number;
            do
            {
                Console.Write("Enter a non-negative number: ");
                number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    Console.WriteLine("The number should be non-negative!");
                }
            } while (number < 0);
            decimal reversed = decimal.Parse(ReverseNum(number));
            Console.WriteLine("The reversed number is: {0}", reversed);

        }
        else if (task == 2)
        {
            int sequenceLength;
            do
            {
                Console.Write("Enter the length of the integer sequence: ");
                sequenceLength = int.Parse(Console.ReadLine());
                if (sequenceLength <= 0)
                {
                    Console.WriteLine("The length should be greater than zero!");
                }
            } while (sequenceLength <= 0);

            int[] sequence = new int[sequenceLength];
            Console.WriteLine("Enter the elements of the sequence:");

            for (int i = 0; i < sequenceLength; i++)
            {
                sequence[i] = int.Parse(Console.ReadLine());
            }

            double average = CalculateAverage(sequence);
            Console.WriteLine("The average of the sequence is: {0}", average);

        }
        else if (task == 3)
        {
            Console.WriteLine("Enter the coefficients of the equation:");

            double a;
            do
            {
                Console.Write("a = ");
                a = double.Parse(Console.ReadLine());
                if (a == 0)
                {
                    Console.WriteLine("The value of \"a\" should not be equal to zero!");
                }
            } while (a == 0);
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());

            double result = -b / a;
            Console.WriteLine("The root x = {0}", result);

        }
    }

    static string ReverseNum(decimal number)
    {
        return new string(number.ToString().ToCharArray().Reverse().ToArray());
    }

    static double CalculateAverage(int[] arr)
    {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        double result = sum / (arr.Length);
        return result;
    }

    static void Main()
    {
        int taskNumber;
        do
        {
            PrintMenu();
            string input = Console.ReadLine();
            taskNumber = int.Parse(input);
            ProcessTask(taskNumber);
            if (taskNumber > 0 && taskNumber < 4)
            {
                Console.WriteLine("Task executed!");
            }
            else if (taskNumber == 4)
            {
                Console.WriteLine("Goodbye!");
            }
        } while (taskNumber != 4);
    }
}
