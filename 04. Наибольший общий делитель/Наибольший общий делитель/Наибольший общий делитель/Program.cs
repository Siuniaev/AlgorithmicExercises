/*
По данным двум числам 1 ≤ a,b ≤ 2*10^9 найдите их наибольший общий делитель.

Sample Input 1:
18 35
Sample Output 1:
1

Sample Input 2:
14159572 63967072
Sample Output 2:
4
*/

using System;

namespace Наибольший_общий_делитель
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var a = ulong.Parse(input[0]);
            var b = ulong.Parse(input[1]);

            Console.WriteLine(les2(a, b));
        }

        static ulong les2(ulong a, ulong b)
        {
            if (a == 0)
                return b;

            if (b == 0)
                return a;
            
            if (a > b)
                return les2(a % b, b);
            else
                return les2(a, b % a);
        }
    }
}
