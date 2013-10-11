using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a number between 0 and 999: ");
        ushort input = ushort.Parse(Console.ReadLine());
        byte ones = (byte)(input % 10);
        input /= 10;
        byte tens = (byte)(input % 10);
        input /= 10;
        byte hundreds = (byte)(input % 10);
        switch (hundreds)
        {
            case 1: Console.Write("One hundred ");
                break;
            case 2: Console.Write("Two hundred ");
                break;
            case 3: Console.Write("Three hundred ");
                break;
            case 4: Console.Write("Four hundred ");
                break;
            case 5: Console.Write("Five hundred ");
                break;
            case 6: Console.Write("Six hundred ");
                break;
            case 7: Console.Write("Seven hundred ");
                break;
            case 8: Console.Write("Eight hundred ");
                break;
            case 9: Console.Write("Nine hundred ");
                break;
            case 0: break;
        }
        switch (tens)
        {
            case 1:
                if (hundreds == 0)
                {
                    break;
                }
                else 
                {
                    Console.Write("and ");
                }
                break;
            case 2: Console.Write("twenty ");
                break;
            case 3: Console.Write("thirty ");
                break;
            case 4: Console.Write("forty ");
                break;
            case 5: Console.Write("fifty ");
                break;
            case 6: Console.Write("sixty ");
                break;
            case 7: Console.Write("seventy ");
                break;
            case 8: Console.Write("eighty ");
                break;
            case 9: Console.Write("ninety ");
                break;
            case 0:
                if (hundreds == 0)
                {
                    break;
                }
                else if (ones != 0)
                {
                    Console.Write("and ");
                }
                break;
        }
        switch (ones)
        {
            case 1:
                if (tens == 1)
                {
                    Console.WriteLine("eleven");
                }
                else if (tens == 0 && hundreds == 0)
                    {
                        Console.WriteLine("One");
                    }
                    else if (tens == 0)
                        {
                            Console.WriteLine("one");
                        }
                        else 
                        {
                            Console.WriteLine("one"); 
                        }
                break;
            case 2:
                if (tens == 1) 
                {
                    Console.WriteLine("twelve"); 
                }
                else if ((tens == 0) && (hundreds == 0)) 
                    {
                        Console.WriteLine("Two"); 
                    }
                    else if (tens == 0) 
                        {
                            Console.WriteLine("two"); 
                        }
                        else
                        {
                            Console.WriteLine("two"); 
                        }
                break;
            case 3:
                if (tens == 1)
                {
                    Console.WriteLine("thirteen"); 
                }
                else if ((tens == 0) && (hundreds == 0)) 
                    {
                        Console.WriteLine("Three");
                    }
                    else if (tens == 0) 
                        {
                            Console.WriteLine("three");
                        }
                        else 
                        {
                            Console.WriteLine("three");
                        }
                break;
            case 4:
                if (tens == 1)
                {
                    Console.WriteLine("fourteen"); 
                }
                else if ((tens == 0) && (hundreds == 0))
                    {
                        Console.WriteLine("Four"); 
                    }
                    else if (tens == 0)
                        {
                            Console.WriteLine("four");
                        }
                        else
                        {
                            Console.WriteLine("four");
                        }
                break;
            case 5:
                if (tens == 1) 
                {
                    Console.WriteLine("fifteen"); 
                }
                else if ((tens == 0) && (hundreds == 0)) 
                    {
                        Console.WriteLine("Five"); 
                    }
                    else if (tens == 0) 
                        {
                            Console.WriteLine("five");
                        }
                        else
                        {
                            Console.WriteLine("five");
                        }
                break;
            case 6:
                if (tens == 1) 
                {
                    Console.WriteLine("sixteen"); 
                }
                else if ((tens == 0) && (hundreds == 0)) 
                    {
                        Console.WriteLine("Six"); 
                    }
                    else if (tens == 0) 
                        {
                            Console.WriteLine("six");
                        }
                        else 
                        {
                            Console.WriteLine("six");
                        }
                break;
            case 7:
                if (tens == 1)
                {
                    Console.WriteLine("seventeen"); 
                }
                else if ((tens == 0) && (hundreds == 0)) 
                {
                    Console.WriteLine("Seven"); 
                }
                    else if (tens == 0) 
                        {
                        Console.WriteLine("seven");
                        }
                        else 
                        {
                            Console.WriteLine("seven");
                        }
                break;
            case 8:
                if (tens == 1) 
                {
                    Console.WriteLine("eighteen"); 
                }
                else if ((tens == 0) && (hundreds == 0)) 
                    {
                        Console.WriteLine("Eight"); 
                    }
                    else if (tens == 0) 
                        {
                            Console.WriteLine("eight");
                        }
                        else
                        {
                            Console.WriteLine("eight");
                        }
                break;
            case 9:
                if (tens == 1) 
                {
                    Console.WriteLine("nineteen"); 
                }
                else if ((tens == 0) && (hundreds == 0)) 
                    {
                        Console.WriteLine("Nine");
                    }
                    else if (tens == 0) 
                        {
                            Console.WriteLine("nine");
                        }
                        else 
                        {
                            Console.WriteLine("nine");
                        }
                break;
            case 0:
                if ((tens == 0) && (hundreds == 0))
                {
                    Console.WriteLine("Zero");
                }
                else
                { 
                    break; 
                }
                break;
        }
    }
}

