using System;
using System.Collections.Generic;
using System.Linq;

namespace HWHZ9
{  
    public static class Ext
    {
        //1
        public static bool Fi(this int n)
        {
            if (n < 0) return false;
            if (n == 0 || n == 1) return true;

            int a = 0;
            int b = 1;
            while (b < n)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }
            return b == n;
        }

        //2
        public static int WCount(this string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;

            string[] w = s.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return w.Length;
        }

        //3
        public static int LastW(this string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;

            string[] w = s.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return w.Length == 0 ? 0 : w[w.Length - 1].Length;
        }

        //4
        public static bool Duzki(this string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> D = new Dictionary<char, char>
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' }
        };

            foreach (char c in s)
            {
                if (D.ContainsKey(c))
                {
                    stack.Push(c);
                }
                else if (D.ContainsValue(c))
                {
                    if (stack.Count == 0 || D[stack.Pop()] != c)
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        //5
        public static int[] F(this int[] array, Predicate<int> predicate)
        {
            return array.Where(x => predicate(x)).ToArray();
        }
    }

    public record DailyT(int H, int L);
    public record StuG(string S, int G);

    public class Program
    {
        public static void Main()
        {
            //1
            int n = 22;
            Console.WriteLine($"{n} Це число фібоначі: {n.Fi()}");

            //2
            string t = "Я не знаю що написати лол";
            Console.WriteLine($"Кількість слів: {t.WCount()}");

            //3
            t = "Я не знаю що написати знов лол";
            Console.WriteLine($"Довжина останнього слова: {t.LastW()}");

            //4
            string s = "{}[]";
            Console.WriteLine($"{s} Це є: {s.Duzki()}");

            //5
            int[] n1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Predicate<int> E = x => x % 2 == 0;
            int[] EN = n1.F(E);
            Console.WriteLine($"Парні: {string.Join(", ", EN)}");

            Predicate<int> O = x => x % 2 != 0;
            int[] ON = n1.F(O);
            Console.WriteLine($"Не парні: {string.Join(", ", ON)}");

            //6
            DailyT[] te =
            {
            new DailyT(22, 6),
            new DailyT(23, 18),
            };

            var MaxDiff = te
                .Select((temp, index) => new { Day = index + 1, Diff = temp.H - temp.L })
                .OrderByDescending(x => x.Diff)
                .First();

            Console.WriteLine($"День з найбільшою різницею температур: день {MaxDiff.Day} З різницею {MaxDiff.Diff} C");

            // 7
            StuG[] g =
            {
            new StuG("Матем", 185),
            new StuG("Укр мов", 190),
            new StuG("Англ мов", 187),
            new StuG("Література", 170)
            };

            var maxG = g.OrderByDescending(x => x.G).First();
            var averageG = g.Average(x => x.G);

            Console.WriteLine($"Студент з найбільшою оцінкою: {maxG.S} Оцінкою {maxG.G}");
            Console.WriteLine($"Середня оцінка: {averageG}");
        }
    }
}
