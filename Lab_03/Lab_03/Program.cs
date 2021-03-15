using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMO
{
    class Program
    {
        static void Main(string[] args)
        {
            double s;
            int n = 4; //размерность системы
            double[,] a = new double[n, n];
            double[] b = new double[n];
            double[] x = new double[n];

            for (int i = 0; i < n; i++)
                x[i] = 0;
            Console.WriteLine("Коэффициенты системы:");

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = double.Parse(Console.ReadLine());

            Console.WriteLine("Свободные коэффициенты:");
            for (int i = 0; i < n; i++)
                b[i] = double.Parse(Console.ReadLine());

            for (int k = 0; k < n - 1; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    for (int j = k + 1; j < n; j++)
                        a[i, j] = a[i, j] - a[k, j] * (a[i, k] / a[k, k]);
                    b[i] = b[i] - b[k] * a[i, k] / a[k, k];
                }
            }
            for (int k = n - 1; k >= 0; k--)
            {
                s = 0;
                for (int j = k + 1; j < n; j++)
                    s += a[k, j] * x[j];
                x[k] = (b[k] - s) / a[k, k];
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write("|");
                for (int j = 0; j < n; j++)
                    Console.Write($"{a[i, j]} ");
                Console.WriteLine("|");
            }
            for (int i = 0; i < n; i++)
                Console.WriteLine($"|{b[i]}| ");
            Console.WriteLine("Система имеет следующие корни");
            for (int i = 0; i < x.Length; i++)
                Console.WriteLine($"x{i} = {x[i]:0.##}");
        }
    }
}