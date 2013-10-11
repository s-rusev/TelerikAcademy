using System;
using System.Collections.Generic;
using System.Linq;

class PolynomialsOperations
{
    static int[] SubstractPolynomials(int[] first, int[] second)
    {
        int[] result = new int[Math.Max(first.Length, second.Length)];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = first[i] - second[i];
        }
        return result;
    }
    static int[] AddPolynomials(int[] first, int[] second)
    {
        int[] result = new int[Math.Max(first.Length, second.Length)];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = first[i] + second[i];
        }
        return result;
    }


    static void Main()
    {
        Console.WriteLine("A program for adding polynomials");
        Console.WriteLine("Enter the power N of the bigger polynomial: ");
        int n = int.Parse(Console.ReadLine());
        int[] firstPoly = new int[n];
        int[] secondPoly = new int[n];
        Console.WriteLine("Enter N coefficients for first polynom");
        for (int i = 0; i < firstPoly.Length; i++)
        {
            firstPoly[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Enter N coefficients for second polynom");
        for (int i = 0; i < secondPoly.Length; i++)
        {
            secondPoly[i] = int.Parse(Console.ReadLine());
        }
        int[] resultAdding = AddPolynomials(firstPoly, secondPoly);
        int[] resultSubstraction = SubstractPolynomials(firstPoly, secondPoly);
        Console.WriteLine("After adding the polynomials the result coefficients are: ");
        foreach (var item in resultAdding)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("After substraction the polynomials the result coefficients are: ");
        foreach (var item in resultSubstraction)
        {
            Console.WriteLine(item);
        }
    }
}
