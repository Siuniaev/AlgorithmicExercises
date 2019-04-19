/*
Первая строка входа содержит целые числа 1 ≤ W ≤ 10^4 и 1 ≤ n ≤ 300 — вместимость рюкзака и число золотых слитков.
Следующая строка содержит n целых чисел 0 ≤ w1, … , wn ≤ 10^5, задающих веса слитков.
Найдите максимальный вес золота, который можно унести в рюкзаке.

Sample Input:
10 3
1 4 8

Sample Output:
9
*/
using System;
using System.Linq;

namespace рюкзак
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            int W = Convert.ToInt32(input[0]); //вместимость рюкзака
            int N = Convert.ToInt32(input[1]); //число слитков

            int[] pieces = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int wMax = FindMaxWeight(W, N, pieces);

            Console.WriteLine(wMax);
            Console.Read();
        }

        static int FindMaxWeight(int W, int N, int[] a)
        {
            if (W < 1) return 0;

            int[][] A = new int[N + 1][];

            for (int i = 0; i < N + 1; i++)
                A[i] = new int[W + 1];

            for (int i = 1; i < N + 1; i++)
            {
                for (int j = 1; j < W + 1; j++)
                {
                    if (j >= a[i - 1])
                        A[i][j] = Math.Max(A[i - 1][j - a[i - 1]] + a[i - 1], A[i - 1][j]);
                    else
                        A[i][j] = A[i - 1][j];
                }
            }

            return A[N][W];
        }
    }
}
