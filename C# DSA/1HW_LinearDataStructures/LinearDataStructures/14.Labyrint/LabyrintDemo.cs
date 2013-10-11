using System;
using System.Text;
using System.Collections.Generic;

namespace _14.Labyrinth
{
    public class LabyrintDemo
    {
        static readonly Coordinates[] directions = 
        {
            new Coordinates(0, 1),  //up
            new Coordinates(1, 0),  //right
            new Coordinates(0, -1), //down
            new Coordinates(-1, 0), //left
        };

        static void Main()
        {
            string[,] labyrinth = 
            {
                { "0", "0", "0", "x", "0", "x", "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x", "0", "0", "0", "x", "0", "x" },
                { "0", "*", "x", "0", "x", "0", "0", "0", "0", "x", "x", "x" },
                { "0", "x", "0", "0", "0", "0", "0", "0", "0", "x", "0", "x" },
                { "0", "0", "0", "x", "x", "0", "0", "0", "0", "x", "0", "x" },
                { "0", "0", "0", "x", "0", "x", "0", "0", "0", "0", "0", "x" },
            };

            Queue<Coordinates> currentQueue = new Queue<Coordinates>();
            Coordinates start = GetCoordinates(labyrinth, "*");
            currentQueue.Enqueue(start);

            int level = 0;

            while (currentQueue.Count != 0)
            {
                var nextQueue = new Queue<Coordinates>();

                level++;

                while (currentQueue.Count != 0)
                {
                    Coordinates currentCoordinates = currentQueue.Dequeue();

                    foreach (Coordinates direction in directions)
                    {
                        //check all neighbours of the cell
                        Coordinates nextCoordinates = currentCoordinates + direction;

                        if (!IsInRange(labyrinth, nextCoordinates))
                        {
                            continue;
                        }

                        if (labyrinth[nextCoordinates.Row, nextCoordinates.Col] != "0")
                        {
                            continue;
                        }

                        labyrinth[nextCoordinates.Row, nextCoordinates.Col] = level.ToString();
                        nextQueue.Enqueue(nextCoordinates);
                    }
                }

                currentQueue = nextQueue;
            }

            PrintLabyrint(labyrinth);
        }

        static Coordinates GetCoordinates(string[,] matrix, string element)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col].Equals(element))
                    {
                        return new Coordinates(row, col);
                    }
                }
            }

            throw new ArgumentException("Invalid element.");
        }

        static bool IsInRange(string[,] matrix, Coordinates coordinates)
        {
            bool isRowInRange = (0 <= coordinates.Row) && (coordinates.Row < matrix.GetLength(0));
            bool isColInRange = (0 <= coordinates.Col) && (coordinates.Col < matrix.GetLength(1));
            bool isInRange = isRowInRange && isColInRange;

            return isInRange;
        }

        static void PrintLabyrint(string[,] matrix)
        {
            var result = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == (matrix.GetLength(1) - 1))
                    {
                        result.Append(Environment.NewLine);
                        break;
                    }
                    result.Append((matrix[row, col] + " ").PadLeft(4));
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}