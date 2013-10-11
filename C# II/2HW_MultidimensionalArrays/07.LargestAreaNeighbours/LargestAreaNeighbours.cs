using System;

//* Write a program that finds the largest area of equal 
//neighbor elements in a rectangular matrix and prints its size. 

namespace LargestAreaNeighbour
{
    class LargestAreaNeighbour
    {
        static int NeighbourArea(int[,] matrix, int positionX, int positionY, int neighbour)
        {

            if (positionY < 0 || positionY >= matrix.GetLength(1) || positionX < 0 || positionX >= matrix.GetLength(0))
            {
                return 0;
            }
            if (matrix[positionX, positionY] != neighbour)
            {
                return 0;
            }
            matrix[positionX, positionY] = -1; //visited
            int area = 1 + NeighbourArea(matrix, positionX + 1, positionY, neighbour) +
                NeighbourArea(matrix, positionX - 1, positionY, neighbour) +
                NeighbourArea(matrix, positionX, positionY + 1, neighbour) +
                NeighbourArea(matrix, positionX, positionY - 1, neighbour);
            matrix[positionX, positionY] = neighbour;
            return area;
        }

        static void Main()
        {
            Console.WriteLine("A program that finds the largest area of equal neighbours. ");
            Console.WriteLine("Enter n= ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter m= ");
            int m = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, m];
            Console.WriteLine("Enter the elements of the matrix: (n lines with m elements) ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string input = Console.ReadLine();
                string[] inputTokens = input.Split(' ');
                for (int j = 0; j < inputTokens.Length; j++)
                {
                    matrix[i, j] = int.Parse(inputTokens[j]);
                }
            }
            Console.WriteLine(NeighbourArea(matrix, 0, 1, matrix[0, 0]));
        }
    }
}
