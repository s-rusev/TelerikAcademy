namespace RefactoredLoop
{
    using System;

    class SearchValueInArrayTest
    {
        static void Main(string[] args)
        {
            bool valueIsFound = false;
            int[] array = new int[100];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(40);
            }

            int expectedValue = 23;
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);

                if (array[i] == expectedValue)
                {
                    valueIsFound = true;
                    break;
                }
            }

            if (valueIsFound)
            {
                Console.WriteLine("Value Found");
            }
            //Note: in the original code the value is never found because after
            //i is set to 666 then it is incremented with 1 and the if-clause there
            //is whether the value is 666 (not 667). Also that's why there is a break(in my code)
            //after we found match with expected value because i is varying from 1 to 100
            //and its value then is 667 (int the original one)
        }
    }
}
