using System;

namespace Lab_06
{
    public class DoubleList
    {
        public Node head;

        public DoubleList(int d)
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
                head.prev = newNode;
                newNode.next = head;
                //newNode.prev = head.prev;
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
            new_node.prev = prev_node;
            if (new_node.next != null)
                new_node.next.prev = new_node;
        }

        public void remove(int element_num)
        {
            var del = head;
            for (var i = 0; i < element_num; i++)
                del = del.next;
            if (head == null || del == null)
                return;
            if (head == del)
                head = del.next;
            if (del.next != null)
                del.next.prev = del.prev;
            if (del.prev != null)
                del.prev.next = del.next;
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

        public static void printlist(Node node)
        {
            Node last = null;
            Console.WriteLine("Обход в прямом порядке");
            while (node != null)
            {
                Console.Write(node.data + " ");
                last = node;
                node = node.next;
            }

            Console.WriteLine();
            Console.WriteLine("Обход в обратном порядке");
            while (last != null)
            {
                Console.Write(last.data + " ");
                last = last.prev;
            }
        }

        public class Node
        {
            public int data;
            public Node next;
            public Node prev;

            public Node(int d)
            {
                data = d;
            }
        }
    }
}