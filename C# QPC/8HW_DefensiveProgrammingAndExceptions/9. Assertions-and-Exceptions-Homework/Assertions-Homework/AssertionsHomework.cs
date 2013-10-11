using System;
using System.Linq;
using System.Diagnostics;

class AssertionsHomework
{
    private static bool ArrayIsSortedAscending<T>(T[] arr) where T : IComparable<T>
    {
        if (arr == null)
        {
            throw new ArgumentNullException("array can't be null.");
        }

        bool isSorted = true;

        for (int index = 0; index < arr.Length - 1; index++)
        {
            if (arr[index].CompareTo(arr[index + 1]) < 0)
            {
                isSorted = false;
                break;
            }
        }

        return isSorted;
    }

    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        if (arr == null)
        {
            throw new ArgumentNullException("array can't be null.");
        }

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        Debug.Assert(ArrayIsSortedAscending(arr), "array is not sorted.");
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        if (arr == null)
        {
            throw new ArgumentNullException("array can't be null.");
        }

        if (startIndex > endIndex || startIndex < 0)
        {
            throw new ArgumentOutOfRangeException(string.Format("startIndex must be between {0} and {1}.", 0, endIndex));
        }
        if (endIndex < 0 || endIndex >= arr.Length)
        {
            throw new ArgumentOutOfRangeException(string.Format("endIndex must be between {0} and {1}.", 0, arr.Length - 1));
        }

        int minElementIndex = startIndex;

        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    { 
        if (arr == null)
        {
            throw new ArgumentNullException("array can't be null.");
        }

        if (!ArrayIsSortedAscending(arr))
        {
            throw new ArgumentException("Array must be sorted to perform binary search.");
        }
       
        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        if (arr == null)
        {
            throw new ArgumentNullException("array can't be null.");
        }

        if (startIndex > endIndex || startIndex < 0)
        {
            throw new ArgumentOutOfRangeException(string.Format("startIndex must be between {0} and {1}.", 0, endIndex));
        }
        if (endIndex < 0 || endIndex >= arr.Length)
        {
            throw new ArgumentOutOfRangeException(string.Format("endIndex must be between {0} and {1}.", 0, arr.Length - 1));
        }

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }
            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}
