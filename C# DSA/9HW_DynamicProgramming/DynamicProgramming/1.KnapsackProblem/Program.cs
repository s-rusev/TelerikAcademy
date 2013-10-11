namespace _1.KnapsackProblem
{
    using System;
    using System.Linq;

    class Program
    {
        //beer – weight=3, cost=2
        //vodka – weight=8, cost=12
        //cheese – weight=4, cost=5
        //nuts – weight=1, cost=4
        //ham – weight=2, cost=3
        //whiskey – weight=8, cost=13

        static int[] weights =  {  3,       8,        4,        1,     2,      8 };
        static int[] values =   {  2,       12,       5,        4,     3,      13 };
        static string[] items = { "beer", "vodka", "cheese", "nuts", "ham", "whiskey" };
        static int itemsLength = items.Length;
        static int[,] matrix = new int[100, 100];
        static bool[,] picks = new bool[100, 100];
        static int knapsackSize = 10;

        static int Knapsack()
        {
            for (int i = 1; i <= itemsLength; i++)
            {
                for (int j = 0; j <= knapsackSize; j++)
                {
                    if (weights[i - 1] <= j)
                    {
                        matrix[i, j] = Math.Max(matrix[i - 1, j], values[i - 1] + matrix[i - 1, j - weights[i - 1]]);
                        if (values[i - 1] + matrix[i - 1, j - weights[i - 1]] > matrix[i - 1, j])
                        {
                            picks[i, j] = true;
                        }
                        else
                        {
                            //picks[i, j] = false;
                        }
                    }
                    else
                    {
                        picks[i, j] = false;
                        matrix[i, j] = matrix[i - 1, j];
                    }
                }
            }

            return matrix[itemsLength, knapsackSize];
        }

        static void PrintPicks(int item, int size)
        {
            while (item > 0)
            {
                if (picks[item, size] == true) //take that item
                {
                    Console.WriteLine(items[item - 1]);
                    item--;
                    size -= weights[item];
                }
                else
                {
                    item--;
                }
            }

            return;
        }

        static void Main()
        {
            int max = Knapsack();
            Console.WriteLine("Max value: {0}", max);
            Console.WriteLine("Picks were: ");
            PrintPicks(itemsLength, knapsackSize);
        }
    }
}
