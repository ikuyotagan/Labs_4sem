using System;

namespace Lab_06
{
    public class PointerList
    {
        private Node head;

        public PointerList(int d)
        {
            head = new Node(d);
        }

        public void destroyList()
        {
            head = null;
        }

        public bool isEmpty()
        {
            return head != null;
        }

        public int getLength()
        {
            var temp = head;
            var count = 0;
            while (temp != null)
            {
                count++;
                temp = temp.next;
            }

            return count;
        }

        public void insert(int element_num, int new_data)
        {
            var prev_node = head;
            if (element_num == 0)
            {
                var newNode = new Node(new_data);
                newNode.next = head;
                head = newNode;
                return;
            }
            for (var i = 0; i < element_num-1; i++)
                prev_node = prev_node.next;
            if (prev_node == null)
            {
                Console.WriteLine("Такой позиции нет");
                throw new
                    NotSupportedException("Ошибочка");
            }

            var new_node = new Node(new_data);
            new_node.next = prev_node.next;
            prev_node.next = new_node;
        }

        public void remove(int position)
        {
            if (head == null)
                return;
            var temp = head;
            if (position == 0)
            {
                head = temp.next;
                return;
            }

            for (var i = 0; temp != null && i < position - 1; i++)
                temp = temp.next;
            if (temp == null || temp.next == null)
            {
                Console.WriteLine("Такой позиции нет");
                throw new
                    NotSupportedException("Ошибочка");
            }

            var next = temp.next.next;
            temp.next = next;
        }

        public int find(int x)
        {
            var current = head;
            var n = 0;
            while (current != null)
            {
                if (current.data == x)
                    return n;
                current = current.next;
                n++;
            }

            Console.WriteLine("Такой позиции нет");
            throw new
                NotSupportedException("Ошибочка");
        }

        public int retrieve(int x)
        {
            var current = head;
            var n = 0;
            do
            {
                if (n == x)
                    return current.data;
                current = current.next;
                n++;
            } while (current != null && n != x);
            if (n == x)
                return current.data;
            Console.WriteLine("Такой позиции нет");
            throw new
                NotSupportedException("Ошибочка");
        }

        public void printList()
        {
            var n = head;
            while (n != null)
            {
                Console.Write(n.data + " ");
                n = n.next;
            }
        }

        public class Node
        {
            public int data;
            public Node next;

            public Node(int d)
            {
                data = d;
                next = null;
            }
        }
    }
}