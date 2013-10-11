using System;
using System.Collections.Generic;
using System.Linq;
class MinMaxAvgSumProdForSet
{

    static T Min<T>(params T[] sequence)
    {
        int sequenceLength = sequence.GetLength(0);
        if (sequenceLength > 0)
        {
            dynamic result = sequence.Min();
            return result;
        }
        else
        {
            throw new InvalidOperationException("Length of parameters must be greater than 0");
        }
    }

    static T MaxFromSequence<T>(params T[] sequence)
    {
        int sequenceLength = sequence.GetLength(0);
        if (sequenceLength > 0)
        {
            dynamic result = sequence.Max();
            return result;
        }
        else
        {
            throw new InvalidOperationException("Length of parameters must be greater than 0");
        }
    }

    static T Average<T>(params T[] sequence)
    {
        dynamic sum = 0;
        dynamic sequenceLength = sequence.GetLength(0);
        foreach (var num in sequence)
        {
            sum += num;
        }

        return sum / sequenceLength;
    }

    static T Sum<T>(params T[] sequence)
    {
        dynamic sum = 0;
        foreach (var num in sequence)
        {
            sum += num;
        }
        return sum;
    }

    static T Product<T>(params T[] sequence)
    {
        if (sequence.GetLength(0) > 0)
        {
            dynamic product = 1;
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
        Console.WriteLine("A program that demonstrates methods with variable numbers of arguments and generic types.");
        Console.WriteLine(Min("asd","asdasdasd"));
        Console.WriteLine(Min(1, 2, 3, 4, -1, -123123, 3, 123));
        Console.WriteLine(MaxFromSequence(2, 3, 12312313, -4, 0));
        Console.WriteLine(Average(1, 2.0));
        Console.WriteLine(Product(1, 2, 3));
    }
}
