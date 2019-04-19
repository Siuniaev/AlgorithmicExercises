/*
Вычислите расстояние редактирования двух данных непустых строк длины не более 10^2, содержащих строчные буквы латинского алфавита.

Sample Input:
short
ports

Sample Output:
3
*/
using System;

namespace Расстояние_Левенштейна
{
    class Program
    {
        static void Main(string[] args)
        {
            string A = Console.ReadLine();
            string B = Console.ReadLine();

            Console.WriteLine(EditDistance(A, B));
            Console.Read();
        }

        public static int EditDistance(string a, string b)
        {
            if (a == b)
                return 0;

            int n = a.Length;
            int m = b.Length;

            if (n == 0)
                return m;

            if (m == 0)
                return n;

            int[,] D = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++)
                D[i, 0] = i;

            for (int i = 0; i <= m; i++)
                D[0, i] = i;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = b[j - 1] == a[i - 1] ? 0 : 1;

                    D[i, j] = Math.Min(D[i - 1, j] + 1, Math.Min(D[i, j - 1] + 1, D[i - 1, j - 1] + cost));                    
                }
            }

            return D[n, m];
        }
    }
}
