using System;

namespace Lab_06
{
    internal class Stack
    {
        private readonly int[] array = new int[100];
        private int max_size;

        private int getTop()
        {
            if (max_size == 0)
            {
                Console.WriteLine("Стек пуст");
                throw new
                    NotSupportedException("Ошибочка");
            }

            return array[max_size];
        }

        private void createStack()
        {
            max_size = 0;
        }

        private int pop()
        {
            if (max_size == 0) 
                throw new 
                    NotSupportedException("Ошибочка");
            else --max_size;
            return array[max_size];
        }

        private void push(int NewItem)
        {
            if (max_size >= 100) 
                throw new
                    NotSupportedException("Ошибочка");
            else array[++max_size] = NewItem;
        }

        private bool isEmpty()
        {
            return max_size == 0;
        }

        private void destroyStack()
        {
            max_size = 0;
        }
    }
}