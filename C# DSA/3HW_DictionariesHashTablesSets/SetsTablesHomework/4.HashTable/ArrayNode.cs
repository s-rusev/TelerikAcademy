using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.HashTable
{
    public class ArrayNode<K, V>
    {
        LinkedList<KeyValuePair<K, V>> items;

        public ArrayNode()
        {
            items = new LinkedList<KeyValuePair<K, V>>();
        }

        public void Add(K key, V value)
        {
            foreach (var pair in items)
            {
                if (pair.Key.Equals(key))
                {
                    throw new ArgumentException("Key already exists in collection.");
                }
            }
            items.AddLast(new KeyValuePair<K, V>(key, value));
        }

        public bool Update(K key, V value)
        {
            bool updated = false;

            for (var it = items.First; it != null; it = it.Next)
            {
                if (it.Value.Key.Equals(key))
                {
                    it.Value = new KeyValuePair<K, V>(key, value);
                    updated = true;
                    break;
                }
            }

            return updated;
        }

        public bool TryGetValue(K key, out V value)
        {
            bool found = false;
            value = default(V);

            if (items != null)
            {
                foreach (var pair in items)
                {
                    if (pair.Key.Equals(key))
                    {
                        value = pair.Value;
                        found = true;
                        break;
                    }
                }
            }

            return found;
        }

        public bool Remove(K key)
        {
            bool removed = false;
            if (items != null)
            {
                foreach (var pair in items)
                {
                    if (pair.Key.Equals(key))
                    {
                        items.Remove(pair);
                        removed = true;
                        break;
                    }
                }
            }

            return removed;
        }

        public void Clear()
        {
            items.Clear();
        }

        public IEnumerable<V> Values
        {
            get
            {
                foreach (var pair in items)
                {
                    yield return pair.Value;
                }
            }
        }

        public IEnumerable<K> Keys
        {
            get
            {
                if (items != null)
                {
                    foreach (var pair in items)
                    {
                        yield return pair.Key;
                    }
                }
            }
        }

        public IEnumerable<KeyValuePair<K, V>> Items
        {
            get
            {
                foreach (var pair in items)
                {
                    yield return pair;
                }
            }
        }
    }
}