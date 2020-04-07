using System;
using System.Collections.Generic;
using System.Linq;
/*
2. Дана коллекция List<T>, требуется подсчитать, сколько раз каждый элемент встречается в
данной коллекции.
а) для целых чисел;
б) *для обобщенной коллекции;
в)**используя Linq.
*/
namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args) 
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 5, 9, 2, 10};
             
            foreach (var item in list.Distinct())
            {
                Console.WriteLine(item + " - " + list.Where(x => x == item).Count() + " раз");
            } 
            Console.ReadLine();
        }
    }
}
