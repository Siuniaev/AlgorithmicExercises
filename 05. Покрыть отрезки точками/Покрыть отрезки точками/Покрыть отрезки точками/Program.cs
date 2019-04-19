/*
По данным n отрезкам необходимо найти множество точек минимального размера, для которого каждый из отрезков содержит хотя бы одну из точек.
В первой строке дано число 1 ≤ n ≤ 100 отрезков. Каждая из последующих n строк содержит по два числа 0 ≤ l ≤ r ≤ 10^9, задающих начало и конец отрезка.
Выведите оптимальное число m точек и сами m точек. Если таких множеств точек несколько, выведите любое из них.

Sample Input:
3
1 3
2 5
3 6
Sample Output:
1
3 
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Покрыть_отрезки_точками
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());            

            int[][] arrs = new int[n][];

            for (int i = 0; i < n; i++)
            {
                arrs[i] = new int[2];
                var inputStr = Console.ReadLine().Split(' ');
                arrs[i][0] = Convert.ToInt32(inputStr[0]);
                arrs[i][1] = Convert.ToInt32(inputStr[1]);
            }
            
            int[][] sorted = arrs.OrderBy(x => x[1]).ToArray();

            List<int> res = cover(sorted);

            Console.WriteLine(res.Count);            
            Console.WriteLine(string.Join(" ", res));            
        }

        public static List<int> cover(int[][] arr)
        {
            List<int> sb = new List<int>();

            int l = arr.Length;

            for (int i = 0; i < l; i++)
            {
                int point = arr[i][1];

                for (int j = i; j < l && point <= arr[j][1] && point >= arr[j][0]; j++)                
                    i = j;
                
                sb.Add(point);
            }
            return sb;
        }
    }
}
