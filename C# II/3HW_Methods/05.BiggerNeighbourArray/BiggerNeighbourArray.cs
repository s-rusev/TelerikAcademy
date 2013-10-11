using System;

//Write a method that checks if the element at given position in given array
//of integers is bigger than its two neighbors (when such exist).


class BiggerNeighbourArray
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


    static void Main()
    {
        Console.WriteLine("Enter numbers of elements for the array: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter index of the searched element: (0-based)");
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the elements: ");
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        if (k == 0 || k == arr.Length - 1)
        {
            Console.WriteLine("Element don't have two neighbours!");
        }
        else
        {
            bool res = IsBiggerNeighbour(arr, k);
            Console.WriteLine("Is the element {0} bigger than it's neighbours? -> {1}", arr[k], res);
        }
    }
}
