using System;
//Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).


class QuickSortArray
{
    public static void QuickSort(int[] arr, int left, int right)
    {
        int pivot, tempLeft, tempRight;
        tempLeft = left;
        tempRight = right;
        pivot = arr[left];

        while (left < right)
        {
            while ((arr[right] >= pivot) && (left < right))
            {
                right--;
            }
            if (left != right)
            {
                arr[left] = arr[right];
                left++;
            }

            while ((arr[left] <= pivot) && (left < right))
            {
                left++;
            }
            if (left != right)
            {
                arr[right] = arr[left];
                right--;
            }
        }

        arr[left] = pivot;
        pivot = left;
        left = tempLeft;
        right = tempRight;

        if (left < pivot)
        {
            QuickSort(arr, left, pivot - 1);
        }

        if (right > pivot)
        {
            QuickSort(arr, pivot + 1, right);
        }
    }

    public static void Main()
    {
        Console.WriteLine("A program that sorts an array using QuickSort");
        Console.WriteLine("Enter number of elements for the array:");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        Console.WriteLine("Enter the elements: ");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        QuickSort(array, 0, array.Length - 1);
        Console.WriteLine("The sorted inegers are: ");
        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }
}
