using System;
using System.Linq;

namespace Union
{//Соединить две коллекции в одну возможно с помощью метода Union().
    class Program
    {
        static void Main(string[] args)
        {
            string[] cars = { "Волга", "Москвич", "Москвич", "Нива", "Газель" };
            string[] buses = { "Газель", "Икарус", "ЛиАЗ" };

            var vehicles = cars.Union(buses);

            foreach (string v in vehicles)
                Console.WriteLine(v);

            //Если нам нужно просто прибавить элементы одной коллекции к другой, не заботясь о дублировании,
            //есть метод Concat():
            // объединяет с дубликатами
            var vehicles2 = cars.Concat(buses);

            // Также мы можем проверить коллекцию на наличие дубликатов
            // и удалить их с помощью метода Distinct():
            string[] cars2 = { "Волга", "Москвич", "Москвич", "Нива", "Газель" };

            //удалим дубликаты
            var uniqueCars = cars.Distinct();
             foreach (string v in uniqueCars)
                Console.WriteLine(v);

           // Кстати, последовательно вызвав cars.Concat(buses).Distinct();,
           // мы получим результат, идентичный cars.Union(buses).
        }
    }
}