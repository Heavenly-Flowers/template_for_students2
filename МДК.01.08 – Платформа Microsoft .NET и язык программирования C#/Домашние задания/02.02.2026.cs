using System;

class HangmanGame
{
    private static readonly string[] Dictionary = { "Зачет", "Экзамен", "Компьютер", "Программирование", "Метод" };
    private static readonly Random Rng = new();

    static void Main()
    {
        string SecretWord = Dictionary[Rng.Next(Dictionary.Length)];
        char[] CurrentState = Array.ConvertAll(SecretWord.ToCharArray(), _ => '_');
        int Lives = 6;

        Console.WriteLine("=== Игра Виселица ===");

        do
        {
            Console.WriteLine($"\nСлово: {new string(CurrentState)}\nПопыток осталось: {Lives}");
            Console.Write("Введите букву: ");

            string rawInput = Console.ReadLine();
            if (string.IsNullOrEmpty(rawInput) || rawInput.Length != 1)
            {
                Console.WriteLine("Пожалуйста, введите ровно одну букву!");
                continue;
            }

            char playerLetter = rawInput[0];

            if (UpdateProgress(SecretWord, CurrentState, playerLetter))
            {
                Console.WriteLine("Буква есть!");
            }
            else
            {
                Console.WriteLine("Такой буквы нет!");
                Lives--;
            }

        } while (Lives > 0 && Array.Exists(CurrentState, c => c == '_'));

        FinishGame(SecretWord, Lives > 0);
    }

    private static bool UpdateProgress(string secret, char[] state, char letter)
    {
        bool hasMatch = false;
        for (int i = 0; i < secret.Length; i++)
        {
            if (secret[i] != letter) continue;
            state[i] = letter;
            hasMatch = true;
        }
        return hasMatch;
    }

    private static void FinishGame(string word, bool isWin)
    {
        Console.WriteLine(isWin ? "\nВы выиграли!" : "\nВы проиграли!");
        Console.WriteLine($"{(isWin ? "Слово" : "Загаданное слово")}: {word}");
    }
}