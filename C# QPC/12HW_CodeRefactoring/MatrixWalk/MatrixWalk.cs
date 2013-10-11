using System;

namespace MatrixWalk
{
    public class MatrixWalk
    {
        static void Main()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int matrixLength = 0;

            while (!int.TryParse(input, out matrixLength) || matrixLength < 0 || matrixLength > 100)
            {
                Console.WriteLine("Enter a correct positive number!");
                input = Console.ReadLine();
            }

            Matrix matrix = new Matrix(matrixLength);
            MatrixInitializer matrixInitializer = new MatrixInitializer();
            int number = 1;
            int row = 0;
            int col = 0;
            int horizontalStep = 1;
            int vericalStep = 1;

            matrixInitializer.InitializeMatrixWhilePosible(matrix.MatrixContainer, ref number, ref row, ref col,
                ref horizontalStep, ref vericalStep);

            for (int matrixRow = 0; matrixRow < matrixLength; matrixRow++)
            {
                for (int matrixCol = 0; matrixCol < matrixLength; matrixCol++)
                {
                    Console.Write("{0,3}", matrix.MatrixContainer[matrixRow, matrixCol]);
                }

                Console.WriteLine();
            }
        }
    }
}