using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.LinkedList
{
    public class LinkedListDemo
    {
        static void Main()
        {
            CustomLinkedList<int> dynamicList = new CustomLinkedList<int>();
            dynamicList.AddLast(5);
            dynamicList.AddLast(6);
            dynamicList.AddLast(7);
            dynamicList.AddLast(8);
            dynamicList.AddFirst(1);
            dynamicList.RemoveAtIndex(2);

            foreach (var item in dynamicList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
