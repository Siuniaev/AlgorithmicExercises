/*
Первая строка содержит число 1 ≤ n ≤ 10^5, вторая — массив A[1…n], содержащий натуральные числа, не превосходящие 10^9.
Необходимо посчитать число пар индексов 1 ≤ i < j ≤ n, для которых A[i] > A[j]. 
Такая пара элементов называется инверсией массива. Количество инверсий в массиве является в некотором смысле его мерой неупорядоченности:
например, в упорядоченном по неубыванию массиве инверсий нет вообще, а в массиве, упорядоченном по убыванию, инверсию образуют каждые два элемента.

Sample Input:
5
2 3 9 2 9

Sample Output:
2
*/
using System;
using System.Linq;

namespace Число_инверсий
{
    class Program
    {
        static long result = 0;

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            long[] array = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            long[] mergedArr = MergeFind(array);

            Console.WriteLine(result);
            Console.Read();
        }

        static long[] MergeFind(long[] arr)
        {
            if (arr.Length == 1) return arr;

            int m = arr.Length / 2;
            return Merge(MergeFind(arr.Take(m).ToArray()), MergeFind(arr.Skip(m).ToArray()));
        }

        static long[] Merge(long[] arr1, long[] arr2)
        {
            int ptr1 = 0, ptr2 = 0;
            long[] merged = new long[arr1.Length + arr2.Length];

            for (int i = 0; i < merged.Length; i++)
            {
                if (ptr1 < arr1.Length && ptr2 < arr2.Length)
                {
                    if (arr1[ptr1] > arr2[ptr2])
                    {
                        result++;

                        //если не последний элемент левого массива оказался больше элемента из правого, то остальные элементы этого массива тоже будут больше
                        if (ptr1 != arr1.Length - 1) 
                            result += arr1.Length - 1 - ptr1;

                        merged[i] = arr2[ptr2++];
                    }
                    else
                        merged[i] = arr1[ptr1++];
                }
                else
                {
                    if (ptr1 < arr1.Length)
                        merged[i] = arr1[ptr1++];
                    else
                        merged[i] = arr2[ptr2++];
                }
            }

            return merged;
        }        
    }
}
