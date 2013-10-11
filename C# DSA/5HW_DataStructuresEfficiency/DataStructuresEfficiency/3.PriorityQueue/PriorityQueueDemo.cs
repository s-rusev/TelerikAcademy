using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.PriorityQueue
{
    public class PriorityQueueDemo
    {
        static void Main()
        {
            PriorityQueue<string> myPriorityQueue = new PriorityQueue<string>();
            //item value priority
            myPriorityQueue.Enqueue("anItem(priority 10)", 10);
            myPriorityQueue.Enqueue("anItem(priority 2)", 2);
            myPriorityQueue.Enqueue("anItem(priority 100)", 100);
            myPriorityQueue.Enqueue("anItem(priority 0)"); //with default priority - 0
                                      
            Console.WriteLine(myPriorityQueue.Dequeue());
            Console.WriteLine(myPriorityQueue.Dequeue());
            Console.WriteLine(myPriorityQueue.Dequeue());
            Console.WriteLine(myPriorityQueue.Dequeue());
        }
    }
}
