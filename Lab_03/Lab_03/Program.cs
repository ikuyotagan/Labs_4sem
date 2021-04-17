using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMO
{
    public class Slau
    {
        public static void Gauss()
        {
            double s;
            int n = 4; //размерность системы
            double[,] a = new double[n, n];
            double[] b = new double[n];
            double[] x = new double[n];
            for (int i = 0; i < n; i++)
                x[i] = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    a[i, j] = double.Parse(Console.ReadLine());
                b[i] = double.Parse(Console.ReadLine());
            }

            for (int k = 0; k < n - 1; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    for (int j = k + 1; j < n; j++)
                        a[i, j] -= a[k, j] * (a[i, k] / a[k, k]);
                    b[i] -= b[k] * a[i, k] / a[k, k];
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
                    Console.Write($"{a[i, j],-5:0.##} ");
                Console.WriteLine("|");
            }
            for (int i = 0; i < n; i++)
                Console.WriteLine($"|{b[i],-5:0.##}| ");

            Console.WriteLine("Система имеет следующие корни");
            for (int i = 0; i < x.Length; i++)
                Console.WriteLine($"x{i} = {x[i]:0.##}");
        }
        public static void Test()
        {
            int n = 4;
            double[] a = { 0, -1, 1, 1 }, b = { 2, 2, -3, 2 }, c = { 2, -0.5, -1, 0 }, d = { 1, 0, 2, 2 };
            double[] A = new double[n], B = new double[n], x = new double[n];
            double e;
            int i;
            A[0] = -c[0] / b[0];
            B[0] = d[0] / b[0];
            for (i = 1; i < n - 1; i++)
            {
                e = a[i] * A[i - 1] + b[i];
                A[i] = -c[i] / e;
                B[i] = (d[i] - a[i] * B[i - 1]) / e;
            }
            x[n - 1] = (d[n - 1] - a[n - 1] * B[n - 2]) / (b[n - 1] + a[n - 1] * A[n - 2]);
            for (i = n - 2; i >= 0; i--)
            {
                x[i] = x[i + 1] * A[i] + B[i];
            }
            Console.WriteLine("Система имеет следующие корни");
            for (i = 0; i < x.Length; i++)
                Console.WriteLine($"x{i} = {x[i]:0.##}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Slau.Gauss();
            Slau.Test();
        }
    }
}