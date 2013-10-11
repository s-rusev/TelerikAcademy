using System;

class Matrices
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
        Console.WriteLine(new string('^', 50));
    }
    static void Main()
    {
        Console.WriteLine("A program to print matrices in specific order.");
        Console.WriteLine("Enter dimension for the matrices: ");
        int n = int.Parse(Console.ReadLine());
        int[,] firstMatrix = new int[n, n];
        int[,] secondMatrix = new int[n, n];
        int[,] thirdMatrix = new int[n, n];
        int[,] forthMatrix = new int[n, n];


        int number = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                firstMatrix[j, i] = ++number;
            }
        }
        Console.WriteLine("First matrix: ");
        PrintMatrix(firstMatrix);

        number = 0;
        for (int i = 0; i < n; i += 2)
        {
            for (int j = 0; j < n; j++)
            {
                secondMatrix[j, i] = ++number;
            }
            if (i == n - 1)
            {
                break;
            }
            for (int j = n - 1; j >= 0; j--)
            {
                secondMatrix[j, i + 1] = ++number;
            }
        }

        Console.WriteLine("Second matrix: ");
        PrintMatrix(secondMatrix);
        number = 0;
        int k = n - 1;
        for (int slice = 0; slice < 2 * n - 1; slice++)
        {
            int z = slice;
            if (slice < n)
            {
                z = 0;
            }
            else
            {
                z = slice - n + 1;
            }
            for (int j = z; j <= slice - z; j++)
            {
                if (z != 0)
                {
                    k = -z;
                    thirdMatrix[j + k, j] = ++number;
                }
                else
                {
                    thirdMatrix[j + k, j] = ++number;

                }
            }
            k--;

        }

        Console.WriteLine("Third matrix: ");
        PrintMatrix(thirdMatrix);

        int rowStart = 0, rowEnd = n;
        int colStart = 0, colEnd = n;
        int row = rowStart;
        int col = colStart;
        string direction = "right";

        for (int i = 1; i <= n * n; i++)
        {
            if (direction == "down")
            {
                forthMatrix[row, col] = i;
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
                forthMatrix[row, col] = i;
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
                forthMatrix[row, col] = i;
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
                forthMatrix[row, col] = i;
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
        rowStart = 0;
        rowEnd = n;
        colStart = 0;
        colEnd = n;
        row = rowStart;
        col = colStart;
        direction = "down";

        for (int i = 1; i <= n * n; i++)
        {
            if (direction == "down")
            {
                forthMatrix[row, col] = i;
                row++;
                if (row == rowEnd)
                {
                    row--;
                    direction = "right";
                    colStart++;
                    col = colStart;
                }
            }
            else if (direction == "up")
            {
                forthMatrix[row, col] = i;
                row--;
                if (row < rowStart)
                {
                    row++;
                    direction = "left";
                    colEnd--;
                    col = colEnd - 1;
                }
            }
            else if (direction == "right")
            {
                forthMatrix[row, col] = i;
                col++;
                if (col == colEnd)
                {
                    col--;
                    direction = "up";
                    rowEnd--;
                    row = rowEnd - 1;
                }
            }
            else if (direction == "left")
            {
                forthMatrix[row, col] = i;
                col--;
                if (col < colStart)
                {
                    col++;
                    direction = "down";
                    rowStart++;
                    row = rowStart;
                }
            }
        }

        Console.WriteLine("Fourth matrix: ");
        PrintMatrix(forthMatrix);


    }
}

