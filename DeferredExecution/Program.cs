using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace DeferredExecution
{//Отложенное выполнение
    class Program
    {
        // При необходимости можно на ходу выполнить дополнительные операции:
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student {Name="Андрей", Age=23 },
                new Student {Name="Сергей", Age=27 },
                new Student {Name="Дмитрий", Age=29 }
            };

            var youngStudents = from s in students where s.Age < 25 select s;

           // Запрос, написанный выше, будет выполнен,
           // лишь когда мы обратимся к результатам нашей выборки,
           // например в цикле: 
           foreach (var stud in youngStudents)
                Console.WriteLine(stud.Name);

            // Стадии выполнения LINQ - запроса можно условно разделить так:
            // Получение источника данных(инициализация коллекции, в нашем случае списка студентов).
            // Создание запроса(определение переменной youngStudents).
            // Выполнение и получение результата(при обращении к переменной в цикле).

            //Источник данных (здесь — список студентов)
            //до выполнения запроса может менять несколько раз.
            //Это можно наглядно увидеть,
            //если попробовать изменить какой-либо из элементов до обращения к выборке: 
           
            var students2 = new List<Student>
            {
                new Student {Name="Андрей", Age=23 },
                new Student {Name="Сергей", Age=27 },
                new Student {Name="Дмитрий", Age=29 }
            };

            var youngStudents2 = from s in students where s.Age < 25 select s;

            // Добавим нового студента уже после инициализанции LINQ-запроса
            students.Add(new Student { Name = "Анна", Age = 21 });

            foreach (var stud in youngStudents)
                Console.WriteLine(stud.Name);

            //вывод
            //Андрей
            //Анна

            // Если бы запрос тут выполнился сразу после инициализации, новый студент бы в выборку не попал.

            //Важно зафиксировать,
            //что сама переменная запроса — youngStudents — не выполняет никаких действий.
            //Она просто хранит сам запрос.
        }
    }
}
