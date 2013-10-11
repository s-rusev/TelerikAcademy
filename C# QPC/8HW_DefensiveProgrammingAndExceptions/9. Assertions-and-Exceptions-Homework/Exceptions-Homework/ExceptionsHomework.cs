using System;
using System.Collections.Generic;
using System.Text;

class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] array, int startIndex, int count)
    {
        if (array == null)
        {
            throw new ArgumentNullException("array", "array can't be null.");
        }

        if (startIndex < 0)
        {
            throw new ArgumentOutOfRangeException("startIndex", "startIndex can't be negative number.");
        }

        if (startIndex > array.Length)
        {
            throw new ArgumentOutOfRangeException("startIndex", 
                "startIndex can't be larger than the length of the array.");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("length", "length can't be negative number.");
        }

        if (startIndex + count > array.Length)
        {
            throw new ArgumentOutOfRangeException("The sum of startIndex and length must be less than the length of the array.");
        }

        if (count == 0)
        {
            return new T[0];
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(array[i]);
        }
        return result.ToArray();
    }

    public static string ExtractEnding(string str, int length)
    {
        if (length > str.Length)
        {
            throw new ArgumentOutOfRangeException("length", "length can't be bigger than the length of the string.");
        }

        if (length < 0)
        {
            throw new ArgumentOutOfRangeException("length", "length cannot be less than zero.");
        }

        if (str == null)
        {
            throw new ArgumentException("str can't be null.", "str");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - length; i < str.Length; i++)
        {
            result.Append(str[i]);
        }
        return result.ToString();
    }

    public static bool CheckPrime(int number)
    {
        if (number <= 1)
        {
            throw new ArgumentOutOfRangeException("number", "number must be bigger than 1.");
        }

        bool isPrime = true;

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                isPrime = false;
                break;
            }
        }

        return isPrime;
    }

    static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(String.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(String.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(String.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
        //Console.WriteLine(ExtractEnding("Hi", 100));

        try
        {
            CheckPrime(23);
            Console.WriteLine("23 is prime.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("23 is not prime");
        }

        try
        {
            CheckPrime(33);
            Console.WriteLine("33 is prime.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("33 is not prime");
        }

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
