using System;
using System.Linq;

namespace _4.HashTable
{
    public class HashTableDemo
    {
        static void Main()
        {
            HashTable<string, int> myHashTable = new HashTable<string, int>();
            myHashTable.Add("ivan", 2);
            myHashTable.Add("Dragan", 2);
            //test of update element value
            myHashTable["Dragan"] = 3;
            int value;
            myHashTable.TryGetValue("Dragan", out value);
            Console.WriteLine("All pairs are:");
            foreach (var item in myHashTable.Items)
            {
                Console.WriteLine(item.Key + "->" + item.Value);
            }
            Console.WriteLine("Dragan's value is: " + value);
            Console.WriteLine("Count of elements:" + myHashTable.Count);
            Console.WriteLine("Adding 10000 elements...");
            for (int i = 0; i < 10000; i++)
            {
                myHashTable.Add("Person" + i, 2);
            }
            Console.WriteLine("Count of elements:" + myHashTable.Count);
            Console.WriteLine("Max items at current size:" + myHashTable.MaxItemsAtCurrentSize);
            Console.WriteLine("Hash table contains key \"Dragan\" ->" + myHashTable.ContainsKey("Dragan"));
            Console.WriteLine("Clearing the hash table...");
            myHashTable.Clear();
            Console.WriteLine("Hash table contains key \"Dragan\" ->" + myHashTable.ContainsKey("Dragan"));

            HashSet<int> myHashSet = new HashSet<int>();
            myHashSet.Add(3);
            myHashSet.Add(4);
            //myHashSet.Add(3);
            foreach (var item in myHashSet.Values)
            {
                Console.WriteLine(item);
            }

        }
    }
}
