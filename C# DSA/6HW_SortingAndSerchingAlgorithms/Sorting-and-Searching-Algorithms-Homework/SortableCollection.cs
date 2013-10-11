namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            bool isFound = false;
            foreach (var entry in this.Items)
            {
                if (entry.CompareTo(item) == 0)
                {
                    isFound = true;
                    break;
                }
            }

            return isFound;
        }

        public bool BinarySearch(T item)
        {
            bool isFound = false;
            int left = 0;
            int rigth = this.items.Count - 1;
            int middle = rigth / 2;

            while (left <= rigth)
            {
                if (item.CompareTo(this.items[middle]) == 0)
                {
                    isFound = true;
                    break;
                }
                else if (item.CompareTo(this.items[middle]) < 0)
                {
                    rigth = middle - 1;
                    middle = (rigth - left) / 2 + left;
                }
                else
                {
                    left = middle + 1;
                    middle = (rigth - left) / 2 + left;
                }
            }

            return isFound;
        }

        /// <summary>
        /// O(n) complexity
        /// </summary>
        public void Shuffle()
        {
            Random randomGenerator = new Random();

            for (int i = items.Count - 1; i >= 0; i--)
            {
                int randomNumber = randomGenerator.Next(0, i + 1);
                T temp = items[randomNumber];
                items[randomNumber] = items[i];
                items[i] = temp;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
