using System;
using System.Text;

class Matrices
{
    private int[,] matrix;

    public int[,] Matrix
    {
        set
        {
            for (int i = 0; i < value.GetLength(0); i++)
            {
                for (int j = 0; j < value.GetLength(1); j++)
                {
                    matrix[i, j] = value[i, j];
                }
            }
        }
        get
        {
            return this.matrix;
        }
    }
    public Matrices(int[,] array)
    {
        this.matrix = new int[array.GetLength(0), array.GetLength(1)];
        Array.Copy(array, this.matrix, array.Length);
    }

    public static Matrices operator +(Matrices firstMatrix, Matrices secondMatrix)
    {
        int n = (int)Math.Max(firstMatrix.matrix.GetLength(0), secondMatrix.matrix.GetLength(0));
        int m = (int)Math.Max(firstMatrix.matrix.GetLength(1), secondMatrix.matrix.GetLength(1));
        int[,] resArray = new int[n, m];
        for (int i = 0; i < resArray.GetLength(0); i++)
        {
            for (int j = 0; j < resArray.GetLength(1); j++)
            {
                resArray[i, j] = firstMatrix.matrix[i, j] + secondMatrix.matrix[i, j];
            }
        }
        Matrices result = new Matrices(resArray);
        return result;
    }

    public static Matrices operator -(Matrices firstMatrix, Matrices secondMatrix)
    {
        int n = (int)Math.Max(firstMatrix.matrix.GetLength(0), secondMatrix.matrix.GetLength(0));
        int m = (int)Math.Max(firstMatrix.matrix.GetLength(1), secondMatrix.matrix.GetLength(1));
        int[,] resArray = new int[n, m];
        for (int i = 0; i < resArray.GetLength(0); i++)
        {
            for (int j = 0; j < resArray.GetLength(1); j++)
            {
                resArray[i, j] = firstMatrix.matrix[i, j] - secondMatrix.matrix[i, j];
            }
        }
        Matrices result = new Matrices(resArray);
        return result;
    }
    public static Matrices operator *(Matrices firstMatrix, Matrices secondMatrix)
    {
        Matrices result = new Matrices(new int[firstMatrix.matrix.GetLength(0), secondMatrix.matrix.GetLength(1)]);
        for (int i = 0; i < result.matrix.GetLength(0); i++)
        {
            for (int j = 0; j < result.matrix.GetLength(1); j++)
            {
                int value = 0;
                for (int k = 0; k < firstMatrix.matrix.GetLength(1); k++)
                {
                    value += firstMatrix.matrix[i, k] * secondMatrix.matrix[k, j];
                }
                result.matrix[i, j] = value;
            }
        }
        return result;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < this.matrix.GetLength(0); i++)
        {
            for (int j = 0; j < this.matrix.GetLength(1); j++)
            {
                sb.Append(this.matrix[i, j]).Append(" ");
            }
            sb.Append("\n");
        }
        return sb.ToString();
    }

    static void Main()
    {
        Console.WriteLine("A program that demonstrates Matrices class.");
        int[,] arr = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
        int[,] arr2 = new int[,] { { 7, 6, 8 }, { 66, 66, 66 } };
        int[,] arr3 = new int[,] { { 1, 2 }, { 3, 4 } };
        int[,] arr4 = new int[,] { { 1, 0 }, { 0, 1 } };
        Matrices m = new Matrices(arr);
        Matrices n = new Matrices(arr2);
        Matrices p = new Matrices(arr3);
        Matrices k = new Matrices(arr4);
        Console.WriteLine((m + n).ToString());
        Console.WriteLine((m - n).ToString());
        Console.WriteLine((p * k).ToString());
        m.Matrix = arr; // set invoked here
        int[,] res = new int[2, 3];
        res = m.Matrix; //get invoked here
    }
}

