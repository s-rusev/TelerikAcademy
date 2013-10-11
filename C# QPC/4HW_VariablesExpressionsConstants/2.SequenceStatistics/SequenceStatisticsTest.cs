namespace SequenceStatistics
{
    using System;

    class SequenceStatisticsTest
    {
        public static void PrintStatistics(double[] array)
        {
            double maxValue = GetMax(array);
            Console.WriteLine("Maximal value is: " + maxValue);

            double minValue = GetMin(array);
            Console.WriteLine("Minimal value is: " + minValue);

            double averageValue = GetAverage(array);
            Console.WriteLine("Average value is: " + averageValue);
        }

        private static double GetMax(double[] array)
        {
            double maxValue = double.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }
            }

            return maxValue;
        }

        private static double GetMin(double[] array)
        {
            double minValue = double.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
            }

            return minValue;
        }

        private static double GetAverage(double[] array)
        {
            double sumOfElements = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sumOfElements += array[i];
            }

            double averageValue = sumOfElements / array.Length;
            return averageValue;
        }

        public static void Main(string[] args)
        {
            double[] sampleArray = { 1.4, 4.1, 5.5, 5, 6 };
            PrintStatistics(sampleArray);
        }
    }
}
