namespace Methods
{
    using System;
    using System.Linq;

    public static class Methods
    {
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("All sides should be positive.");
            }
            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
            return area;
        }

        public static string DigitToString(int number)
        {
            string result = null;
            switch (number)
            {
                case 0: result = "zero"; break;
                case 1: result = "one"; break;
                case 2: result = "two"; break;
                case 3: result = "three"; break;
                case 4: result = "four"; break;
                case 5: result = "five"; break;
                case 6: result = "six"; break;
                case 7: result = "seven"; break;
                case 8: result = "eight"; break;
                case 9: result = "nine"; break;
                default:
                    throw new ArgumentException("Argument must be a digit between 0-9!");
            }

            return result;
        }

        public static int FindMaxNumber(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Input can not be null!");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("Array must have at least one element!");
            }

            int maxElement = elements.Max();

            return maxElement;
        }

        public static void PrintNumberWithPrecionTwo(double number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintNumberAsPercent(double number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintNumberPaddingEight(double number)
        {
            Console.WriteLine("{0,8}", number);
        }

        public static bool CheckLineIsHorizontal(double x1, double y1, double x2, double y2)
        {
            CheckLineExist(x1, x2, y1, y2);
            bool isLineHorizontal = (y1 == y2);

            return isLineHorizontal; 
        }

        public static bool CheckLineIsVertical(double x1, double y1, double x2, double y2)
        {
            CheckLineExist(x1, x2, y1, y2);
            bool isLineVertical = (x1 == x2);

            return isLineVertical;
        }

        public static double CalculateDistanceTwoPoints(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));

            return distance;
        }

        private static bool CheckLineExist(double x1, double y1, double x2, double y2)
        {
            if ((x1 == x2) && (y1 == y2)) //line is a point
            {
                throw new ArgumentException("Line must be defined by two different coordinates!");
            }

            return x1 == x2;
        }

    }
}
