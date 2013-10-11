using System;

class SpiralMatrix
{
    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0 , 6} ", matrix[i, j]);

            }
            Console.WriteLine();
        }
    }
    static void Main() 
    {
        int n = int.Parse(Console.ReadLine());
        int [,] arr = new int[n,n];
        int rowStart = 0, rowEnd = n;
        int colStart = 0, colEnd = n;
        int row = rowStart;
        int col = colStart;
        string direction = "right";

        for (int i = 1; i <= n * n; i++)
        {
            if (direction == "down")
            {
                arr[row, col] = i;
                row++;
                if (row == rowEnd)
                {
                    row--;
                    direction = "left";
                    colEnd--;
                    col = colEnd - 1;
                }
            }
            else if (direction == "up")
            {
                arr[row, col] = i;
                row--;
                if (row < rowStart)
                {
                    row++;
                    direction = "right";
                    colStart++;
                    col = colStart;
                }
            }
            else if (direction == "right")
            {
                arr[row, col] = i;
                col++;
                if (col == colEnd)
                {
                    col--;
                    direction = "down";
                    rowStart++;
                    row = rowStart;
                }
            }
            else if (direction == "left")
            {
                arr[row, col] = i;
                col--;
                if (col < colStart)
                {
                    col++;
                    direction = "up";
                    rowEnd--;
                    row = rowEnd - 1;
                }
            }
        }
        PrintMatrix(arr);
    }
}