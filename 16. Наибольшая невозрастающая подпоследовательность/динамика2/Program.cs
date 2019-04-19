/*
Задача повышенной сложности: наибольшая невозрастающая подпоследовательность.
Дано целое число 1 ≤ n ≤ 10^5 и массив A[1…n], содержащий неотрицательные целые числа, не превосходящие 10^9.
Найдите наибольшую невозрастающую подпоследовательность в A. 
В первой строке выведите её длину k, во второй — её индексы 1 ≤ i1 < i2 < … < ik ≤ n (таким образом, A[i1] ≥ A[i2] ≥ … ≥ A[in]).

Sample Input:
5
5 3 4 4 2

Sample Output:
4
1 3 4 5 
*/

using System;
using System.Linq;

namespace динамика2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] result = MultipliesCount(arr);

            Console.WriteLine(result.Length);
            Console.WriteLine(string.Join(" ", result));
            Console.Read();
        }

        static int[] MultipliesCount(int[] a)
        {
            int[] P = new int[a.Length];
            int[] M = new int[a.Length + 1];
            int L = 0;

            for (int i = 0; i < a.Length; i++)
            {
                int lo = 1;
                int hi = L;

                while (lo <= hi)
                {
                    int mid = (lo + hi) / 2;

                    if (a[M[mid]] >= a[i])
                        lo = mid + 1;
                    else
                        hi = mid - 1;
                }

                int newL = lo;
                P[i] = M[newL - 1];
                M[newL] = i;

                if (newL > L)
                    L = newL;
            }

            int[] S = new int[L];
            int k = M[L];

            for (int i = L - 1; i >= 0; i--)
            {
                S[i] = k + 1;
                k = P[k];
            }

            return S;
        }
    }
}
