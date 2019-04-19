/*
Дано целое число 1≤n≤40, необходимо вычислить n-е число Фибоначчи(напомним, что F0 = 0, F1= 1 и Fn = Fn−1 + Fn−2 при n≥2).

Sample Input:
3
Sample Output:
2
*/

using System;

namespace Небольшое_число_Фибоначчи
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            if (n >= 2)
            {
                int[] fibNumbers = new int[n + 1];

                fibNumbers[0] = 0;
                fibNumbers[1] = 1;

                for (int i = 2; i < n + 1; i++)                
                    fibNumbers[i] = fibNumbers[i - 1] + fibNumbers[i - 2];                

                Console.WriteLine(fibNumbers[n].ToString());
            }
            else            
                Console.WriteLine("1");            
        }
    }
}
