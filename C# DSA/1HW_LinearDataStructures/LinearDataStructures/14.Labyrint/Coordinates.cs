namespace _14.Labyrinth
{
    class Coordinates
    {
        public int Row { get; private set; }

        public int Col { get; private set; }

        public Coordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public static Coordinates operator +(Coordinates a, Coordinates b)
        {
            return new Coordinates(
                a.Row + b.Row,
                a.Col + b.Col);
        }

        
    }
}