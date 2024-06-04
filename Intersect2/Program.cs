using System;
using System.Linq;

namespace Intersect
{// Для нахождения общих элементов коллекций используйте Intersect():
    class Program
    {
        static void Main(string[] args)
        {
            string[] cars = { "Волга", "Москвич", "Нива", "Газель" };
            string[] buses = { "Газель", "Икарус", "ЛиАЗ" };

            // поищем машины, которые можно считать микроавтобусами
            var microBuses = cars.Intersect(buses);

            foreach (string mb in microBuses)
                Console.WriteLine(mb);
        }

            static void Main2(string[] args)
            {
                Console.WriteLine(CountCommon("one", "two"));
            }

            static int CountCommon(string word1, string word2)
            {
                var amount = word1.Intersect(word2)//   ищем пересечение
         .Count(); // считаем количество
                return amount;
            }
        
    }
}
    
