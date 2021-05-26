using System;
using System.Text;

namespace Lab_06
{
    public class EvaluateString
    {
        public static double calc(string expression)
        {
            var str = expression.ToCharArray();
            var values = new LinkedStack<double>();
            var ops = new LinkedStack<char>();
            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    continue;
                if (str[i] >= '0' && str[i] <= '9')
                {
                    var sbuf = new StringBuilder();
                    while (i < str.Length && str[i] >= '0' && str[i] <= '9')
                        sbuf.Append(str[i++]);
                    values.Push(double.Parse(sbuf.ToString()));
                    i--;
                }
                else if (str[i] == '(')
                {
                    ops.Push(str[i]);
                }
                else if (str[i] == ')')
                {
                    while (ops.Peek() != '(')
                        values.Push(operation(ops.Pop(), values.Pop(), values.Pop()));
                    ops.Pop();
                }
                else if (str[i] == '+' || str[i] == '-' || str[i] == '*' || str[i] == '/')
                {
                    while (ops.getLength() > 0 && hasPrecedence(str[i], ops.Peek()))
                        values.Push(operation(ops.Pop(), values.Pop(), values.Pop()));
                    ops.Push(str[i]);
                }

                Console.WriteLine("Hello World!");
            }

            while (ops.getLength() > 0)
                values.Push(operation(ops.Pop(), values.Pop(), values.Pop()));
            return values.Pop();
        }

        private static bool hasPrecedence(char op1, char op2)
        {
            if (op2 == '(' || op2 == ')')
                return false;
            if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
                return false;
            return true;
        }

        private static double operation(char op, double b, double a)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                        throw new
                            NotSupportedException("Cannot divide by zero");
                    return a / b;
            }

            return 0;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var list = new List(1);
            list.insert(0,1);
            list.insert(1, 1);
            list.insert(2, 2);
            list.insert(0, 3);
            list.remove(1);
            for (int i = 0; i < list.getLength(); i++)
            {
                Console.WriteLine(list.retrieve(i));
            }
            Console.WriteLine();

            var plist = new PointerList(1);
            plist.insert(0, 1);
            plist.insert(1, 1);
            plist.insert(2, 2);
            plist.insert(0, 3);
            plist.remove(1);
            for (int i = 0; i < plist.getLength(); i++)
            {
                Console.WriteLine(plist.retrieve(i));
            }
            Console.WriteLine();

            var dlist = new DoubleList(1);
            dlist.insert(0, 1);
            dlist.insert(1, 1);
            dlist.insert(2, 2);
            dlist.insert(0, 3);
            dlist.remove(1);
            for (int i = 0; i < dlist.getLength(); i++)
            {
                Console.WriteLine(dlist.retrieve(i));
            }
            
            //LinkedStack<int> stack = new LinkedStack<int>();
            //stack.Push(3);
            //stack.Push(4);
            //stack.Push(5);
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());
            Console.WriteLine(EvaluateString.calc("2*(3+2)*((5*2-8)+(6-2*2))"));
        }
    }
}