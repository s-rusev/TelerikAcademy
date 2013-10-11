using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _4.BiDictionary
{
    public class BiKeyDictionary<K1, K2, V>
    {
        OrderedMultiDictionary<K1, V> containerFirstKey =
            new OrderedMultiDictionary<K1, V>(true);
        OrderedMultiDictionary<K2, V> containerSecondKey =
            new OrderedMultiDictionary<K2, V>(true);
        OrderedMultiDictionary<Tuple<K1, K2>, V> containerTwoKeys =
            new OrderedMultiDictionary<Tuple<K1, K2>, V>(true);

        public IEnumerable<V> FindValuesFirstKey(K1 key1)
        {
            return containerFirstKey[key1];
        }

        public IEnumerable<V> FindValuesSecondKey(K2 key2)
        {
            return containerSecondKey[key2];
        }

        public IEnumerable<V> FindValuesTwoKeys(K1 key1, K2 key2)
        {
            Tuple<K1, K2> key = new Tuple<K1, K2>(key1, key2);
            return containerTwoKeys[key];
        }

        public void Add(K1 key1, K2 key2, V value)
        {
            Tuple<K1, K2> tuple = new Tuple<K1, K2>(key1, key2);
            containerFirstKey[key1].Add(value);
            containerSecondKey[key2].Add(value);
            containerTwoKeys[tuple].Add(value);
        }
    }
}
