using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.HashTable
{
    public class HashSet<T>
    {
        private HashTable<T, T> array;

        private const double fillFactor = 0.75d;
        private int maxItemsAtCurrentSize;
        private int count;

        public HashSet()
            : this(16)
        {
        }

        public HashSet(int initialCapacity)
        {
            if (initialCapacity < 1)
            {
                throw new ArgumentException("Invalid initial capacity.");
            }

            array = new HashTable<T, T>(initialCapacity);
            maxItemsAtCurrentSize = (int)(initialCapacity * fillFactor) + 1;
        }

        public void Add(T value)
        {
            if (count >= maxItemsAtCurrentSize)
            {
                AutoGrow();
            }

            array.Add(value, value);
            count++;
        }

        public bool Remove(T key)
        {
            bool removed = false;
            if (array.Remove(key))
            {
                count--;
                removed = true;
            }

            return removed;
        }

        //public T this[T key]
        //{
        //    get
        //    {
        //        T value;
        //        if (!array.TryGetValue(key, out value))
        //        {
        //            throw new ArgumentException("Invalid key");
        //        }
        //        return value;
        //    }
        //    set
        //    {
        //        array.Update(key, value);
        //    }
        //}

        public bool TryGetValue(T key, out T value)
        {
            bool isValidValue = array.TryGetValue(key, out value);
            return isValidValue;
        }

        public bool ContainsKey(T key)
        {
            T value;
            bool containsKey = array.TryGetValue(key, out value);
            return containsKey;
        }

        public bool ContainsValue(T value)
        {
            bool containsValue = false;
            foreach (var val in array.Values)
            {
                if (val.Equals(value))
                {
                    containsValue = true;
                    break;
                }
            }

            return containsValue;
        }

        public IEnumerable<T> Keys
        {
            get
            {
                return array.Keys;
            }
        }

        public IEnumerable<T> Values
        {
            get
            {
                return array.Values;
            }
        }

        //public IEnumerable<KeyValuePair<T, T>> Items
        //{
        //    get
        //    {
        //        return array.Items;
        //    }
        //}

        public void Clear()
        {
            count = 0;
            array.Clear();
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public int MaxItemsAtCurrentSize
        {
            get
            {
                return maxItemsAtCurrentSize;
            }
        }

        private void AutoGrow()
        {
            HashTable<T, T> largerArray = new HashTable<T, T>(array.MaxItemsAtCurrentSize * 2);

            foreach (var node in array.Items)
            {
                largerArray.Add(node.Key, node.Value);
            }

            array = largerArray;
            maxItemsAtCurrentSize = (int)(array.MaxItemsAtCurrentSize * fillFactor) + 1;
        }
    }
}