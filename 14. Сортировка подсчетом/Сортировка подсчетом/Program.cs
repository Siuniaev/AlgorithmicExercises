/*
Первая строка содержит число 1 ≤ n ≤ 10^4, вторая — n натуральных чисел, не превышающих 10.
Выведите упорядоченную по неубыванию последовательность этих чисел.

Sample Input:
5
2 3 9 2 9

Sample Output:
2 2 3 9 9
*/
using System;
using System.Linq;

namespace Сортировка_подсчетом
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Sort(arr);

            Console.WriteLine(string.Join(" ", arr));
            Console.Read();
        }

        public static void Sort(int[] arr)
        {
            int[] B = new int[11];

            for (int i = 0; i < arr.Length; i++)
                B[arr[i]]++;

            int m = 0;

            for (int i = 0; i < B.Length; i++)
            {
                while (B[i] > 0)
                {
                    arr[m] = i;
                    B[i]--;
                    m++;
                }
            }
        }
    }
}
