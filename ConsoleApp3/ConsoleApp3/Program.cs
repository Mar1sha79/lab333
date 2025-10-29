namespace Lab3_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Лабораторная работа 3 - Массивы и файлы");

            while (true)
            {
                System.Console.WriteLine("1. Задание 1 - Заполнение двумерных массивов");
                System.Console.WriteLine("2. Задание 2 - Работа с двумерными массивами");
                System.Console.WriteLine("3. Задание 3 - Работа с матрицами");
                System.Console.WriteLine("4. Задание 4 - Бинарные файлы");
                System.Console.WriteLine("5. Задание 5 - Бинарные файлы и структуры");
                System.Console.WriteLine("6. Задание 6 - Текстовые файлы");
                System.Console.WriteLine("7. Задание 7 - Текстовые файлы (структура)");
                System.Console.WriteLine("8. Задание 8 - Текстовый файл");
                System.Console.WriteLine("0. Выход");
                System.Console.Write("Выберите задание: ");

                string choice = System.Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Solution.Task1();
                        break;
                    case "2":
                        Solution.Task2();
                        break;
                    case "3":
                        Solution.Task3();
                        break;
                    case "4":
                        Solution.Task4();
                        break;
                    case "5":
                        Solution.Task5();
                        break;
                    case "6":
                        Solution.Task6();
                        break;
                    case "7":
                        Solution.Task7();
                        break;
                    case "8":
                        Solution.Task8();
                        break;
                    case "0":
                        System.Console.WriteLine("Выход из программы.");
                        return;
                    default:
                        System.Console.WriteLine("Неверный выбор! Попробуйте снова.");
                        break;
                }

                System.Console.WriteLine("\nНажмите любую клавишу для продолжения.");
                System.Console.ReadKey();
            }
        }
    }
}