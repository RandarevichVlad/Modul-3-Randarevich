using System;

// Создаем класс Уведомление
public class Notification
{
    // Определяем типы уведомлений как перечисление (enum)
    public enum NotificationType
    {
        Message,
        Call,
        Email
    }

    // Определяем события для каждого типа уведомления
    public event EventHandler<string> MessageReceived;
    public event EventHandler<string> CallReceived;
    public event EventHandler<string> EmailReceived;

    // Метод для отправки уведомления
    public void SendNotification(NotificationType type, string message)
    {
        switch (type)
        {
            case NotificationType.Message:
                OnMessageReceived(message);
                break;
            case NotificationType.Call:
                OnCallReceived(message);
                break;
            case NotificationType.Email:
                OnEmailReceived(message);
                break;
            default:
                break;
        }
    }

    // Защищенные методы для вызова событий
    protected virtual void OnMessageReceived(string message)
    {
        MessageReceived?.Invoke(this, message);
    }

    protected virtual void OnCallReceived(string message)
    {
        CallReceived?.Invoke(this, message);
    }

    protected virtual void OnEmailReceived(string message)
    {
        EmailReceived?.Invoke(this, message);
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        // Создаем экземпляр класса Уведомление
        Notification notification = new Notification();

        // Регистрируем обработчики событий для каждого типа уведомления
        notification.MessageReceived += (sender, message) =>
        {
            Console.WriteLine($"Получено сообщение: {message}");
        };

        notification.CallReceived += (sender, message) =>
        {
            Console.WriteLine($"Получен звонок: {message}");
        };

        notification.EmailReceived += (sender, message) =>
        {
            Console.WriteLine($"Получено письмо: {message}");
        };

        // Отправляем уведомления
        notification.SendNotification(Notification.NotificationType.Message, "Привет, как дела?");
        notification.SendNotification(Notification.NotificationType.Call, "Вам звонили с пропущенным вызовом.");
        notification.SendNotification(Notification.NotificationType.Email, "У вас новое электронное письмо.");

        Console.ReadLine(); // Чтобы консольное приложение не закрылось сразу
    }
}
