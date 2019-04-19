/*
Даны целые числа 1≤n≤10^18 и 2≤m≤10^5, необходимо найти остаток от деления n-го числа Фибоначчи на m.

Sample Input:
10 2
Sample Output:
1
*/

using System;
using System.Linq;

namespace Огромное_число_Фибоначчи
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] arr = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            long n = arr[0];
            long m = arr[1];

            long fib = GetFibonacci(n, m);

            Console.WriteLine(fib);
            Console.Read();
        }

        static long GetFibonacci(long n, long m)
        {
            long remainder = n % GetPisanoPeriod(m);

            long first = 0;
            long second = 1;
            long res = remainder;

            for (int i = 1; i < remainder; i++)
            {
                res = (first + second) % m;
                first = second;
                second = res;
            }

            return res % m;
        }

        static long GetPisanoPeriod(long m)
        {
            long a = 0, b = 1, c = a + b;

            for (int i = 0; i < m * m; i++)
            {
                c = (a + b) % m;
                a = b;
                b = c;
                if (a == 0 && b == 1) return i + 1;
            }

            return 0;
        }
    }
}
