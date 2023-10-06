using System;
using System.Collections.Generic;

namespace TaskManagementApp
{
    // Создаем класс задачи
    class Task
    {
        public string Description { get; set; }

        public Task(string description)
        {
            Description = description;
        }
    }

    // Создаем делегат для выполнения задачи
    delegate void TaskDelegate(Task task);

    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>(); // Список задач

            while (true)
            {
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Выполнить задачи");
                Console.WriteLine("3. Выйти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите описание задачи:");
                        string description = Console.ReadLine();
                        tasks.Add(new Task(description));
                        break;

                    case "2":
                        Console.WriteLine("Выберите способ выполнения задачи:");
                        Console.WriteLine("1. Отправить уведомление");
                        Console.WriteLine("2. Записать в журнал");
                        string delegateChoice = Console.ReadLine();

                        TaskDelegate taskDelegate = null;

                        switch (delegateChoice)
                        {
                            case "1":
                                taskDelegate = SendNotification;
                                break;

                            case "2":
                                taskDelegate = LogTask;
                                break;

                            default:
                                Console.WriteLine("Неверный выбор.");
                                break;
                        }

                        if (taskDelegate != null)
                        {
                            foreach (var task in tasks)
                            {
                                taskDelegate(task);
                            }
                        }
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }

        // Метод для отправки уведомления
        static void SendNotification(Task task)
        {
            Console.WriteLine($"Отправляем уведомление: {task.Description}");
        }

        // Метод для записи задачи в журнал
        static void LogTask(Task task)
        {
            Console.WriteLine($"Записываем в журнал: {task.Description}");
        }
    }
}
