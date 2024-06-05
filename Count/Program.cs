using System;
using System.Linq;

namespace Count
{// Метод Count() можно использовать, когда вы хотите не просто посчитать элементы,
 // а  узнать, сколько из них удовлетворяют определенным критериям.
    class Program
    {
        static void Main(string[] args)
        {
            // получим тех кто младше 25
            var youngStudentsAmount =
                (from student in students
                 where student.Age < 25
                 select student).Count();

            // выведет 1
            Console.WriteLine(youngStudentsAmount);

            //Есть другой способ — использовать перегрузку метода Count(), принимающую на вход лямбда-выражение:
            var youngStudentAmount = students.Count(s => s.Age < 25);
        }

        static void Main2(string[] args)
        {
            var contacts = new List<Contact>()
            {
                new Contact() { Name = "Андрей", Phone = 79994500508 },
                new Contact() { Name = "Сергей", Phone = 799990455 },
                new Contact() { Name = "Иван", Phone = 79999675334 },
                new Contact() { Name = "Игорь", Phone = 8884994 },
                new Contact() { Name = "Анна", Phone = 665565656 },
                new Contact() { Name = "Василий", Phone = 3434 }
            };

            var invalidContacts = (from contact in contacts // пробегаемся по контактам
                                   let phoneString = contact.Phone.ToString() // сохраняем в промежуточную переменную строку номера телефона
                                   where !phoneString.StartWith('7') || !phoneString.Lenght != 11 // выполняем выборку по условиям
                                   select contact) // добавляем объект в выборку
                                   .Count(); // считаем количество объектов в выборке
        }
    }
}
