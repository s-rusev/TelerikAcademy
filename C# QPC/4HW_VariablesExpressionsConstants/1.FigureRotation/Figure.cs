namespace FigureRotation
{
    using System;

    public class Figure
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public static Figure GetRotatedFigure(Figure figureToRotate, double angleFigureRotation)
        {
            double width = Math.Abs(Math.Cos(angleFigureRotation)) * figureToRotate.Width +
                Math.Abs(Math.Sin(angleFigureRotation)) * figureToRotate.Height;
            double height = Math.Abs(Math.Sin(angleFigureRotation)) * figureToRotate.Width +
                Math.Abs(Math.Cos(angleFigureRotation)) * figureToRotate.Height;
            Figure rotatedFigure = new Figure(width, height);

            return rotatedFigure;
        }

        public override string ToString()
        {
            return string.Format("Width: {0}, Height: {1}", this.Width, this.Height);
        }
    }
}
