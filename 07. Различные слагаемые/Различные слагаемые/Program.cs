/*
По данному числу 1 ≤ n ≤ 10^9 найдите максимальное число k, для которого n можно представить как сумму k различных натуральных слагаемых.
Выведите в первой строке число k, во второй — k слагаемых.

Sample Input:
6
Sample Output:
3
1 2 3 
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Различные_слагаемые
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<int> nums = new HashSet<int>();
            int sum = 0;

            for (int i = 1; i <= n && sum != n; i++)
            {
                int d = n - sum;

                if (i > d)
                {
                    int r = i - d;
                    sum -= r;
                    nums.Remove(r);
                }
                sum += i;
                nums.Add(i);
            }

            Console.WriteLine(nums.Count);
            Console.WriteLine(string.Join(" ", nums.ToList()));
        }
    }
}
