/*
У вас есть примитивный калькулятор, который умеет выполнять всего три операции с текущим числом x: заменить x на 2x, 3x или x+1.
По данному целому числу 1 ≤ n ≤ 10^5 определите минимальное число операций k, необходимое, чтобы получить n из 1.
Выведите k и последовательность промежуточных чисел.

Sample Input 1:
5

Sample Output 1:
3
1 2 4 5 

Sample Input 2:
96234

Sample Output 2:
14
1 3 9 10 11 22 66 198 594 1782 5346 16038 16039 32078 96234
*/
using System;

namespace калькулятор
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());

            int[] Result = FindMinSteps(N);

            Console.WriteLine(Result.Length - 1);
            Console.WriteLine(string.Join(" ", Result));
            Console.Read();
        }

        static int[] FindMinSteps(int N)
        {
            if (N == 0 || N == 1)
                return new int[] { 1 };

            int[] A = new int[N]; //масисв чисел от 1 до N включительно
            int[] D = new int[N]; //массив минимальных шагов, которыми можно прийти в каждое число

            for (int i = 0; i < N; i++)
            {
                A[i] = i + 1;
                D[i] = N; //по умолчанию везде кол-во шагов - большое число
            }
            D[0] = 0;

            int temp;
            for (int i = 0; i < N - 1; i++)
            {
                int step = D[i] + 1;

                temp = A[i] + 1;
                if (temp <= N && step < D[temp - 1])
                    D[temp - 1] = step;

                temp = A[i] * 2;
                if (temp <= N && step < D[temp - 1])
                    D[temp - 1] = step;

                temp = A[i] * 3;
                if (temp <= N && step < D[temp - 1])
                    D[temp - 1] = step;
            }

            int[] R = new int[D[N - 1] + 1];
            int m = R.Length - 1;

            int m2 = N - 1;

            while (m > 0)
            {
                R[m] = A[m2];

                int k = D[m2];
                while (D[m2] >= k || (A[m2] + 1 != R[m] && A[m2] * 2 != R[m] && A[m2] * 3 != R[m]))
                {
                    m2--;
                }

                m--;
            }

            R[0] = 1;

            return R;
        }
    }
}
