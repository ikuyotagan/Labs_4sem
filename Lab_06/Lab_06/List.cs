using System;

namespace Lab_06
{
    public class List
    {
        private int[] Items = new int[100];
        private int last = 1;

        public List(int firstItem)
        {
            Items[0] = firstItem;
        }

        public void destroyList()
        {
            Items = null;
        }

        public bool isEmpty()
        {
            return last == 0;
        }

        public int getLength()
        {
            return last;
        }

        public void insert(int n, int newItem)
        {
            if (last >= 100)
            {
                Console.WriteLine("Список полон");
            }
            else if (n > last)
            {
                throw new
                    NotSupportedException("Ошибочка");
            }
            else
            {
                for (var i = last; i >= n; i--)
                    Items[i + 1] = Items[i];
                last += 1;
                Items[n] = newItem;
            }
        }

        public void remove(int n)
        {
            if (n > last || n < 1)
            {
                Console.WriteLine("Такой позиции нет");
            }
            else
            {
                last--;
                for (var i = n; i <= last; i++)
                    Items[i] = Items[i + 1];
            }
        }

        public int find(int x)
        {
            for (var i = 0; i <= last; i++)
                if (Items[i] == x)
                    return i;
            return last + 1; //х не найден
        }

        public int retrieve(int n)
        {
            if (n > last || n < 0)
                Console.WriteLine("Такой позиции нет");
            else
                return Items[n];
            throw new
                NotSupportedException("Ошибочка");
        }
    }
}