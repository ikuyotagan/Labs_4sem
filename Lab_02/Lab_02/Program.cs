using System;

namespace Lab_02
{
    // C # программа для реализации Runge
    // метод Кутты
    class GFG
    {
        static double function(double x, double y)
        {
            return (y/x);
        }
        static double pervfunction(double x, double y)
        {
            return (y*(Math.Log(x)));
        }
        static double profunction(double x, double y)
        {
            return (1/x);
        }
        public static long Fact(long n)
        {
            if (n == 0)
                return 1;
            else
                return n * Fact(n - 1);
        }
        public static double rungeKutta(double x0, double y0, double x, double h)
        {
            int n = (int)Math.Round((x - x0) / h);
            double k1, k2, k3, k4;
            double y = y0;
            for (int i = 1; i <= n; i++)
            {
                k1 = h * (function(x0, y));
                k2 = h * (function(x0 + 0.5 * h, y + 0.5 * k1));
                k3 = h * (function(x0 + 0.5 * h, y + 0.5 * k2));
                k4 = h * (function(x0 + h, y + k3));
                x0 += h;
                y += (1.0 / 6.0) * (k1 + 2 * k2 + 2 * k3 + k4);
                Console.WriteLine("The value of y at {0:0.##} is : {1:0.##}", x0, y);
            }
            return y;
        }
        public static double Adamskor(double x0, double y0, double x, double h)
        {
            Console.WriteLine();
            Console.WriteLine();
            double x1 = x0 + h;
            double y1 = rungeKutta(x0, y0, x1, h);
            double x2 = x1 + h;
            double y2 = rungeKutta(x0, y0, x2, h);
            double x3 = x2 + h;
            double y3 = rungeKutta(x0, y0, x3, h);
            double y = y0;
            int n = (int)((x - x3) / h);
            double x4 = x3 + h;
            for (int i = 1; i < n; i++)
            {
                y = y3 + h * (-9 * function(x0, y0) + 37 * function(x1, y1) - 59 * function(x2, y2) + 55 * function(x3, y3)) / 24;
                y = y3 + h * (function(x1, y1) - 5 * function(x2, y2) + 19 * function(x3, y3) + 9 * function(x4, y)) / 24;
                x0 = x1;
                y0 = y1;
                x1 = x2;
                y1 = y2;
                x2 = x3;
                y2 = y3;
                x3 = x4;
                y3 = y;
                x4 += h;
                Console.WriteLine("The value of y at {0:0.##} is : {1:0.##}", x4, y);
            }
            return y;
        }
        public static double Adams(double x0, double y0, double x, double h)
        {
            Console.WriteLine(); 
            Console.WriteLine();
            double x1 = x0 + h;
            double y1 = rungeKutta(x0, y0, x1, h);
            double x2 = x1 + h;
            double y2 = rungeKutta(x0, y0, x2, h);
            double x3 = x2 + h;
            double y3 = rungeKutta(x0, y0, x3, h);
            double y = y0;
            int n = (int)((x - x3) / h);
            double x4 = x3 + h;
            for (int i = 1; i < n; i++)
            {
                double f1 = function(x3, y3) - function(x2, y2);
                double f2 = function(x3, y3) - 2 * function(x2, y2) + function(x1, y1);
                double f3 = function(x3, y3) - 3 * function(x2, y2) + 3 * function(x1, y1) - function(x0, y0);
                y = y3 + h * y3 + (h * h * f1 )/ 2 + (5 * h * h * h * f2 )/ 12 + (3 * h * h * h * h * f3 )/ 8;
                x0 = x1; 
                y0 = y1;
                x1 = x2;
                y1 = y2;
                x2 = x3;
                y2 = y3;
                x3 = x4;
                y3 = y;
                x4 += h;
                Console.WriteLine("The value of y at {0:0.##} is : {1:0.##}", x4, y);
            }
            return y;
        }
        public static double Priblizh(double x0, double y0, double x)
        {
            Console.WriteLine();
            Console.WriteLine();
            double a, b, y;
            long N;
            double yl = y0;
            y = y0 + pervfunction(x, y0) - pervfunction(x0, y0);
            a = 100;
            b = 100;
            double max = 0;
            for (double i = Math.Min(x0, a); i < (Math.Max(x0, a)); i+=0.01)
                for (double j = Math.Min(y0, b); j < (Math.Max(y0, b)); j+=0.01)
                    if (Math.Abs(function(i, j)) > max)
                        max = Math.Abs(function(i, j));
            double maxn = 0;
            for (double i = Math.Min(x0, a); i < (Math.Max(x0, a)); i += 0.01)
                for (double j = Math.Min(y0, b); j < (Math.Max(y0, b)); j += 0.01)
                    if (Math.Abs(profunction(i, j)) > maxn)
                        maxn = Math.Abs(profunction(i, j));
            N = 1;
            double h = Math.Min(a, b / max);
            while (Math.Abs(yl - y) <= Math.Pow(maxn, N) * max * Math.Pow(h, (N + 1)) / Fact(N + 1))
            {
                
                yl = y0 + pervfunction(x, yl) - pervfunction(x0, yl);
                y = y0 + pervfunction(x, y) - pervfunction(x0, y);
                //max = 0;
                h = Math.Min(a, b / max);
                N++;
                Console.WriteLine("The value of y at {0} is : {1:0.####}",x,y);
            }
            return y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double x0 = 8, y0 = 8, x = 9, h = 0.1;
            Console.WriteLine("\nThe value of y at x is : " + GFG.rungeKutta(x0, y0, x, h));
            Console.WriteLine("\nThe value of y at x is : " + GFG.Adamskor(x0, y0, x, h));
            Console.WriteLine("\nThe value of y at x is : " + GFG.Adams(x0, y0, x, h));
            Console.WriteLine("\nThe value of y at x is : " + GFG.Priblizh(x0, y0, x));
        }
    }
}
