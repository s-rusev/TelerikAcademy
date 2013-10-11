using System;

class MinMaxAvgSumProdForSet
{

    static int Min(params int[] sequence)
    {
        int sequenceLength = sequence.GetLength(0);
        if (sequenceLength > 0)
        {
                int result = sequence[0];
                for (int i = 1; i < sequenceLength; ++i)
                {
                    result = Math.Min(result, sequence[i]);
                }
                return result;
        }
        else
        {
            throw new InvalidOperationException("Length of parameters must be greater than 0");
        }
    }

    static int Max(params int[] sequence)
    {
        int sequenceLength = sequence.GetLength(0);
        if (sequenceLength > 0)
        {
                int result = sequence[0];
                for (int i = 1; i < sequenceLength; i++)
                {
                    result = Math.Max(result, sequence[i]);
                }
                return result;
        }
        else
        {
            throw new InvalidOperationException("Length of parameters must be greater than 0");
        }
    }

    static double Average(params int[] sequence)
    {
        int sum = 0;
        double sequenceLength = sequence.GetLength(0);
        foreach (var num in sequence)
        {
            sum += num;
        }

        return sum / sequenceLength;
    }

    static int Sum(params int[] sequence)
    {
        int sum = 0;
        foreach (var num in sequence)
        {
            sum += num;
        }
        return sum;
    }

    static int Product(params int[] sequence)
    {
        if (sequence.GetLength(0) > 0)
        {
            int product = 1;
            foreach (var num in sequence)
            {
                product *= num;
            }
            return product;
        }
        else
        {
            throw new InvalidOperationException("Length of parameters must be greater than 0");
        }
    }

    static void Main()
    {
        Console.WriteLine("A program that demonstrates methods with variable numbers of arguments.");
        Console.WriteLine(Min(1,2,3,4,-1,-123123,3,123));
        Console.WriteLine(Max(2,3,12312313,-4,0));
        Console.WriteLine(Average(1,2));
        Console.WriteLine(Product(1,2,3));
    }
}
