using System;
using System.Collections.Generic;

namespace SortingApp
{
    // Создадим делегат для методов сортировки.
    delegate void SortingMethod(List<int> list);

    internal class Program
    {
        static void Main(string[] args)
        {
            // Запросим у пользователя количество чисел.
            Console.Write("Введите количество чисел: ");
            int count = int.Parse(Console.ReadLine());

            // Создадим список для хранения чисел.
            List<int> numbers = new List<int>();

            // Запросим у пользователя ввести числа.
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Введите число {i + 1}: ");
                int num = int.Parse(Console.ReadLine());
                numbers.Add(num);
            }

            // Предоставим пользователю выбор метода сортировки.
            Console.WriteLine("Выберите метод сортировки:");
            Console.WriteLine("1. Сортировка пузырьком");
            Console.WriteLine("2. Быстрая сортировка");
            int choice = int.Parse(Console.ReadLine());

            // Создадим экземпляр делегата SortingMethod.
            SortingMethod sortingMethod = null;

            // В зависимости от выбора пользователя, присвоим делегату соответствующий метод сортировки.
            switch (choice)
            {
                case 1:
                    sortingMethod = BubbleSort;
                    break;
                case 2:
                    sortingMethod = QuickSort;
                    break;
                default:
                    Console.WriteLine("Выбран неверный метод сортировки.");
                    return;
            }

            // Вызовем выбранный метод сортировки и выведем отсортированный список.
            sortingMethod(numbers);

            Console.WriteLine("Отсортированный список:");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
        }

        // Метод сортировки пузырьком.
        static void BubbleSort(List<int> list)
        {
            int n = list.Count;
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < n; i++)
                {
                    if (list[i - 1] > list[i])
                    {
                        // Обмен элементов.
                        int temp = list[i - 1];
                        list[i - 1] = list[i];
                        list[i] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        // Метод быстрой сортировки.
        static void QuickSort(List<int> list)
        {
            if (list.Count <= 1)
                return;

            int pivotIndex = list.Count / 2;
            int pivotValue = list[pivotIndex];
            List<int> less = new List<int>();
            List<int> greater = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (i == pivotIndex)
                    continue;

                if (list[i] <= pivotValue)
                    less.Add(list[i]);
                else
                    greater.Add(list[i]);
            }

            QuickSort(less);
            QuickSort(greater);

            list.Clear();
            list.AddRange(less);
            list.Add(pivotValue);
            list.AddRange(greater);
        }
    }
}
