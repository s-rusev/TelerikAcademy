using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicList
{
    class DynamicListTest
    {
        static void Main(string[] args)
        {
            //string[] words = { "0asd", "1asdasd", "2asdasdasd", "3asdasdasd" };
            int[] words = { 1, 2, 4100, 5, 6 };
            //this will break if uncommented
            //int[] numbers = new int[0];
            //GenericList<int> defList = new GenericList<int>(numbers);

            //this will break if uncommented
            //int[] someNumbers = null;
            //GenericList<int> listWithNullArgument = new GenericList<int>(someNumbers);

            GenericList<int> strList = new GenericList<int>(words);
            Console.WriteLine(strList.ToString());
            Console.WriteLine("The max element is: " + strList.Max());
            Console.WriteLine("The min element is: " + strList.Min());
            Console.WriteLine("The number of values is {0}", strList.CountOfElements);
            int index = 2;
            Console.WriteLine("The element with index {0} is {1} ", index, strList.ElementAt(index));
            Console.WriteLine("Removing the element with index {0}", index);
            strList.RemoveByIndex(index);
            Console.WriteLine("Now the number of values is {0}", strList.CountOfElements);
            Console.WriteLine(strList.ToString());
            Console.WriteLine("Adding element at the end of the list");
            //strList.Add("blabla");
            strList.Add(15);
            Console.WriteLine(strList.ToString());
            Console.WriteLine("Adding element at index 1");
            //strList.AddByIndex(1, "added by index");
            strList.AddByIndex(1, 99);
            Console.WriteLine(strList.ToString());
        }
    }
}
