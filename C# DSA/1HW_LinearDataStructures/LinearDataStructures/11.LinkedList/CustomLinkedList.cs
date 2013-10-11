using System;
using System.Collections;
using System.Collections.Generic;

namespace _11.LinkedList
{
    public class CustomLinkedList<T> : IEnumerable<T>
    {
        private Node front;
        private Node back;
        private int countElements;

        private class Node
        {
            private T value;
            private Node nextNode;

            public T Element
            {
                get { return value; }
                set { value = value; }
            }

            public Node Next
            {
                get { return nextNode; }
                set { nextNode = value; }
            }

            public Node(T element, Node prevNode)
            {
                this.value = element;
                prevNode.nextNode = this;
            }

            public Node(T element)
            {
                this.value = element;
                nextNode = null;
            }
        }

        public CustomLinkedList()
        {
            this.front = null;
            this.back = null;
            this.countElements = 0;
        }

        public int Count
        {
            get
            {
                return countElements;
            }
        }

        public void AddFirst(T item)
        {
            var node = new Node(item);
            node.Next = front;
            front = node;
        }

        public void AddLast(T item)
        {
            // empty list
            if (front == null)
            {
                front = new Node(item);
                back = front;
            }
            else
            {
                Node newNode = new Node(item, back);
                back = newNode;
            }

            countElements++;
        }

        public T RemoveAtIndex(int index)
        {
            if (index < 0 || index >= countElements)
            {
                throw new ArgumentOutOfRangeException(
                    "Invalid delete index: " + index);
            }

            Node currentNode = front;
            Node prevNode = null;
            for (int currentIndex = 0; currentIndex < index; currentIndex++)
            {
                prevNode = currentNode;
                currentNode = currentNode.Next;
            }

            // Remove the element
            countElements--;
            if (countElements == 0)
            {
                front = null;
                back = null;
            }
            else if (prevNode == null)
            {
                front = currentNode.Next;
            }
            else
            {
                prevNode.Next = currentNode.Next;
            }

            return currentNode.Element;
        }

        public int IndexOf(T item)
        {
            int index = -1; //not found
            Node current = front;
            while (current != null)
            {
                if ((current.Element != null &&
                     current.Element == (dynamic)item) ||
                    (current.Element == null) && (item == null))
                {
                    break;
                }
                current = current.Next;
                index++;
            }

            return index;
        }

        public bool Contains(T item)
        {
            int index = IndexOf(item);
            bool found = false;
            if (index != -1)
            {
                found = true;
            }

            return found;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = front;
            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

