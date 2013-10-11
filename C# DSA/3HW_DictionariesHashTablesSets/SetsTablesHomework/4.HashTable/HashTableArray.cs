using System;
using System.Collections.Generic;

namespace _4.HashTable
{
    public class HashTableArray<K, V>
    {
        private ArrayNode<K, V>[] array;

        public int Capacity
        {
            get
            {
                return array.Length;
            }
        }

        public HashTableArray(int capacity)
        {
            array = new ArrayNode<K, V>[capacity];
        }

        public void Add(K key, V value)
        {
            if (key == null || value == null)
            {
                return;
            }

            int index = GetIndex(key);

            if (array[index] == null)
            {
                array[index] = new ArrayNode<K, V>();
            }

            array[index].Add(key, value);
        }

        public void Update(K key, V value)
        {
            int index = GetIndex(key);
            if (array[index] == null)
            {
                throw new ArgumentException("Element does not exist");
            }

            array[index].Update(key, value);
        }

        public bool Remove(K key)
        {
            bool removed = array[GetIndex(key)].Remove(key);
            return removed;
        }

        public bool TryGetValue(K key, out V value)
        {
            int index = GetIndex(key);
            if (array[index] == null)
            {
                value = default(V);
                return false;
            }

            bool isValidValue = array[index].TryGetValue(key, out value);
            return isValidValue;
        }

        public void Clear()
        {
            foreach (var node in array)
            {
                if (node != null)
                {
                    node.Clear();
                }
            }
        }

        public IEnumerable<V> Values
        {
            get
            {
                foreach (var node in array)
                {
                    if (node != null)
                    {
                        foreach (var value in node.Values)
                        {
                            yield return value;
                        }
                    }
                }
            }
        }

        public IEnumerable<K> Keys
        {
            get
            {
                foreach (var node in array)
                {
                    if (node != null)
                    {
                        foreach (var key in node.Keys)
                        {
                            yield return key;
                        }
                    }
                }
            }
        }

        public IEnumerable<KeyValuePair<K, V>> Items
        {
            get
            {
                foreach (var node in array)
                {
                    if (node != null)
                    {
                        foreach (var pair in node.Items)
                        {
                            yield return pair;
                        }
                    }
                }
            }
        }

        private int GetIndex(K key)
        {
            return Math.Abs(key.GetHashCode() % Capacity);
        }
    }
}