using System;
using System.Linq;

namespace МaxMinAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new[] { 1, 7, 45, 23 };
            int greatest = nums.Max();
            int smallest = nums.Min();
            double average = nums.Average();

            var students = new List<Student>
            {
                new Student {Name="Андрей", Age=23 },
                new Student {Name="Сергей", Age=27 },
                new Student {Name="Дмитрий", Age=29 }
            };
            // найдем возраст самого старого студента ( 29 )
            var oldest = students.Max(s => s.Age);

            // самого молодого ( 23 )
            var youngest = students.Min(s => s.Age);

            //  и средний возраст ( 26,3 )
            var average2 = students.Average(s => s.Age);
        }
        //Напишите программу с бесконечным циклом,  которая будет
        //ожидать ввода числа с клавиатуры(используйте Console.ReadLine());
        //добавлять число в список, хранящийся в памяти;
        //выводить после добавления следующую информацию:
        //оличество чисел в списке, сумму всех чисел списка,
        //аибольшее и наименьшее числа, а также их среднее значение.

        //   статическая переменная для хранения данных в памяти
        public static List<int> Numbers = new List<int>();
        static void Main3(string[] args)
        {
            while (true)
            {
                // Читаем введенный с консоли  текст
                var input = Console.ReadLine();

                // проверяем, число ли это
                var isInteger = Int32.TryParse(input, out int inputNum);

                // если не число - показываем ошибку
                if (!isInteger)
                {
                    Console.WriteLine();
                    Console.WriteLine("Вы ввели не число");
                }
                // если соответствует, запускаем обработчик
                else
                {
                    // добавляем в список
                    Numbers.Add(inputNum);

                    // выводим все критерии
                    Console.WriteLine("Число " + input + " добавлено в список.");
                    Console.WriteLine($"Всего в списке  {Numbers.Count}  чисел");
                    Console.WriteLine($"Сумма:  {Numbers.Sum()}");
                    Console.WriteLine($"Наибольшее:  {Numbers.Max()}");
                    Console.WriteLine($"Наименьшее:  {Numbers.Min()}"); 
                    Console.WriteLine($"Среднее:  {Numbers.Average()}");
                    Console.WriteLine();
                }
            }
        }
    }
}
