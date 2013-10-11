namespace Methods
{
    using System;

    public class TestClass
    {
        public static void Main()
        {
            double triangleArea = Methods.CalculateTriangleArea(3, 4, 5);
            Console.WriteLine(triangleArea);

            string digitAsString = Methods.DigitToString(5);
            Console.WriteLine(digitAsString);

            int[] sampleElements = {5, -1, 3, 2, 14, 2, 3};
            int maxElement = Methods.FindMaxNumber(sampleElements);
            Console.WriteLine(maxElement);

            Methods.PrintNumberWithPrecionTwo(1.3);
            Methods.PrintNumberAsPercent(0.75);
            Methods.PrintNumberPaddingEight(2.30);

            double dist = Methods.CalculateDistanceTwoPoints(3, -1, 3, 2.5);
            Console.WriteLine(dist);

            bool isHorizontal = Methods.CheckLineIsHorizontal(3, -1, 3, 2.5);
            Console.WriteLine("Horizontal? " + isHorizontal);

            bool isVertical = Methods.CheckLineIsVertical(3, -1, 3, 2.5);
            Console.WriteLine("Vertical? " + isVertical);

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992,03,17));
            peter.OtherInfo = "From Sofia";

            Student stella = new Student("Stella", "Markova", new DateTime(1993,11,03));
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
