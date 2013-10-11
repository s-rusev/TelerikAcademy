using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _3.PriorityQueue
{
    public class PriorityQueue<T>
    {
        private class ItemWithPriority : IComparable<ItemWithPriority>
        {
            public T Item { get; private set; }
            public int Priority { get; private set; }

            public ItemWithPriority(T t, int priority)
            {
                Item = t;
                Priority = priority;
            }

            public int CompareTo(ItemWithPriority other)
            {
                return this.Priority.CompareTo(other.Priority);
            }
        }

        private OrderedBag<ItemWithPriority> itemsPriorityContainer = new OrderedBag<ItemWithPriority>();

        public void Enqueue(T value)
        {
            ItemWithPriority item = new ItemWithPriority(value, 0);
            itemsPriorityContainer.Add(item);
        }

        public void Enqueue(T value, int priority)
        {
            ItemWithPriority item = new ItemWithPriority(value, priority);
            itemsPriorityContainer.Add(item);
        }

        public T Dequeue()
        {
            ItemWithPriority first = itemsPriorityContainer.First();
            itemsPriorityContainer.Remove(first);
           
            return first.Item;
        }
    }
}
