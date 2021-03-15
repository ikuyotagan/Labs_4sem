using Lab_01;
using System;
using System.Runtime.InteropServices;

namespace Lab_01
{
    class Sort
    {
        private static int Partition(int[] array, int start, int end)
        {
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] <= array[end])
                {
                    int temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            return marker - 1;
        }

        public static void Quicksort(int[] array, int start, int end)
        {   
            if (start >= end)
            {
                return;
            }
            int pivot = Partition(array, start, end);
            Quicksort(array, start, pivot - 1);
            Quicksort(array, pivot + 1, end);
        }
        public static void SelectionSort(int[] array)
        {
            int min, temp;
            int length = array.Length;
            for (int i = 0; i < length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    temp = array[i];
                    array[i] = array[min];
                    array[min] = temp;
                }
            }
        }
        public static int Search<T>(T[] data, T value) where T : IComparable
        {
            var left = data.GetLowerBound(0);
            var right = data.GetUpperBound(0);
            Console.WriteLine(left);
            Console.WriteLine(right);
            if ((left == right)&&(data[left].CompareTo(value)==0))
                return left;
            while (true)
            {
                    var middle = left + (right - left) / 2;
                    var comparisonResult = data[middle].CompareTo(value);
                    if (comparisonResult == 0)
                        return middle;
                    if (comparisonResult < 0)
                        left = middle;
                    if (comparisonResult > 0)
                        right = middle;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] M = new int[10] { 1, 2, 3, 5, 20, 19, 32, 25, 75, 10 };
            Sort.Quicksort(M, 0, 9);
            for (int i = 0; i <= 9; i++)
                Console.WriteLine(M[i]);

            M = new int[10] { 1, 2, 3, 5, 20, 19, 32, 25, 75, 10 };
            Sort.SelectionSort(M);
            for (int i = 0; i <= 9; i++)
                Console.WriteLine(M[i]);
            Console.WriteLine(M[Sort.Search<int>(M, 13)]);
        }
    }
}
