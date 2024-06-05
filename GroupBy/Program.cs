using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>()
            {
                new Car("Suzuki", "JP"),
                new Car("Toyota", "JP"),
                new Car("Opel", "DE"),
                new Car("Kamaz", "RUS"),
                new Car("Lada", "RUS"),
                new Car("Honda", "JP"),
            };
            //Сгруппируем их по стране-производителю(используя ключевое слово groupby):
            // Группировка по стране - производителю
            var carsByCountry = from car in cars
                                group car by car.CountryCode;
            // Пробежимся по группам
            foreach (var grouping in carsByCountry )
            {
                Console.WriteLine(grouping.Key + ":");

                // внутри каждой группы пробежимся по элементам
                foreach (var car in grouping)
                    Console.WriteLine(car.Manufacturer);

                Console.WriteLine();
            }

            //Каждая группа представляет объект IGrouping<string, Car>,
            //где string — тип ключа, а параметр Car — тип сгруппированных объектов.
            //Ключ каждой группы доступен через свойство Key.


           // Через метод расширения тот же результат достигается в одну строчку: 
           // Группировка по стране - производителю ( через метод - расширение)
           var carsByCountry2 = cars.GroupBy(c => c.CountryCode);

           // При группировке мы можем использовать уже известную вам проекцию для создания объекта нового типа: 
           var carsByCountry3 = cars
                .GroupBy(car => car.CountryCode)// группируем по стране-производителю
                .Select(group => new
                {//  создаем новую сущность анонимного типа
                    Name = group.Key,
                    Amount = group.Count()
                });
            //И даже осуществлять вложенные запросы, используя ключевое слово into.
            var carsByCountry4 = from car in cars
                                 group car by car.CountryCode into grouping
                                 select new
                                 {
                                     Name = grouping.Key,
                                     Count = grouping.Count(),
                                     Cars = from p in grouping select p
                                 };
            foreach (var group in  carsByCountry4 )
            {
                Console.WriteLine($"{group.Name} : {group.Count} авто");

                foreach (Car car in group.Cars)
                    Console.WriteLine(car.Manufacturer);
            }

            // Аналогичный запрос с помощью метода расширения, как всегда, выглядит менее громоздким:
            var carsByCountry5 = cars
                 .GroupBy(c => c.CountryCode)
                 .Select(group => new
                 {
                     Name = group.Key,
                     Count = group.Count(),
                     Cars = group.Select(car => car)
                 });            
        }

        static void Main5(string[] args )
        {
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", 799900000013, "serg@gmail.com"));
            phoneBook.Add(new Contact("Иннокентий", 799900000013, "innokentii@example.com"));

            //  в качестве критерия группировки передаем домен адреса электронной почты
            var grouped = phoneBook.GroupBy(c => c.Email.Split("@").Last());

            // обрабатываем получившиеся группы
            foreach (var group in grouped )
            {
                // если ключ содержит example, значит, это фейк
                if(group.Key.Contains("example"))
                {
                    Console.WriteLine("Фейковые адреса: ");

                    foreach (var contact in group)
                        Console.WriteLine(contact.Name + " " + contact.Email);
                }
                else
                {
                    Console.WriteLine("Реальные адреса: ");
                    foreach (var contact in group)
                        Console.WriteLine(contact.Name + " " + contact.Email);
                }
            }
        }    
    }
}
