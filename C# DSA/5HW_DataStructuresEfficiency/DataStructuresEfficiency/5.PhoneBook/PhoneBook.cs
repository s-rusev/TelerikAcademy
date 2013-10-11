using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _5.PhoneBook
{
    public class PhoneBook
    {
        OrderedMultiDictionary<string, string> namePhones =
            new OrderedMultiDictionary<string, string>(true);
        OrderedMultiDictionary<Tuple<string, string>, string> nameAndTownPhones =
            new OrderedMultiDictionary<Tuple<string, string>, string>(true);

        public PhoneBook(string[] fileLines)
        {
            for (int i = 0; i < fileLines.Length; i++)
            {
                string[] lineTokens = fileLines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public IEnumerable<string> PhonesByName(string key1)
        {
            return namePhones[key1];
        }

        public IEnumerable<string> PhonesByNameAndTown(string key1, string key2)
        {
            Tuple<string, string> key = new Tuple<string, string>(key1, key2);
            return nameAndTownPhones[key];
        }

        public void Add(string key1, string key2, string value)
        {
            Tuple<string, string> tuple = new Tuple<string, string>(key1, key2);
            namePhones[key1].Add(value);
            nameAndTownPhones[tuple].Add(value);
        }
    }
}
