namespace FigureRotation
{
    using System;

    class FigureRotationTest
    {
        static void Main()
        {
            //sample values
            double figureWidth = 5.4;
            double figureHeigth = 3.4;
            double rotationAngle = 10;
            Figure sampleFigure = new Figure(figureWidth, figureHeigth);
            Figure rotatedFigure = Figure.GetRotatedFigure(sampleFigure, rotationAngle);
            Console.WriteLine(rotatedFigure);
        }
    }
}
