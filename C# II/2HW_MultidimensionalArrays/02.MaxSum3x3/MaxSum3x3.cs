using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("A program to find the 3x3 area with the larges sum of its elements.");
        Console.WriteLine("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter m: ");
        int m = int.Parse(Console.ReadLine());
        int[,] arr = new int[n, m];
        Console.WriteLine("Enter the elements of the matrix: (all elements from a row on a single line with spaces :))");
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            string input = Console.ReadLine();
            string[] tokens = input.Split(' ');
            for (int j = 0; j < tokens.Length; j++)
            {
                arr[i, j] = int.Parse(tokens[j]);
            }
        }

        int maxSum = arr[1, 1] + arr[1, 2] + arr[1, 0]
                    + arr[2, 1] + arr[2, 2] + arr[2, 0]
                    + arr[0, 1] + arr[0, 2] + arr[0, 0];
        for (int i = 1; i <= arr.GetLength(0) - 2; i++)
        {
            for (int j = 1; j <= arr.GetLength(1) - 2; j++)
            {
                int tempSum = arr[i, j] + arr[i, j + 1] + arr[i, j - 1]
                  + arr[i + 1, j] + arr[i + 1, j + 1] + arr[i + 1, j - 1]
                  + arr[i - 1, j] + arr[i - 1, j + 1] + arr[i - 1, j - 1];
                if (tempSum > maxSum)
                {
                    maxSum = tempSum;
                }
            }
        }
        Console.WriteLine("Maximum sum is: {0}", maxSum);
    }
}

/*
 * if we want to check all possible grids:
 * 
                if (i >= 1 && j >= 1 && i <= arr.GetLength(0) - 2 && j <= arr.GetLength(1) - 2)  //in the middle
                {
                    tempSum = arr[i, j] + arr[i, j + 1] + arr[i, j - 1]
                    + arr[i + 1, j] + arr[i + 1, j + 1] + arr[i + 1, j - 1]
                    + arr[i - 1, j] + arr[i - 1, j + 1] + arr[i - 1, j - 1];
                }
                else if (i == 0 && j >= 1 && j <= arr.GetLength(1) - 2) // on the top line
                {
                    tempSum = arr[i, j - 1] + arr[i, j] + arr[i, j + 1] + arr[i + 1, j - 1] + arr[i + 1, j] + arr[i + 1, j + 1];
                }
                else if (i == arr.GetLength(0)-1 && j >= 1 && j <= arr.GetLength(1) - 2) // on the bottom line
                {
                    tempSum = arr[i, j - 1] + arr[i, j] + arr[i, j + 1] + arr[i - 1, j - 1] + arr[i - 1, j] + arr[i - 1, j + 1];
                }
                else if (i >= 1 && i <= arr.GetLength(0) - 2 && j == 0) //on the left line
                {
                    tempSum = arr[i, j] + arr[i + 1, j] + arr[i - 1, j] + arr[i - 1, j + 1] + arr[i, j + 1] + arr[i + 1, j + 1];
                }
                else if (i >= 1 && i <= arr.GetLength(0) - 2 && j == arr.GetLength(1) - 1) //on the right line
                {
                    tempSum = arr[i, j] + arr[i + 1, j] + arr[i - 1, j] + arr[i - 1, j - 1] + arr[i, j - 1] + arr[i + 1, j - 1];
                }
                else if (i == 0 && j == 0) //left-top corner
                {
                    tempSum = arr[0, 0] + arr[0, 1] + arr[1, 0] + arr[1, 1];
                }
                else if (i==0 && j == arr.GetLength(1)-1) //right-top corner
                {
                    tempSum = arr[0, arr.GetLength(1) - 1] + arr[0, arr.GetLength(1) - 2] + arr[1, arr.GetLength(1) - 1] + arr[1, arr.GetLength(1) - 2];
                }
                else if (i==arr.GetLength(0)-1 && j==0) //bottom-left corner
                {
                    tempSum = arr[arr.GetLength(0) - 1, 0] + arr[arr.GetLength(0) - 1, 1] + arr[arr.GetLength(0) - 2, 0] + arr[arr.GetLength(0) - 2, 1];
                }
                else //bottom-right corner
                {
                    tempSum = arr[arr.GetLength(0) - 1, arr.GetLength(1) - 2] + arr[arr.GetLength(0) - 1, arr.GetLength(1) - 1] + arr[arr.GetLength(0) - 2, arr.GetLength(1) - 2] + arr[arr.GetLength(0) - 2, arr.GetLength(1) - 1];
                }

 */