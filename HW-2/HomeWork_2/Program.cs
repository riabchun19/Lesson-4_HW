using System;
using System.Collections.Generic;
using System.Linq;
/*
2. Дана коллекция List<T>, требуется подсчитать, сколько раз каждый элемент встречается в
данной коллекции.
а) для целых чисел; - Готово.
б) *для обобщенной коллекции; - не зовсім поняв що треба тут робити(треба создать свой тип?).
в)**используя Linq. - в процесі
*/
namespace HomeWork2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var items = GenerateItems(100000000);
            
            // Твій варіант, тільки підігнаний під "Обобщённый" метод
            PrintResult(items,
                        inputData =>
                        {
                            var resultList = new List<KeyValuePair<int, int>>();
                            foreach (var item in inputData.Distinct())
                            {
                                resultList.Add(new KeyValuePair<int, int>(item, inputData.Count(x => x == item)));
                            }

                            return resultList;
                        });

            PrintResult(items, GetUniqueWithCount);

            PrintResult(items,
                        inputData =>
                            from x in items
                            group x by x into g
                            let count = g.Count()
                            select new KeyValuePair<int, int>(g.Key, g.Count()));

            PrintResult(items, inputData => inputData.GroupBy(x => x)
                                          .Select(g => new KeyValuePair<int, int>(g.Key, g.Count())));

            Console.ReadLine();
        }

        private static IDictionary<T, int> GetUniqueWithCount<T>(IEnumerable<T> items)
            => items.Aggregate(
                new Dictionary<T, int>(),
                (aggregate, item) =>
                {
                    if (aggregate.ContainsKey(item))
                        aggregate[item] += 1;
                    else
                        aggregate[item] = 1;
                    return aggregate;
                });

        private static int[] GenerateItems(int size)
        {
            var items = new int[size];
            var rnd = new Random();
            for (var i = 0; i < items.Length; i++)
            {
                items[i] = rnd.Next(1, 10);
            }

            return items;
        }

        private static void PrintResult<T>(IEnumerable<T> items, Func<IEnumerable<T>, IEnumerable<KeyValuePair<T, int>>> countUnique)
        {
            Console.WriteLine("------ Start processing ------");
            var checkpoint = DateTime.UtcNow;
            var result = countUnique(items);

            // Якщо розкоментувати ось цю строку, то можемо побачити, що LINQ на даному етапі ще не виконав свою операцію,
            // а тільки на наступному кроці, при переборі колекції
            //var elapsed = DateTime.UtcNow - checkpoint;
            foreach (var pair in result)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} repeats");
            }
            var elapsed = DateTime.UtcNow - checkpoint;
            Console.WriteLine("------ End processing ------");
            Console.WriteLine($"Elapsed: {elapsed:G}");
            Console.WriteLine();
        }
    }
}
