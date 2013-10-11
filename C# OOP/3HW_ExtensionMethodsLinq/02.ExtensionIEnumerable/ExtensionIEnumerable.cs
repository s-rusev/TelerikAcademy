using System;
using System.Collections.Generic;

namespace _02.ExtensionIEnumerable
{
    public static class ExtensionIEnumerable
    {
        public static dynamic Sum<T>(this IEnumerable<T> list)
        {
            dynamic sum = 0;
            foreach (var num in list)
            {
                sum += num;
            }
            return sum;
        }
        public static dynamic Product<T>(this IEnumerable<T> list)
        {
            dynamic product = 1;
            foreach (var num in list)
            {
                product *= num;
            }
            return product;
        }
        public static dynamic Max<T>(this IEnumerable<T> list) where T : IComparable<T>
        {
            return list.Max();
            var type = typeof(T);
            dynamic max;
            if (type == typeof(byte))
            {
                max = byte.MinValue;
            }
            else if (type == typeof(short))
            {
                max = byte.MinValue;
            }
            else if (type == typeof(int))
            {
                max = int.MinValue;
            }
            else if (type == typeof(long))
            {
                max = long.MinValue;
            }
            else if (type == typeof(float))
            {
                max = float.MinValue;
            }
            else if (type == typeof(double))
            {
                max = double.MinValue;
            }
            else if (type == typeof(decimal))
            {
                max = decimal.MinValue;
            }
            else
            {
                max = null;
            }

            foreach (var number in list)
            {
                if (max < number)
                {
                    max = number;
                }
            }
            return max;
        }
        public static dynamic Min<T>(this IEnumerable<T> list) where T : IComparable<T>
        {
            var type = typeof(T);
            dynamic min;
            if (type == typeof(byte))
            {
                min = byte.MaxValue;
            }
            else if (type == typeof(short))
            {
                min = byte.MaxValue;
            }
            else if (type == typeof(int))
            {
                min = int.MaxValue;
            }
            else if (type == typeof(long))
            {
                min = long.MaxValue;
            }
            else if (type == typeof(float))
            {
                min = float.MaxValue;
            }
            else if (type == typeof(double))
            {
                min = double.MaxValue;
            }
            else if (type == typeof(decimal))
            {
                min = decimal.MaxValue;
            }
            else
            {
                min = null;
            }
            foreach (var number in list)
            {
                if (min > number)
                {
                    min = number;
                }
            }
            return min;
        }

        public static dynamic Average<T>(this IEnumerable<T> list)
        {
            dynamic sum = 0;
            dynamic count = 0;
            foreach (var num in list)
            {
                sum += num;
                count++;
            }
            return sum / (double)count;
        }
    }
}