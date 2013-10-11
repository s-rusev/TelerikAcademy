using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTest
{
    class MatrixTest
    {
        static void Main(string[] args)
        {
            int[,] integerMatrix = {
                                       {1,2,4},
                                       {5,-2,1},
                                       {4,12,6} 
                                   };
            int[,] integerMatrixTwo = {
                                          {5,1,8},
                                          {12,28,-4},
                                          {7,-5,12}
                                      };
            int[,] integerMatrixThree = {
                                         {1,2,3,4},
                                         {1,2,3,3},
                                         {1,2,3,5},
                                         {1,2,3,7}
                                     };
            int[,] firstArrMultiply = {
                                          {1,2,3},
                                          {4,5,6}
                                      };
            int[,] secondArrMultiply = {
                                           {7,8},
                                           {9,10},
                                           {11,12}
                                       };
            int[,] zeroArr = {
                                 {0,0},
                                 {0,0}
                             };
            Matrix<int> matrix = new Matrix<int>(integerMatrix);
            Matrix<int> secondMatrix = new Matrix<int>(integerMatrixTwo);
            Matrix<int> thirdMatrix = new Matrix<int>(integerMatrixThree);
            Matrix<int> firstMatrixMultiply = new Matrix<int>(firstArrMultiply);
            Matrix<int> secondMatrixMultiply = new Matrix<int>(secondArrMultiply);
            Matrix<int> zeroMatrix = new Matrix<int>(zeroArr);
            //this will break if uncommented, because we add two matrices with different dimensions
            //Console.WriteLine(matrix + thirdMatrix);
            Console.WriteLine("Adding two matrices");
            Console.WriteLine(matrix + secondMatrix);
            Console.WriteLine("Substracting two matrices");
            Console.WriteLine(secondMatrix - matrix);
            Console.WriteLine("Multiplying two matrices");
            //this will break if uncommented, again because of different dimensions (first.y must be equal to second.x)
            //Console.WriteLine(firstMatrixMultiply * thirdMatrix);
            Console.WriteLine(firstMatrixMultiply * secondMatrixMultiply);
            Console.WriteLine("The element with indexes [2,2] is: ");
            Console.WriteLine(matrix[2, 2]); //demonstrating the indexing
            //this will break if uncomennted, because of invalid indexes
            //Console.WriteLine(matrix[999,999]);
            Console.WriteLine("Demonstrating the true operator:");
            if (zeroMatrix)
            {
                Console.WriteLine(zeroMatrix);
            }



        }
    }
}
