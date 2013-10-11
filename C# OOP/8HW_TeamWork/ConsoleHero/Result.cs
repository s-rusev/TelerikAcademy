using System;

namespace ConsoleHero
{
    public class Result : GameObject
    {
        private int points;
        private static Result instance = new Result(new MatrixCoords(2, 27), new char[,] { { } }, 0);

        public int Points
        {
            get { return this.points; }
            set { this.points = value; }
        }

        private Result(MatrixCoords upperLeft, char[,] symbolChars, int point)
            : base(upperLeft, symbolChars)
        {
            this.Refresh();
            this.Points = point;
        }

        public static Result Instance
        {
            set 
            {
                instance = value;
            }
            get
            {
                return instance;
            }
        }

        public override void Update()
        {
            this.Refresh();
        }

        public void Refresh()
        {
            string displayResult = "RESULT:" + this.points.ToString();
            char[,] temp = new char[1, displayResult.Length];

            for (int index = 0; index < temp.GetLength(1); index++)
            {
                temp[0, index] = displayResult[index];
            }
            this.body = temp;
        }
    }
}
