﻿namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
   
    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                int minElementIndex = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[minElementIndex]) < 0)
                    {
                        minElementIndex = j;
                    }
                }

                if (minElementIndex != i)
                {
                    T swap = collection[i];
                    collection[i] = collection[minElementIndex];
                    collection[minElementIndex] = swap;
                }
            }
        }
    }
}
