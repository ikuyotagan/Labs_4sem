using System;
using System.Linq;

namespace Lab_08
{
    public class Equationfuck
    {
        private static int[,] QuickSort(int[,] a, int i, int j)
        {
            if (i < j)
            {
                int q = Partition(a, i, j);
                a = QuickSort(a, i, q);
                a = QuickSort(a, q + 1, j);
            }

            return a;
        }

        private static int Partition(int[,] a, int p, int r)
        {
            int x = a[p, 4];
            int i = p - 1;
            int j = r + 1;
            while (true)
            {
                do
                    j--;
                while (a[j, 4] > x);
                do
                    i++;
                while (a[i, 4] < x);
                if (i < j)
                {
                    int[] tmp = new int[5];
                    for (int k = 0; k < 5; k++)
                        tmp[k] = a[i, k];
                    for (int k = 0; k < 5; k++)
                        a[i, k] = a[j, k];
                    for (int k = 0; k < 5; k++)
                        a[j, k] = tmp[k];
                }
                else
                    return j;
            }
        }

        private int[,] population = new int[4, 5];
        private Random rnd = new Random();

        public Equationfuck()
        {
            for (int i = 0; i < 4; i++)
            {
                population[i, 4] = 0;
                for (int j = 0; j < 4; j++)
                {
                    population[i, j] = rnd.Next(1, (30 / (i + 1)) + 1);
                    population[i, 4] += (j + 1) * population[i, j];
                }
            }

            for (int k = 0; k < 4; k++)
                population[k, 4] = Math.Abs(population[k, 4] - 30);
        }

        public void EquationSolve()
        {
            while (population[0, 4] != 0)
            {
                Mutation();
                Match();
                population = QuickSort(population, 0, 3);
                print();
            }
        }

        public void Match()
        {
            int[,] pop = population;
            population[3, 0] = pop[2, 0];
            population[3, 1] = pop[0, 1];
            population[3, 2] = pop[0, 2];
            population[3, 3] = pop[1, 3];
            population[3, 4] = 0;
            for (int j = 0; j < 4; j++)
                population[3, 4] += (j + 1) * population[3, j];

            population[0, 2] = pop[1, 2];
            population[0, 3] = pop[2, 3];
            population[0, 4] = 0;
            for (int j = 0; j < 4; j++)
                population[0, 4] += (j + 1) * population[0, j];

            population[1, 0] = pop[0, 0];
            population[1, 2] = pop[2, 2];
            population[1, 3] = pop[0, 3];
            population[1, 4] = 0;
            for (int j = 0; j < 4; j++)
                population[1, 4] += (j + 1) * population[1, j];

            population[2, 0] = pop[1, 0];
            population[2, 2] = pop[0, 2];
            population[2, 3] = pop[0, 3];
            population[2, 4] = 0;
            for (int j = 0; j < 4; j++)
                population[2, 4] += (j + 1) * population[2, j];

            for (int k = 0; k < 4; k++)
                population[k, 4] = Math.Abs(population[k, 4] - 30);
        }

        public void Mutation()
        {
            int b = rnd.Next(0, 4);
            population[rnd.Next(0, 4), b] = rnd.Next(1, (31 / (b + 1)) + 1);
            b = rnd.Next(0, 4);
            population[rnd.Next(0, 4), b] = rnd.Next(1, (31 / (b + 1)) + 1);
        }

        public void print()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 5; i++)
                    Console.Write(population[j, i] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void printAns()
        {
            Console.Write("y = " + population[0, 0]);
            for (int i = 1; i < 4; i++)
                Console.Write(" + " + (i+1) + "*" + population[0, i]);
            Console.Write(" = 30");
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Equationfuck fuck = new Equationfuck();
            fuck.EquationSolve();
            fuck.printAns();
        }
    }
}
