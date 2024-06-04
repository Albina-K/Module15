using System;
using System.Linq;

namespace Except
{
    class Program
    {
        static void Main(string[] args)
        {
            //Бывает необходимо исключить из одной коллекции то, что содержится в другой.
            //Для этого служит метод Except():

           // Важно! Метод Except() возвращает только уникальные элементы.

            // Список напитков в продаже
            string[] drinks = { "Вода", "Кока-кола", "Лимонад", "Вино" };

            // Алкогольные напитки
            string[] alcohol = { "Вино", "Пиво", "Сидр" };
            
            // Убираем алкоголь из ассортимента
            var drinksForKids = drinks.Except(alcohol);

            foreach (string drink in drinksForKids)
                Console.WriteLine(drink);
        }
        static void Main3(string[] args)
        {
            // читаем ввод
            var text = Console.ReadLine();
            // сохраняем список знаков препинания и символ пробела в коллекцию
            var punctuation = new List<char>() { ',', '.', ';', ':', '?', '!', ' ' };
            // валидация ввода
            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("Вы ввели пустой текст");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Текст без знаков препинания: ");

            // так как строка - это массив char, мы можем вызвать метод  except  и удалить знаки препинания
            var word = text.Except(punctuation).ToArray();

        }
    }
}
