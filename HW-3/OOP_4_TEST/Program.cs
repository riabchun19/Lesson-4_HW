using System; 
using System.Collections.Generic;
using System.Linq; 

namespace LambdaExpressions
{ 
    class Program
    {   // 3. *Дан фрагмент программы:
        // а) Свернуть обращение к OrderBy с использованием лямбда-выражения$ 
        // б) *Развернуть обращение к OrderBy с использованием делегата Func<KeyValuePair<string, int>, int>.

        static void Main()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
            {"four",4 },
            {"two",2 },
            { "one",1 },
            {"three",3 },
            };

            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });

            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            Console.ReadKey();
        }
    } 
}
