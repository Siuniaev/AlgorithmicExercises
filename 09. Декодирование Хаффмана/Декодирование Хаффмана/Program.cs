/*
Восстановите строку по её коду и беспрефиксному коду символов.
В первой строке входного файла заданы два целых числа k и l через пробел — количество различных букв, встречающихся в строке,
и размер получившейся закодированной строки, соответственно. В следующих k строках записаны коды букв в формате "letter: code".
Ни один код не является префиксом другого. Буквы могут быть перечислены в любом порядке.
В качестве букв могут встречаться лишь строчные буквы латинского алфавита; каждая из этих букв встречается в строке хотя бы один раз.
Наконец, в последней строке записана закодированная строка. Исходная строка и коды всех букв непусты.
Заданный код таков, что закодированная строка имеет минимальный возможный размер.

В первой строке выходного файла выведите строку s. Она должна состоять из строчных букв латинского алфавита.
Гарантируется, что длина правильного ответа не превосходит 10^4 символов.

Sample Input:
4 14
a: 0
b: 10
c: 110
d: 111
01001100100111

Sample Output:
abacabad
*/
using System;
using System.Collections.Generic;

namespace Декодирование_Хаффмана
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, char> dic = new Dictionary<string, char>(); //код - символ

            var input = Console.ReadLine().Split(' ');
            var a = int.Parse(input[0]);
            var b = int.Parse(input[1]);

            for (int i = 0; i < a; i++)
            {
                string[] values = Console.ReadLine().Replace(" ", "").Split(':');
                dic.Add(values[1], values[0][0]);
            }

            string s = Console.ReadLine();
            string result = "";

            while (!string.IsNullOrEmpty(s) && s.Length > 0)
            {
                int l = s.Length;

                for (int i = 1; i < l + 1; i++)
                {
                    if (dic.ContainsKey(s.Substring(0, i)))
                    {
                        result += dic[s.Substring(0, i)];
                        s = s.Remove(0, i);
                        break;
                    }
                }
            }

            Console.WriteLine(result);
            Console.Read();
        }
    }
}
