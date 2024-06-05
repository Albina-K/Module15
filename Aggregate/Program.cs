using System;
using System.Linq;

namespace Aggregate
{// С помощью этого метода можно выполнить, к примеру, выполнение арифметического действия с элементами коллекции.
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            int result = numbers.Aggregate((x, y) => x - y);

            // вычислит 1-2-3-4-5 = -13
            Console.WriteLine(result);

            int sum = numbers.Aggregate((y, x) => y + x);
        }

            static long Factorial(int number)
        {
            // Коллекция для хранения чисел
            var numbers = new List<int>();

            // Добавляем все числа от 1 до n в коллекцию
            for (int i = 1; i <= number; i++)
                numbers.Add(i);
            
            // Выполняем агрегацию
            return numbers.Aggregate((y, x) => y * x);
        }

    }
}

