using System;
using System.Linq;

namespace Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var simpleNumbers = new[] { 3, 5, 7 };
            Console.WriteLine(simpleNumbers.Sum());

            // Список студентов
            var students = new List<Student>
            {
                new Student {Name="Андрей", Age=23 },
                new Student {Name="Сергей", Age=27 },
                new Student {Name="Дмитрий", Age=29 }
            };

                // сумма возрастов всех студентов
                var totalAge = students.Sum(s => s.Age);

            //Вернет 79
            Console.WriteLine(totalAge);
        }
        //Напишите метод, возвращающий среднее арифметическое числовых объектов коллекции.
        static double Average(int[] numbers)
        {
            // если делить два целых числа, которые не делятся без остатка, при делении остаток будет отброшен
            // чтобы этого не случилось, нужно привести одно из чисел к типу double
            return numbers.Sum() / (double)numbers.Length;
        }
    }
}
