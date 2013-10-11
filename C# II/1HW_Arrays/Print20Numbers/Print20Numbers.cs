using System;

//Write a program that allocates array of 20 integers and initializes
//each element by its index multiplied by 5. Print the obtained array on the console.

class Print20Numbers
{
    static void Main()
    {
        Console.WriteLine("Program to print 20 numbers - each number is index of array multipled by 5:");
        int[] arr = new int[20];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i*5;
            Console.WriteLine(arr[i]);
        }
    }
}

