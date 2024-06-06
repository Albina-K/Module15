using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace Zip
{//Данный метод позволяет попарно соединять последовательности. 
    class Program
    {
       // При необходимости можно на ходу выполнить дополнительные операции:
        static void Main(string[] args)
        {
            //  объявляем две коллекции
            var letters = new string[] { "A", "B", "C", "D", "E" };
            var numbers = new int[] { 1, 2, 3 };

            // проводим "упаковку" элементов, сопоставляя попарно
            var q = letters.Zip(numbers, (l, n) => l + n.ToString());

            // вывод
            foreach (var s in q)
                Console.WriteLine(s);
        }
    }
}
