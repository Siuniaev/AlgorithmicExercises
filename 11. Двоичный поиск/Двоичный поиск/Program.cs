/*
В первой строке даны целое число 1 ≤ n ≤ 10^5 и массив A[1…n] из n различных натуральных чисел, не превышающих 10^9, в порядке возрастания,
во второй — целое число 1 ≤ k ≤ 10^5 и k натуральных чисел b1,…,bk, не превышающих 10^9.
Для каждого i от 1 до k необходимо вывести индекс 1 ≤ j ≤ n, для которого A[j] = bi, или −1, если такого j нет.

Sample Input:
5 1 5 8 12 13
5 8 1 23 1 11

Sample Output:
3 1 -1 1 -1
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Двоичный_поиск
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayA = Console.ReadLine().Split(' ').Select(int.Parse).Skip(1).ToArray();
            int[] arrayB = Console.ReadLine().Split(' ').Select(int.Parse).Skip(1).ToArray();            

            List<int> results = new List<int>();

            foreach (int a in arrayB)
                results.Add(BinarySearch(arrayA, a));

            Console.WriteLine(String.Join(" ", results));
            Console.Read();
        }

        public static int BinarySearch(int[] arr, int a)
        {
            int l = 0;
            int r = arr.Length - 1;

            while (l <= r)
            {
                int m = (l + r) / 2;

                if (arr[m] == a)
                    return ++m;
                else if (arr[m] > a)
                    r = --m;
                else
                    l = ++m;
            }

            return -1;
        }
    }
}
