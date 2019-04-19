/*
В первой строке задано два целых числа 1 ≤ n ≤ 50000 и 1 ≤ m ≤ 50000 — количество отрезков и точек на прямой, соответственно.
Следующие n строк содержат по два целых числа ai и bi (ai ≤ bi) — координаты концов отрезков.
Последняя строка содержит m целых чисел — координаты точек. Все координаты не превышают 10^8 по модулю.
Точка считается принадлежащей отрезку, если она находится внутри него или на границе.
Для каждой точки в порядке появления во вводе выведите, скольким отрезкам она принадлежит.

Sample Input:
2 3
0 5
7 10
1 6 11

Sample Output:
1 0 0
*/
using System;
using System.Collections.Generic;

namespace Точки_и_отрезки
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int vectorsCount = Convert.ToInt32(input[0]);
            int dotsCount = Convert.ToInt32(input[1]);

            int[] arrA = new int[vectorsCount]; //точки начал отрезков
            int[] arrB = new int[vectorsCount]; //точки концов отрезков

            for (int i = 0; i < vectorsCount; i++)
            {
                string[] inputVector = Console.ReadLine().Split(' ');
                arrA[i] = Convert.ToInt32(inputVector[0]);
                arrB[i] = Convert.ToInt32(inputVector[1]);
            }

            int[] dots = new int[dotsCount]; //точки, которые ищем на отрезках

            string[] inputDots = Console.ReadLine().Split(' ');

            for (int i = 0; i < dotsCount; i++)
                dots[i] = Convert.ToInt32(inputDots[i]);

            QuickSort(arrA, 0, arrA.Length - 1);
            QuickSort(arrB, 0, arrB.Length - 1);

            List<int> results = new List<int>();

            foreach (int dot in dots)
            {
                int result = 0;

                int a = BinarySearchA(arrA, dot);

                if (a != -1)
                    result += a;
                else
                    result += vectorsCount;

                int b = BinarySearchB(arrB, dot);

                if (b != -1)
                    result -= b + 1;                

                results.Add(result);
            }

            Console.WriteLine(string.Join(" ", results));
            Console.Read();
        }        

        private static void QuickSort(int[] a, int i, int j)
        {
            if (i < j)
            {
                int m = Partition(a, i, j);
                QuickSort(a, i, m);
                QuickSort(a, m + 1, j);
            }
        }

        private static int Partition(int[] a, int l, int r)
        {
            int x = a[l];
            int m1 = l - 1;
            int m2 = r + 1;

            while (true)
            {
                do m2--;                
                while (a[m2] > x);

                do m1++;                
                while (a[m1] < x);

                if (m1 < m2)
                {
                    int tmp = a[m1];
                    a[m1] = a[m2];
                    a[m2] = tmp;
                }
                else
                    return m2;                
            }
        }

        //бинарный поиск в массиве крайнего лекого индекса, где точка будет >= числу под индексом
        public static int BinarySearchA(int[] arr, int dot)
        {
            int min = 0;
            int max = arr.Length - 1;
            int old = -1;

            while (min <= max)
            {
                int mid = (min + max) / 2;

                if (dot < arr[mid])
                {
                    old = mid;
                    max = mid - 1;
                }
                else
                    min = mid + 1;
            }
            return old;
        }

        //бинарный поиск в массиве крайнего правого индекса, где точка будет > числа под индексом
        public static int BinarySearchB(int[] arr, int dot)
        {
            int min = 0;
            int max = arr.Length - 1;
            int old = -1;

            while (min <= max)
            {
                int mid = (min + max) / 2;

                if (dot > arr[mid])
                {
                    old = mid;
                    min = mid + 1;
                }
                else
                    max = mid - 1;
            }
            return old;
        }
    }
}
