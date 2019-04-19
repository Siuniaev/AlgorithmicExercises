/*
Первая строка содержит количество предметов 1 ≤ n ≤ 10^3 и вместимость рюкзака 0 ≤ W ≤ 2*10^6.
Каждая из следующих n строк задаёт стоимость 0 ≤ ci ≤ 2*10^6 и объём 0 < wi ≤ 2*10^6 предмета (n, W, ci, wi — целые числа).
Выведите максимальную стоимость частей предметов (от каждого предмета можно отделить любую часть, стоимость и объём при этом пропорционально
уменьшатся), помещающихся в данный рюкзак, с точностью не менее трёх знаков после запятой.

Sample Input:
3 50
60 20
100 50
120 30
Sample Output:
180.000
*/
using System;
using System.Linq;

namespace Непрерывный_рюкзак
{
    class Program
    {
        public class Item
        {
            public double Price;
            public double Weight;
            public double PW;

            public Item(double price, double weight)
            {
                Price = price;
                Weight = weight;
                PW = weight != 0 ? price / weight : price;
            }
        }

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(input[0]);
            double Limit = Convert.ToDouble(input[1]);
            double BagWeight = 0;
            double BagCost = 0;

            Item[] items = new Item[n];
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split(' ');
                items[i] = new Item(price: Convert.ToDouble(input[0]), weight: Convert.ToDouble(input[1]));
            }

            Item[] sorted = items.Where(x => x.Price > 0).OrderByDescending(x => x.PW).ToArray();

            for (int i = 0; i < sorted.Length; i++)
            {
                if (BagWeight < Limit)
                {
                    Item it = sorted[i];
                    if (it.Price > 0)
                    {
                        if (BagWeight + it.Weight <= Limit)
                        {
                            BagWeight += it.Weight;
                            BagCost += it.Price;
                        }
                        else
                        {
                            if (it.Weight > 0)                            
                                BagCost += it.Price * ((Limit - BagWeight) / it.Weight);                            
                            else                            
                                BagCost += it.Price;
                            
                            break;
                        }
                    }
                }
                else
                    break;
            }

            string output = (int)BagCost == BagCost ? BagCost.ToString() + ".000" : String.Format("{0:0.###}", BagCost);

            Console.WriteLine(output);
            Console.Read();
        }
    }
}
