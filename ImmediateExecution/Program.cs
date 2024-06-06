using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace ImmediateExecution
{//Немедленное выполнение
    class Program
    {
        // Некоторые методы всё же позволяют нам запустить выполнение запроса мгновенно.:

       // Например, это методы, которые возвращают из коллекции один элемент или одно какое-либо значение:
      
        // Count();
      
        // Average();
      
        // First() / FirstOrDefault();
      
        // Min();
      
        // Max().
        static void Main(string[] args)
        {
            // здесь запрос будет выполнен немедленно, и в переменную будет сохранено количество элементов выборки
            var youngStudents = (from s in students where s.Age < 25 select s).Count();

        // Ещё один способ запустить мгновенное выполнение LINQ - выражения —
        // сохранить результат выборки в новую коллекцию с помощью таких методов, как:

        // ToArray();

        // ToList();

        // ToHashSet() и т.д.

     //   Например:

            var youngStudents = students
               .Where(s => s.Age < 25) // на этом этапе происходит генерация LINQ-выражения
               .ToList(); // А вот тут уже будет выполнение

            //Напишите свой пример, который позволит узнать, приводит ли метод ToArray()
            //к мгновенному выполнению LINQ-запроса ?

            //  Подготовим тестовые данные
            var names = new List<string>() { "Вася", "Вова", "Петя", "Андрей" };

            //Подготовим тестовую выборку (без ToArray())
            var experiment = names.Where(name => name.StartsWith("B"));

            // уберем несколько элементов уже после выборки (если она выполняется отложено, то они в неё не попадут)
            names.Remove("Вася");
            names.Remove("Вова");

            // обратимся к выборке в цикле foreach
            foreach(var word in experiment)
                Console.WriteLine(word);


          //  Теперь эксперимент с ToArray():
          //  Снова возьмем те же тестовые данные
          var names = new List<string>() { "Вася", "Вова", "Петя", "Андрей" };

            // Теперь добавим ToArray() в конце того же самого LINQ-запроса
            var experiment = names.Where(name => name.StartsWith("В")).ToArray();

            // Также уберем несколько элементов
            names.Remove("Вася");
            names.Remove("Вова");

            // обратимся к выборку в цикле foreach
            foreach (var word in experiment)
                Console.WriteLine(word);
        }
    }
}

