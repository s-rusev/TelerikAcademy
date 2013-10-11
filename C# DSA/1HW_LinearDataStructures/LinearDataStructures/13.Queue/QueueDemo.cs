using System;

namespace _13.Queue
{
    public class QueueDemo
    {
        static void Main()
        {
            CustomLinkedQueue<string> guitars = new CustomLinkedQueue<string>();
            guitars.Enqueue("Gibson");
            guitars.Enqueue("Fender");
            guitars.Enqueue("Ibanez");
            guitars.Enqueue("Yamaha");

            while (guitars.Count != 0)
            {
                Console.WriteLine(guitars.Dequeue());    
            }
            
        }
    }
}
