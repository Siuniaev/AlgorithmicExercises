/*
По данной непустой строке s длины не более 10^4, состоящей из строчных букв латинского алфавита, постройте оптимальный беспрефиксный код.
В первой строке выведите количество различных букв k, встречающихся в строке, и размер получившейся закодированной строки.
В следующих k строках запишите коды букв в формате "letter: code". В последней строке выведите закодированную строку.

Sample Input:
abacabad

Sample Output:
4 14
a: 0
b: 10
c: 110
d: 111
01001100100111
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Кодирование_Хаффмана
{
    class Program
    {
        //символ - его новое представление строкой
        public static Dictionary<char, List<bool>> dicConverted = new Dictionary<char, List<bool>>(); 

        static void Main(string[] args)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>(); //символ - его частота
            List<Node> nodes = new List<Node>(); //дерево
            Node Root = null; //корневая нода

            string s = Console.ReadLine();

            for (int i = 0; i < s.Length; i++)
            {
                if (!dic.ContainsKey(s[i])) dic.Add(s[i], 0);
                    dic[s[i]]++;
            }

            foreach (KeyValuePair<char, int> kvp in dic)            
                nodes.Add(new Node() { Symbol = kvp.Key, Number = kvp.Value });            

            if (nodes.Count == 1)
                Root = nodes[0];

            while (nodes.Count > 1)
            {
                List<Node> sorted = nodes.OrderBy(x => x.Number).ToList();

                if (sorted.Count >= 2)
                {
                    List<Node> taken = sorted.Take(2).ToList(); //берем две ноды с минимальным числом

                    Node parent = new Node()
                    {
                        Symbol = '*',
                        Number = taken[0].Number + taken[1].Number,
                        Left = taken[0],
                        Right = taken[1]
                    };

                    nodes.Remove(taken[0]);
                    nodes.Remove(taken[1]);
                    nodes.Add(parent);
                }

                Root = nodes.FirstOrDefault();
            }

            //дерево собрано (ссылки на вершины хранятся только в вершинах)

            List<bool> resultList = new List<bool>(); //результат конвертации строки

            for (int i = 0; i < s.Length; i++)
            {
                List<bool> encoded = Root.ConvertToBits(s[i], new List<bool>());
                resultList.AddRange(encoded);
            }

            Console.WriteLine(dic.Count + " " + resultList.Count);

            foreach (KeyValuePair<char, List<bool>> kvp in dicConverted)
            {
                string boolstring = "";
                foreach (bool b in kvp.Value)                
                    boolstring += b ? "1" : "0";
                
                Console.WriteLine(kvp.Key + ": " + boolstring);
            }

            string result = "";
            foreach (bool b in resultList)            
                result += b ? "1" : "0";            

            Console.WriteLine(result);
            Console.Read();
        }

        public class Node
        {
            public char Symbol;
            public int Number;
            public Node Right;
            public Node Left;

            public List<bool> ConvertToBits(char symbol, List<bool> data)
            {
                if (Right == null && Left == null) //значит лист дерева
                {
                    if (symbol.Equals(this.Symbol))
                    {
                        if (data.Count == 0)
                            data.Add(false); //исключение для одного листа в дереве

                        if (!dicConverted.ContainsKey(this.Symbol))
                            dicConverted.Add(this.Symbol, data);

                        return data;
                    }
                    else                    
                        return null;                    
                }
                else
                {
                    List<bool> left = null;
                    List<bool> right = null;

                    if (Left != null)
                    {
                        List<bool> leftPath = new List<bool>();
                        leftPath.AddRange(data);
                        leftPath.Add(false);

                        left = Left.ConvertToBits(symbol, leftPath);
                    }

                    if (Right != null)
                    {
                        List<bool> rightPath = new List<bool>();
                        rightPath.AddRange(data);
                        rightPath.Add(true);
                        right = Right.ConvertToBits(symbol, rightPath);
                    }

                    return left ?? right;                    
                }
            }
        }
    }
}
