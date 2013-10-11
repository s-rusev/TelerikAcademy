using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13.Queue
{
   

    public class CustomLinkedQueue<T> where T : IComparable<T>
    {
        private Node<T> front;
        private Node<T> back;
        private int countElements;

        private class Node<T> where T : IComparable<T>
        {
            private T value;
            private Node<T> next;
            private Node<T> previous;

            public T Value
            {
                get { return this.value; }
                set { this.value = value; }
            }

            public Node<T> Next
            {
                get { return this.next; }
                set { this.next = value; }
            }

            public Node<T> Previous
            {
                get { return this.previous; }
                set { this.previous = value; }
            }

            public Node()
                : this(default(T), null, null)
            {
            }

            public Node(T value)
            {
                this.value = value;
                this.next = null;
                this.previous = null;
            }

            public Node(T value, Node<T> nextValue, Node<T> prevValue)
            {
                this.value = value;
                this.next = nextValue;
                this.previous = prevValue;
            }
        }

        public int Count
        {
            get { return this.countElements; }
        }

        public CustomLinkedQueue()
        {
            this.front = null;
            this.back = null;
            this.countElements = 0;
        }

        public void Enqueue(T value)
        {
            if (this.back == null)
            {
                this.back = new Node<T>(value);
                this.front = back;
            }
            else
            {
                Node<T> newNode = new Node<T>(value, null, this.back);
                this.back.Next = newNode;
                this.back = newNode;
            }

            this.countElements++;
        }

        public T Dequeue()
        {
            if (this.countElements > 0)
            {
                T topElement = front.Value;
                if (this.front.Next == null)
                {
                    this.front = null;
                    this.back = null;
                }
                else
                {
                    this.front = front.Next;
                    this.front.Previous = null;
                }
                this.countElements--;
                return topElement;
            }
            else
            {
                throw new NullReferenceException("No elements in the queue!");
            }
        }

        public T Peek()
        {
            if (this.countElements > 0)
            {
                T topElement = this.front.Value;
                return topElement;
            }
            else
            {
                throw new NullReferenceException("No elements in the queue!");
            }
        }

        public bool Contains(T value)
        {
            bool containsValue = false;
            Node<T> currentNode = front;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    containsValue = true;
                    break;
                }
                currentNode = currentNode.Next;
            }

            return containsValue;
        }

        public void Clear()
        {
            this.countElements = 0;
            this.front = null;
            this.back = null;
        }
    }
}