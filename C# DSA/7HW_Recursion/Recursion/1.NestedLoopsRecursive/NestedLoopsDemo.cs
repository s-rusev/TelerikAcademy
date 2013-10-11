using System;

namespace _1.NestedLoopsRecursive
{
    public class NestedLoopsDemo
    {
        static int numberOfLoops;
        static int[] loops;

        static void Main()
        {
            Console.Write("N = ");
            numberOfLoops = int.Parse(Console.ReadLine());

            loops = new int[numberOfLoops];

            NestedLoops(0);
        }

        static void NestedLoops(int currentLoop)
        {
            if (currentLoop == numberOfLoops)
            {
                PrintLoops();
                return;
            }

            for (int counter = 1; counter <= numberOfLoops; counter++)
            {
                loops[currentLoop] = counter;
                NestedLoops(currentLoop + 1);
            }
        }

        static void PrintLoops()
        {
            for (int i = 0; i < numberOfLoops; i++)
            {
                Console.Write("{0} ", loops[i]);
            }
            Console.WriteLine();
        }
    }
}

