using System;

namespace Lab_06
{
    internal class LinkedStack<T>
    {
        private Node head;

        public int getLength()
        {
            var temp = head;
            if (head == null)
            {
                Console.WriteLine("Стек пуст");
                return 0;
            }

            var n = 1;
            while (temp.next != null)
            {
                temp = temp.next;
                n++;
            }

            return n;
        }

        public void Push(T value)
        {
            var newNode = new Node(value);
            if (head == null)
                newNode.next = null;
            else
                newNode.next = head;
            head = newNode;
        }

        public T Pop()
        {
            if (head == null)
            {
                Console.WriteLine("Stack Underflow. Deletion not possible");
                throw new
                    NotSupportedException("Стек пуст");
            }

            var ans = head;
            head = head.next;
            return ans.data;
        }

        public T Peek()
        {
            if (head == null)
                throw new
                    NotSupportedException("Стек пуст");

            return head.data;
        }

        private class Node
        {
            public readonly T data;
            public Node next;

            public Node(T d)
            {
                data = d;
                next = null;
            }
        }
    }
}