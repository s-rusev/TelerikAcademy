using System;
using System.Linq;
using System.Text;

namespace MatrixWalk
{
    public class Matrix
    {
        private int length;
        private readonly int[,] matrixContainer;

        public Matrix(int length)
        {
            this.Length = length;
            this.matrixContainer = new int[this.Length, this.Length];
        }

        public int[,] MatrixContainer
        {
            get
            {
                return this.matrixContainer;
            }
            private set
            {
            }
        }

        public int Length
        {
            get
            {
                return this.length;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Matrix length must be between 0 and 100");
                }
                this.length = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.matrixContainer.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrixContainer.GetLength(1); j++)
                {
                    sb.Append(this.matrixContainer[i, j] + " ");
                }
                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}