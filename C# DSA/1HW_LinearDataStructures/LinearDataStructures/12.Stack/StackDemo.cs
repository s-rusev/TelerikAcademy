using System;

namespace _12.Stack
{
    public class StackDemo 
    {
        public static void Main() 
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(1);
            stack.Push(9);
            stack.Push(9);
            stack.Push(0);

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            stack.Pop();

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}