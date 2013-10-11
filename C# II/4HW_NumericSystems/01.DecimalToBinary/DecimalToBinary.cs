using System;

//A program that converts a decimal number to its binary representation

class DecimalToBinary

{
    static void Main()
    {
        Console.WriteLine("Enter a decimal number: ");
        int input = int.Parse(Console.ReadLine());
        Console.WriteLine("The number to its binary representation using Convert.ToString()->{0}",Convert.ToString(input, 2));
        string result = "";
        while (input > 0)
        {
            result = (input % 2) + result;
            input /= 2;
        }
        Console.WriteLine("The number to its binary representation using my algorithm->{0}",result);
    }
}
