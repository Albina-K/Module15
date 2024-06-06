using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace GroupJoin
{//Позволяет одновременно с тем, что мы делали выше (соединение последовательностей), произвести группировку.
    class Program
    {
        static void Main(string[] args)
        {
            // Список моделей
            var cars = new List<Car>()
            {
                new Car() { Model  = "SX4", Manufacturer = "Suzuki"},
                new Car() { Model  = "Grand Vitara", Manufacturer = "Suzuki"},
                new Car() { Model  = "Jimny", Manufacturer = "Suzuki"},
                new Car() { Model  = "Land Cruiser Prado", Manufacturer = "Toyota"},
                new Car() { Model  = "Camry", Manufacturer = "Toyota"},
                new Car() { Model  = "Polo", Manufacturer = "Volkswagen"},
                new Car() { Model  = "Passat", Manufacturer = "Volkswagen"},
            };

            // Список автопроизводителей
            var manufacturers = new List<Manufacturer>()
            {
                new Manufacturer() { Country = "Japan", Name = "Suzuki" },
                new Manufacturer() { Country = "Japan", Name = "Toyota" },
                new Manufacturer() { Country = "Germany", Name = "Volkswagen" },
            };
            // Выборка + группировка
            var result2 = manufacturers.GroupJoin(cars,// первый набор данных
                m => m.Name,// общее свойство второго набора
                car => car.Manufacturer,// общее свойство первого набора
                (m, crs) => new// результат выборки
                {
                    Name = m.Name,
                    Country = m.Country,
                    Cars = crs.Select(c =>c.Model)
                });
            // Вывод:
            foreach (var team in result2)//сначала проходимся по ключам
            {
                Console.WriteLine(team.Name + ":");
                foreach (string car in team.Cars)//потом по элементам внутри значений
                    Console.WriteLine(car);
                Console.WriteLine();
            }
        }
        //Теперь сгруппируйте сотрудников по отделам,
        //выведя на экран последовательно сначала название отдела,
        //а затем список его сотрудников:
        static void Main2(string[] args)
        { 
            var departments = new List<Department>()
            {
                new Department() {Id = 1, Name = "Программирование"},
                new Department() {Id = 2, Name = "Продажи"}
            };

            var employees = new List<Employee>()
            {
                new Employee() { DepartmentId = 1, Name = "Инна", Id = 1},
                new Employee() { DepartmentId = 1, Name = "Андрей", Id = 2},
                new Employee() { DepartmentId = 2, Name = "Виктор ", Id = 3},
                new Employee() { DepartmentId = 3, Name = "Альберт ", Id = 4},
            };

            var result2 = departments.GroupJoin(
                employees,// первый набор данных
                 dep => dep.Id,// общее свойство второго набора
                 em => em.DepartmentId,// общее свойство первого набора
                (dep, emps) => new// результат выборки
                {
                    Name = dep.Name,
                    Employees = emps.Select(e => e.Name),                    
                });
            // Вывод:
            foreach (var dep in result2)//сначала проходимся по отделам
            {
                Console.WriteLine(dep.Name + ":");
                foreach (string emp in dep.Employees)// Выводим сотрудников
                    Console.WriteLine(emp);
                Console.WriteLine();
            }
        }
    }
        
    // Модель автомобиля
    public class Car
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
    }
    // Завод - изготовитель
    public class Manufacturer
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

}
