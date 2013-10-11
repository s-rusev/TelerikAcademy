using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Implement methods for adding element , accessing element by index (check), removing 
//element by index , inserting element at given position, clearing the list (check), finding element by its value(check) and ToString() (check). 

namespace DynamicList
{
    public class GenericList<T> where T: IComparable
    {
        private T[] container;
        private int countOfElements;
        private static readonly int initalCapacity = 10;

        public GenericList()
        {
            this.container = new T[initalCapacity];
            countOfElements = 0;
        }

        public GenericList(T[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }
            if (arr.Length == 0)
            {
                throw new ArgumentException("Array has no elements"); // later we wont be able to extend x2 the length of array
            }
            this.container = new T[arr.Length];
            this.countOfElements = arr.Length;
            arr.CopyTo(this.container, 0);
        }

        public int CountOfElements
        {
            get
            {
                return this.countOfElements;
            }
        }

        public T[] Container
        {
            get
            {
                return this.container;
            }
            set
            {
                this.container = value;
            }
        }

        public T Min() 
        {
            //return this.container.Min();  
            T min = this.container[0];
            for (int i = 1; i < this.container.Length; i++)
            {
                if (this.container[i].CompareTo(min) < 0)
                {
                    min = this.container[i];
                }
            }
            return min;
        }

        public T Max()
        {
            T max = this.container[0];
            for (int i = 1; i < this.container.Length; i++)
            {
                if (this.container[i].CompareTo(max) > 0)
                {
                    max = this.container[i];
                }
            }
            return max;
        }

        //deletes all elements in the list
        public void ClearList()
        {
            this.container = new T[initalCapacity];
            this.countOfElements = 0;
        }

        //finds the index of first occurance of item T
        public int IndexOf(T item)
        {
            for (int i = 0; i < this.container.Length; i++)
            {
                if (item.Equals(this.container[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public void RemoveByIndex(int index)
        {
            if (index >= this.countOfElements || index < 0)
            {
                throw new ArgumentOutOfRangeException(
                "Invalid index: " + index);
            }
            var tempArray = new T[this.CountOfElements - 1];
            Array.Copy(this.container, 0, tempArray, 0, index);
            Array.Copy(this.container, index + 1, tempArray, index, (this.container.Length - 1 - index));
            this.container = tempArray;
            this.countOfElements--;
        }

        public T ElementAt(int index)
        {
            if (index < 0 || index > container.Length)
            {
                throw new IndexOutOfRangeException("Index out of bounds of the array!");
            }
            if (index.GetType() != typeof(int))
            {
                throw new ArgumentException("Index must be a number!");
            }
            return this.container[index];
        }


        public void Add(T item)
        {
            AddByIndex(this.countOfElements, item);
        }

        public void AddByIndex(int index, T item)
        {
            if (index > this.container.Length || index < 0)
            {
                throw new IndexOutOfRangeException(
                "Invalid index: " + index);
            }
            T[] extendedArr = this.container;
            if (this.countOfElements + 1 > this.container.Length)
            {
                extendedArr = new T[this.countOfElements * 2];
                
            }
            Array.Copy(this.container, extendedArr, index);
            this.countOfElements++;
            Array.Copy(this.container, index, extendedArr, index + 1, this.countOfElements - index - 1);
            extendedArr[index] = item;
            this.container = extendedArr;
        }

        public override string ToString()
        {
            //problem with null values
            //string concatenated = string.Join(",",
            //              container.Select(x => x.ToString()).ToArray());
            StringBuilder sb = new StringBuilder();
            //foreach (var item in this.container)
            //{
            //    if (item != null)
            //    {
            //        sb.Append(item).Append("\n");
            //    }
            //}
            for (int i = 0; i < this.countOfElements; i++)
            {
                sb.Append("\n").Append(this.container[i]);
            }
           
            return string.Format("Values: {0} ", sb.ToString());
        }
    }
}
