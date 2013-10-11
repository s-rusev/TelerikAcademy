using System;

class SignOfProduct
{
    static void Main()
    {
        Console.WriteLine("Enter three numbers: ");
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int num3 = int.Parse(Console.ReadLine());
        if (num1 == 0 || num2 == 0 || num3 == 0)
        {
            Console.WriteLine("Positive sign");
        }
        else
        {
            if (num1 > 0)
            {
                if (num2 > 0)
                {
                    if (num3 > 0)
                    {
                        Console.WriteLine("Positive sign");
                    }
                    else
                    {
                        Console.WriteLine("Negative sign");
                    }
                }
                else
                {
                    if (num3 > 0)
                    {
                        Console.WriteLine("Negative sign");
                    }
                    else
                    {
                        Console.WriteLine("Positive sign");
                    }
                }
            }
            else
            {
                if (num2 > 0)
                {
                    if (num3 > 0)
                    {
                        Console.WriteLine("Negative sign");
                    }
                    else
                    {
                        Console.WriteLine("Positive sign");
                    }
                }
                else
                {
                    if (num3 > 0)
                    {
                        Console.WriteLine("Positive sign");
                    }
                    else
                    {
                        Console.WriteLine("Negative sign");
                    }
                }
            }
        }
    }
}


