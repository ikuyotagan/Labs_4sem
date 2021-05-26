using System;

namespace Lab_06
{
    public class CircularList
    {
        private Node head;

        public void push(int data)
        {
            var ptr1 = new Node();
            var temp = head;
            ptr1.data = data;
            ptr1.next = head;
            if (head != null)
            {
                while (temp.next != head)
                    temp = temp.next;
                temp.next = ptr1;
            }
            else
            {
                ptr1.next = ptr1;
            }

            head = ptr1;
        }

        public void printList()
        {
            var temp = head;
            if (head != null)
                do
                {
                    Console.Write(temp.data + " ");
                    temp = temp.next;
                } while (temp != head);
        }

        private class Node
        {
            public int data;
            public Node next;
        }
    }
}