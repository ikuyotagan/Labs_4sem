using System;

namespace Lab_06
{
    public class Queue
    {
        private int count;
        private int front;
        private readonly int[] Items = new int[100];
        private int rear;

        public bool IsEmpty()
        {
            return count == 0;
        }

        public void CreateQueue()
        {
            front = 0;
            rear = -1;
        }

        public void EnQueue(int NewItem)
        {
            if (count == 100)
            {
                Console.WriteLine("Очередь полна");
            }
            else
            {
                rear = (rear + 1) % 100;
                Items[rear] = NewItem;
                ++count;
            }
        }

        public void DeQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Очередь пуста");
            }
            else
            {
                front = (front + 1) % 100;
                --count;
            }
        }

        public int GetFront()
        {
            if (count == 0)
            {
                Console.WriteLine("Очередь пуста");
                return -1;
            }

            return Items[front];
        }
    }
}