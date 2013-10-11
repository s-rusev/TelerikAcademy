using System;

//Write a method that returns the index of the first element in array 
//that is bigger than its neighbors, or -1, if there’s no such element.
//Use the method from the previous exercise.

class FirstIndexBiggerNeighbour
{
    static bool IsBiggerNeighbour(int[] array, int position) //checks the first found element is bigger than it's two neighbours(if any)
    {
        bool isBigger = false;
        if (position > 0 && position <= array.Length - 2)
        {
            if (array[position - 1] < array[position] && array[position + 1] < array[position])
            {
                isBigger = true;
            }
        }
        return isBigger;
    }

    static int IndexElementBiggerThanNeighbours(int[] arr)
    {
        int pos = 0;
        bool foundSolution = false;
        for (int i = 1; i <= arr.Length - 2; i++)
        {
            if (IsBiggerNeighbour(arr, i))
            {
                pos = i;
                foundSolution = true;
                break;
            }
        }
        if (!foundSolution)
        {
            pos = -1;
        }
        return pos;
    }

    static void Main()
    {
        Console.WriteLine("Enter numbers of elements for the array: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter the elements: ");
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        int firstIndex = IndexElementBiggerThanNeighbours(arr);
        Console.WriteLine("The index of the first element bigger than its neighbours is {0}", firstIndex);

    }
}
