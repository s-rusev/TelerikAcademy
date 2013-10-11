using System;
using System.Collections.Generic;

namespace _1.PriorityQueueBinaryHeap
{
    public class PriorityQueueDemo
    {
        static void Main(string[] args)
        {
            //uses default comparator of the priority, e.g. normal int comparator
            PriorityQueue<int, string> myPriorityQueue = new PriorityQueue<int, string>();
            myPriorityQueue.Add(new KeyValuePair<int,string>(100, "Joro"));
            myPriorityQueue.Add(new KeyValuePair<int,string>(500, "Niki"));
            myPriorityQueue.Add(new KeyValuePair<int,string>(900, "Nakov"));
            myPriorityQueue.Add(new KeyValuePair<int,string>(300, "Doncho"));

            Console.WriteLine(myPriorityQueue.Count);

            while (!myPriorityQueue.IsEmpty)
            {
                Console.WriteLine(myPriorityQueue.Dequeue());
            }
        }
    }
}
