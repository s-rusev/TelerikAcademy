using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.HashTable
{
    public class HashTable<K, V>
    {
        private const double fillFactor = 0.75d;
        private int maxItemsAtCurrentSize;
        private int count;
        private HashTableArray<K, V> array;

        public HashTable()
            : this(16)
        {
        }

        public HashTable(int initialCapacity)
        {
            if (initialCapacity < 1)
            {
                throw new ArgumentException("Invalid initial capacity.");
            }

            array = new HashTableArray<K, V>(initialCapacity);
            maxItemsAtCurrentSize = (int)(initialCapacity * fillFactor) + 1;
        }

        public void Add(K key, V value)
        {
            if (count >= maxItemsAtCurrentSize)
            {
                AutoGrow();
            }

            array.Add(key, value);
            count++;
        }

        public bool Remove(K key)
        {
            bool removed = false;
            if (array.Remove(key))
            {
                count--;
                removed = true;
            }

            return removed;
        }

        public V this[K key]
        {
            get
            {
                V value;
                if (!array.TryGetValue(key, out value))
                {
                    throw new ArgumentException("Invalid key");
                }
                return value;
            }
            set
            {
                array.Update(key, value);
            }
        }

        public bool TryGetValue(K key, out V value)
        {
            bool isValidValue = array.TryGetValue(key, out value);
            return isValidValue;
        }

        public bool ContainsKey(K key)
        {
            V value;
            bool containsKey = array.TryGetValue(key, out value);
            return containsKey;
        }

        public bool ContainsValue(V value)
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

        public IEnumerable<K> Keys
        {
            get
            {
                return array.Keys;
            }
        }

        public IEnumerable<V> Values
        {
            get
            {
                return array.Values;
            }
        }

        public IEnumerable<KeyValuePair<K, V>> Items
        {
            get
            {
                return array.Items;
            }
        }

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
            HashTableArray<K, V> largerArray = new HashTableArray<K, V>(array.Capacity * 2);

            foreach (var node in array.Items)
            {
                largerArray.Add(node.Key, node.Value);
            }

            array = largerArray;
            maxItemsAtCurrentSize = (int)(array.Capacity * fillFactor) + 1;
        }
    }
}