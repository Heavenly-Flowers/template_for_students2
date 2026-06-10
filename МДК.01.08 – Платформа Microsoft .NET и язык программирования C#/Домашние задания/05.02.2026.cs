using System;

class Program
{
    static void Main(string[] args)
    {
        string[] users = { "Анна", "Иван", "Мария", "Дмитрий", "Ольга" };
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\nМЕНЮ");
            Console.WriteLine("1 - Показать всех пользователей");
            Console.WriteLine("2 - Редактировать имя пользователя");
            Console.WriteLine("3 - Выйти из программы");
            Console.Write("Ваш выбор: ");

            string menuChoice = Console.ReadLine();

            switch (menuChoice)
            {
                case "1":
                    ShowUsers(users);
                    break;
                case "2":
                    EditUser(users);
                    break;
                case "3":
                    Console.WriteLine("До свидания!");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Ошибка! Выберите 1, 2 или 3");
                    break;
            }
        }
    }

    static void ShowUsers(string[] users)
    {
        Console.WriteLine("\nСписок пользователей:");

        for (int i = 0; i < users.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {users[i]}");
        }
    }

    static void EditUser(string[] users)
    {
        Console.WriteLine("\nРедакт пользователя");
        ShowUsers(users);

        Console.Write("\nВведите номер пользователя для редактирования: ");
        string inputNumber = Console.ReadLine();

        if (int.TryParse(inputNumber, out int userNumber) && userNumber >= 1 && userNumber <= users.Length)
        {
            int targetIndex = userNumber - 1;

            Console.WriteLine($"Текущее имя: {users[targetIndex]}");
            Console.Write("Введите новое имя: ");
            string newName = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(newName))
            {
                users[targetIndex] = newName;
                Console.WriteLine($"Готово! Пользователь {userNumber} теперь называется {newName}");
            }
            else
            {
                Console.WriteLine("Ошибка: имя не может быть пустым!");
            }
        }
        else
        {
            Console.WriteLine("Ошибка: некорректный номер или введены буквы!");
        }

        Console.WriteLine("\nНажмите Enter, чтобы продолжить...");
        Console.ReadLine();
    }
}
