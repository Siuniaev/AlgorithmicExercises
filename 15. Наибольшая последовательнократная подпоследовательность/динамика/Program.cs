/*
Задача: наибольшая последовательнократная подпоследовательность.
Дано целое число 1 ≤ n ≤ 10^3 и массив A[1…n] натуральных чисел, не превосходящих 2*10^9.
Выведите максимальное 1 ≤ k ≤ n, для которого найдётся подпоследовательность 1 ≤ i1 < i2 < … < ik ≤ n длины k,
в которой каждый элемент делится на предыдущий (формально: для  всех 1 ≤ j < k, A[ij]|A[ij+1]).

Sample Input:
4
3 6 7 12

Sample Output:
3
*/

using System;
using System.Linq;

namespace динамика
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();            

            int result = MultipliesCount(arr, n);
            Console.WriteLine(result);
            Console.Read();
        }

        static int MultipliesCount(int[] a, int n)
        {
            if (a.Length != n) return -1;

            int result = 0;

            int[] D = new int[n];
            int[] prev = new int[n];

            for (int i = 0; i < a.Length; i++)
            {
                D[i] = 1;
                prev[i] = 1;

                for (int j = 0; j < i; j++)
                {
                    if (a[i] % a[j] == 0 && D[j] + 1 > D[i])
                    {
                        D[i] = D[j] + 1;
                        prev[i] = j;
                    }
                }
            }

            for (int i = 0; i < n; i++)
                result = Math.Max(result, D[i]);

            return result;
        }
    }
}
