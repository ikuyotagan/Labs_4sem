using System;
using System.Collections.Generic;

namespace Lab_07
{
    class Doubler
    {
        private static Dictionary<string, string> dict = new Dictionary<string, string>
        {
            { "*a", "aA*_" },
            { "*b", "bB*_" },
            { "*_", "#" },
            { "A#a", "aA#" },
            { "A#b", "bA#" },
            { "B#a", "aB#" },
            { "B#b", "bB#" },
            { "A#", "#a" },
            { "B#", "#b" },
            { "#", "" },
        };

        public static string doubleStr(string word)
        {
            if (word.Length == 0)
            {
                Console.WriteLine("Слово пустое");
                return "-1";
            }
            bool found;
            int n = word.Length;
            for (int i = 0; i < 2 * n; i += 2)
            {
                word = word.Insert(i, "*");
            }
            do
            {
                found = false;
                foreach (KeyValuePair<string, string> pair in dict)
                {
                    if (word.Contains(pair.Key))
                    {
                        found = true;
                        int position = word.IndexOf(pair.Key);
                        word = word.Remove(position, pair.Key.Length);
                        word = word.Insert(position, pair.Value);
                        break;
                    }
                }
            }
            while (found);
            Console.WriteLine("Результат: {0}", word);
            return word;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите слово: ");
            string word = Console.ReadLine();
            Doubler.doubleStr(word);
        }
    }
}
