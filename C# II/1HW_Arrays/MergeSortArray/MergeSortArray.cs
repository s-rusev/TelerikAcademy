using System;

// Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).

namespace CSharpSort
{
    class MergeSortArray
    {
        public static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length == 1)
                return numbers;
            int middle = numbers.Length / 2;
            int[] left = new int[middle];
            for (int i = 0; i < middle; i++)
            {
                left[i] = numbers[i];
            }
            int[] right = new int[numbers.Length - middle];
            for (int i = 0; i < numbers.Length - middle; i++)
            {
                right[i] = numbers[i + middle];
            }
            left = MergeSort(left);
            right = MergeSort(right);

            int leftIndex = 0;
            int rightIndex = 0;

            int[] sorted = new int[numbers.Length];
            //merge
            for (int k = 0; k < numbers.Length; k++)
            {
                if (rightIndex == right.Length || ((leftIndex < left.Length) && (left[leftIndex] <= right[rightIndex])))
                {
                    sorted[k] = left[leftIndex];
                    leftIndex++;
                }
                else if (leftIndex == left.Length || ((rightIndex < right.Length) && (right[rightIndex] <= left[leftIndex])))
                {
                    sorted[k] = right[rightIndex];
                    rightIndex++;
                }
            }
            return sorted;
        }

        //merges two already sorted arrays into a sorted one (from Nakov's Programirane= ++algoritmi) but I'm not using it actually...
        public static int[] DoMerge(int[] firstArr, int[] secondArr) 
        {
            int[] resultArr = new int[firstArr.Length + secondArr.Length];
            int firstIndex = 0;
            int secondIndex = 0;
            int resultIndex = 0;
            while (firstIndex < firstArr.Length && secondIndex < secondArr.Length)
            {
                resultArr[resultIndex++] = (firstArr[firstIndex] < secondArr[secondIndex]) ? firstArr[firstIndex++] : secondArr[secondIndex++];
            }
            if (firstIndex == firstArr.Length)
            {
                while (secondIndex < secondArr.Length)
                {
                    resultArr[resultIndex++] = secondArr[secondIndex++];
                }
            }
            else
            {
                while (firstIndex < firstArr.Length)
                {
                    resultArr[resultIndex++] = firstArr[firstIndex++];
                }
            }
            return resultArr;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("A program sorting an array using Merge Sort.");
            Console.WriteLine("Enter number of elements: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            int[] res = MergeSort(arr);
            Console.WriteLine("The sorted arrays are: ");
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
    }
}