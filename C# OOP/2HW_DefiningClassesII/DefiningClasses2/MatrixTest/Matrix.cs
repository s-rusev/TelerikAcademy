using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTest
{
    class Matrix<T>
    {
        private T[,] container;

        public Matrix(T[,] array)
        {
            this.container = new T[array.GetLength(0), array.GetLength(1)];
            Array.Copy(array, this.container, array.Length);
        }

        public T[,] Container
        {
            get
            {

                return this.container;
            }
        }

        public T this[int row, int col]
        {
            get
            {
                if (row >= this.container.GetLength(0) || col >= this.container.GetLength(1) || row < 0 || col < 0)
                {
                    throw new IndexOutOfRangeException("Index out of range!");
                }
                return this.container[row, col];
            }
            set
            {
                this.container[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first.container.GetLength(0) != second.container.GetLength(0)
                || first.container.GetLength(1) != second.container.GetLength(1))
            {
                throw new InvalidOperationException("Cannot add matrixes with different dimensions!");
            }
            //copy the array to the result
            Matrix<T> result = new Matrix<T>(first.container);
            for (int i = 0; i < result.container.GetLength(0); i++)
            {
                for (int j = 0; j < result.container.GetLength(1); j++)
                {
                    result.container[i, j] += (dynamic)second.container[i, j];
                }
            }
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first.container.GetLength(0) != second.container.GetLength(0)
                || first.container.GetLength(1) != second.container.GetLength(1))
            {
                throw new InvalidOperationException("Cannot add matrixes with different dimensions!");
            }
            //copy the array to the result
            Matrix<T> result = new Matrix<T>(first.container);
            for (int i = 0; i < result.container.GetLength(0); i++)
            {
                for (int j = 0; j < result.container.GetLength(1); j++)
                {
                    result.container[i, j] -= (dynamic)second.container[i, j];
                }
            }
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if (first.container.GetLength(1) != second.container.GetLength(0))
            {
                throw new InvalidOperationException("The first matrix's second dimension" +
                        "should be equal to the second matrix's first dimension");
            }
            T[,] matrixArray = new T[first.container.GetLength(0), second.container.GetLength(1)];
            Matrix<T> result = new Matrix<T>(matrixArray);
            for (int i = 0; i < result.container.GetLength(0); i++)
            {
                for (int j = 0; j < result.container.GetLength(1); j++)
                {
                    T value = default(T);
                    for (int k = 0; k < first.container.GetLength(1); k++)
                    {
                        value += (dynamic)first[i, k] * (dynamic)second[k, j];
                    }
                    result[i, j] = value;
                }
            }
            return result;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            if (matrix == null || matrix.container.GetLength(0) == 0 || matrix.container.GetLength(1) == 0)
            {
                return false;
            }
            foreach (var value in matrix.container)
            {
                if (value.Equals(default(T)))
                {
                    continue;
                }
                else
	            {
                    return false;
	            }
            }
            return true;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            if (matrix == null || matrix.container.GetLength(0) == 0 || matrix.container.GetLength(1) == 0)
            {
                return false;
            }
            foreach (var value in matrix.container)
            {
                if (!value.Equals(default(T)))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.container.GetLength(0); i++)
            {
                for (int j = 0; j < this.container.GetLength(1); j++)
                {
                    sb.Append(this.container[i, j]).Append(" ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}
