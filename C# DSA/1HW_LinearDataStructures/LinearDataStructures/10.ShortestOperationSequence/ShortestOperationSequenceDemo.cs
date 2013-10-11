using System;
using System.Collections.Generic;


namespace _10.ShortestOperationSequence
{
    public class ShortestOperationSequenceDemo
    {
        /// <summary>
        /// Using gready algorith to find the shortest operation sequence.
        /// The best analogy is filling a bowl first with
        /// rocks, than with smaller rocks, than with sand
        /// and finally with beer. Or in other words:
        /// That way we get all the *2 operations first, than all the
        /// +2 operations second and finally all the +1 operations  (and reverse them)
        /// </summary>
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            if (m - n == 2)
            {
                Console.WriteLine(n);
                Console.WriteLine(m);
            }
            else
            {
                int current = m;
                List<int> operands = new List<int>();
                operands.Add(current);

                while (current / 2 >= n)
                {
                    if (current % 2 == 0)
                    {
                        current /= 2;
                        operands.Add(current);
                    }
                    else
                    {
                        current -= 1;
                        operands.Add(current);
                        current /= 2;
                        operands.Add(current);
                    }
                }

                while (current - 2 >= n)
                {
                    current -= 2;
                    operands.Add(current);
                }

                while (current - 1 >= n)
                {
                    current -= 1;
                    operands.Add(current);
                }

                operands.Reverse();

                foreach (var item in operands)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}