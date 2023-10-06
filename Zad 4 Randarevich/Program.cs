using System;
using System.Collections.Generic;
using System.Linq;

namespace DataFilteringSystem
{
    // Создаем класс, который будет содержать методы для фильтрации данных
    public class DataFilter
    {
        // Определяем делегат для фильтрации данных
        public delegate bool FilterDelegate(string data);

        // Метод для фильтрации данных с использованием делегата
        public static List<string> FilterData(List<string> dataList, FilterDelegate filter)
        {
            List<string> filteredData = new List<string>();

            foreach (string data in dataList)
            {
                if (filter(data))
                {
                    filteredData.Add(data);
                }
            }

            return filteredData;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Пример списка данных
            List<string> data = new List<string>
            {
                "Я помню чудное мгновенье:\n" +
                "Передо мной явилась ты,\n" +
                "Как мимолетное виденье,\n" +
                "Как гений чистой красоты.",

                "Ты как звезда падшая с небес,\n" +
                "Ты как лебедь белая на волнах,\n" +
                "Ты как пушистый облак в небесах,\n" +
                "Ты как весенний аромат цветов."
            };

            Console.WriteLine("Выберите тип фильтрации (1 - по длине, 2 - по ключевым словам):");
            int filterType = int.Parse(Console.ReadLine());

            // Создаем делегат в зависимости от выбранного типа фильтрации
            DataFilter.FilterDelegate filter;

            if (filterType == 1)
            {
                // Фильтр по длине строки (длина больше 20 символов)
                filter = dataItem => dataItem.Length > 20;
            }
            else if (filterType == 2)
            {
                // Фильтр по ключевым словам (например, содержит слово "Я помню")
                filter = dataItem => dataItem.Contains("Я помню");
            }
            else
            {
                Console.WriteLine("Неправильный выбор фильтрации.");
                return;
            }

            // Применяем фильтр к данным и выводим результат
            List<string> filteredData = DataFilter.FilterData(data, filter);

            Console.WriteLine("Результат фильтрации:");
            foreach (string item in filteredData)
            {
                Console.WriteLine(item);
            }
        }
    }
}
