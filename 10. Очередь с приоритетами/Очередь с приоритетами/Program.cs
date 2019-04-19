/*
Первая строка входа содержит число операций 1 ≤ n ≤ 10^5. 
Каждая из последующих n строк задают операцию одного из следующих двух типов:
Insert x, где 0 ≤ x ≤ 10^9 — целое число;
ExtractMax.
Первая операция добавляет число x в очередь с приоритетами, вторая — извлекает максимальное число и выводит его.

Sample Input:
6
Insert 200
Insert 10
ExtractMax
Insert 5
Insert 500
ExtractMax

Sample Output:
200
500
*/
using System;
using System.Collections.Generic;

namespace Очередь_с_приоритетами
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Com> commands = new List<Com>();

            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                commands.Add(new Com(input));
            }

            Heap heap = new Heap();

            foreach (Com com in commands)            
                heap.RunCommand(com);

            Console.Read();
        }

        public class Heap
        {
            private List<int> heap;

            //просеивание вниз
            private void ShiftDown(int i)
            {
                while (2 * i < heap.Count)
                {
                    int max = i;

                    if (heap[2 * i] > heap[max])
                        max = 2 * i;

                    if (2 * i + 1 < heap.Count && heap[2 * i + 1] > heap[max])
                        max = 2 * i + 1;

                    if (max == i)
                        break;
                    
                    int temp = heap[i];
                    heap[i] = heap[max];
                    heap[max] = temp;
                    i = max;
                }
            }

            //просеивание вверх
            private void ShiftUp(int i)
            {
                while (i > 0 && heap[i / 2] < heap[i])
                {                    
                    int temp = heap[i];
                    heap[i] = heap[i / 2];
                    heap[i / 2] = temp;
                    i = i / 2;
                }
            }

            public void Insert(int x)
            {
                if (heap == null)
                    heap = new List<int>();

                heap.Add(x);
                ShiftUp(heap.Count - 1);
            }

            public void ExtractMax()
            {
                int x = heap[0];
                heap[0] = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);
                ShiftDown(0);

                Console.WriteLine(x.ToString());
            }

            public void RunCommand(Com com)
            {
                switch (com.Command)
                {
                    case "Insert":
                        Insert(com.Number);
                        break;
                    case "ExtractMax":
                        ExtractMax();
                        break;
                }
            }
        }

        public class Com
        {
            public string Command;
            public int Number;

            public Com(string[] s)
            {
                Command = s[0];

                if (s.Length > 1)
                    Number = Convert.ToInt32(s[1]);
            }
        }
    }
}
