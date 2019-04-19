/*
Даны число 1 ≤ n ≤ 10^2 ступенек лестницы и целые числа −10^4 ≤ a1, … ,an ≤ 10^4, которыми помечены ступеньки.
Найдите максимальную сумму, которую можно получить, идя по лестнице снизу вверх (от нулевой до n-й ступеньки),
каждый раз поднимаясь на одну или две ступеньки.

Sample Input 1:
3
-1 2 1

Sample Output 1:
3

Sample Input 2:
5
-64 -16 -13 -9 -48

Sample Output 2:
-73
*/
using System;

namespace лестница
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine()); //количество ступеней
            string[] input = Console.ReadLine().Split(' '); //цены ступеней

            int[] A = new int[N + 1];
            for (int i = 1; i < N + 1; i++)
                A[i] = int.Parse(input[i - 1]);

            int Max = FindMax(N, A);

            Console.WriteLine(Max);
            Console.Read();
        }

        static int FindMax(int N, int[] A)
        {
            if (N == 1) return A[1];

            int[,] D = new int[N + 1, 3];

            for (int i = 0; i < N + 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 0)
                        D[i, j] = A[j];
                    else if (j == 0)
                    {
                        if (i == 1)
                            D[i, j] = D[i - 1, j + 1];
                        else
                            D[i, j] = Math.Max(D[i - 1, j + 1], D[i - 2, j + 2]);
                    }
                    else if (i + j < N + 1)
                        D[i, j] = D[i, 0] + A[i + j];
                }
            }

            return D[N, 0];
        }
    }
}
