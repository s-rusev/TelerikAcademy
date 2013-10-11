using System;

class LargestAreaNeighbour
{
    static int NeighbourArea(char[,] matrix, int positionX, int positionY, char neighbour)
    {

        if (positionY < 0 || positionY >= matrix.GetLength(1) || positionX < 0 || positionX >= matrix.GetLength(0))
        {
            return 0;
        }
        if (matrix[positionX, positionY] != neighbour)
        {
            return 0;
        }
        matrix[positionX, positionY] = '*'; //visited
        int area = 1 + NeighbourArea(matrix, positionX + 1, positionY, neighbour) +
            NeighbourArea(matrix, positionX - 1, positionY, neighbour) +
            NeighbourArea(matrix, positionX, positionY + 1, neighbour) +
            NeighbourArea(matrix, positionX, positionY - 1, neighbour);

        return area;
    }

    static char[,] lab =
    {
         //{' ','*','*'},
         //{' ','*','*'},
         //{'*','*','*'},
          {' ', ' ', ' ', '*', ' ', ' ', ' '},
          {'*', '*', ' ', '*', ' ', '*', ' '},
          {' ', ' ', ' ', ' ', ' ', ' ', ' '},
          {' ', '*', '*', '*', '*', '*', ' '},
          {' ', ' ', ' ', ' ', ' ', ' ', ' '}
    };

    static void Main()
    {
        Console.WriteLine("A recursive program to find the largest connected area of adjacent empty cells in a matrix. ");
        Console.WriteLine("The largest connected area of adjacent empty cells is: " + NeighbourArea(lab, 0, 0, lab[0, 0]));
    }
}
