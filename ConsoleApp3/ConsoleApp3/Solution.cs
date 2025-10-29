namespace Lab3_CSharp
{
    public static class Solution
    {
        //задание 1
        public static void Task1()
        {
            System.Console.WriteLine("\nзадание 1");
            System.Console.WriteLine("Заполнение трех массивов согласно варианту 3");

            try
            {
                System.Console.Write("Введите n: ");
                int n = int.Parse(System.Console.ReadLine());
                System.Console.Write("Введите m: ");
                int m = int.Parse(System.Console.ReadLine());

                if (n <= 0 || m <= 0)
                {
                    System.Console.WriteLine("Размеры массива должны быть положительными!");
                    return;
                }

                int[,] array1 = new int[n, m];
                System.Console.WriteLine($"Введите {n * m} элементов первого массива:");
                for (int j = 0; j < m; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        System.Console.Write($"Элемент [{i},{j}]: ");
                        array1[i, j] = int.Parse(System.Console.ReadLine());
                    }
                }

                int[,] array2 = new int[n, n];
                System.Random rand = new System.Random();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j > n - i - 1)
                        {
                            array2[i, j] = rand.Next(-12, 4566);
                        }

                        else
                        {
                            array2[i, j] = rand.Next(-1024, 1025);
                        }
                    }
                }

                int[,] array3 = CreateSpecialArray(n);

                System.Console.WriteLine("\nПервый массив:");
                PrintArray(array1);
                System.Console.WriteLine("\nВторой массив:");
                PrintArray(array2);
                System.Console.WriteLine("\nТретий массив:");
                PrintArray(array3);
            }
            catch (System.FormatException)
            {
                System.Console.WriteLine("Ошибка: неверный формат ввода!");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static int[,] CreateSpecialArray(int n)
        {
            int[,] array = new int[n, n];
            int value = 1;

            for (int d = 0; d < 2 * n - 1; d++)
            {
                if (d < n)
                {
                    for (int i = d, j = n - 1; i >= 0 && j >= n - 1 - d; i--, j--)
                    {
                        array[i, j] = value++;
                    }
                }
                else
                {
                    for (int i = n - 1, j = 2 * n - 2 - d; j >= 0 && i >= d - n + 1; i--, j--)
                    {
                        array[i, j] = value++;
                    }
                }
            }
            return array;
        }

        private static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    System.Console.Write($"{array[i, j],6}");
                }
                System.Console.WriteLine();
            }
        }

        //задание 2
        public static void Task2()
        {
            System.Console.WriteLine("\nзадание 2");
            System.Console.WriteLine("Найти подмассив 3x3 с максимальной суммой");

            try
            {
                System.Console.Write("Введите количество строк n: ");
                int n = int.Parse(System.Console.ReadLine());
                System.Console.Write("Введите количество столбцов m: ");
                int m = int.Parse(System.Console.ReadLine());

                if (n <= 0 || m <= 0)
                {
                    System.Console.WriteLine("Размеры массива должны быть положительными!");
                    return;
                }

                int[,] array = new int[n, m];
                System.Random rand = new System.Random();

                System.Console.WriteLine("Сгенерированный массив:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        array[i, j] = rand.Next(-50, 51);
                        System.Console.Write($"{array[i, j],4}");
                    }
                    System.Console.WriteLine();
                }

                int maxSum = int.MinValue;
                int startRow = -1, startCol = -1;

                for (int i = 0; i <= n - 3; i++)
                {
                    for (int j = 0; j <= m - 3; j++)
                    {
                        int sum = 0;
                        for (int k = 0; k < 3; k++)
                        {
                            for (int l = 0; l < 3; l++)
                            {
                                sum += array[i + k, j + l];
                            }
                        }
                        if (sum > maxSum)
                        {
                            maxSum = sum;
                            startRow = i;
                            startCol = j;
                        }
                    }
                }

                if (startRow != -1 && startCol != -1)
                {
                    System.Console.WriteLine($"\nПодмассив 3x3 с максимальной суммой {maxSum}:");
                    for (int i = startRow; i < startRow + 3; i++)
                    {
                        for (int j = startCol; j < startCol + 3; j++)
                        {
                            System.Console.Write($"{array[i, j],4}");
                        }
                        System.Console.WriteLine();
                    }
                }
                else
                {
                    System.Console.WriteLine("Не удалось найти подмассив 3x3!");
                }
            }
            catch (System.FormatException)
            {
                System.Console.WriteLine("Ошибка: неверный формат ввода!");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        //задание 3
        public static void Task3()
        {
            System.Console.WriteLine("\nзадание 3");
            System.Console.WriteLine("Вычисление матричного выражения: Aт + 2*В + Ст");

            try
            {
                System.Console.Write("Введите размер матриц n: ");
                int n = int.Parse(System.Console.ReadLine());

                if (n <= 0)
                {
                    System.Console.WriteLine("Размер матрицы должен быть положительным!");
                    return;
                }

                Matrix A = new Matrix(n, n);
                Matrix B = new Matrix(n, n);
                Matrix C = new Matrix(n, n);

                System.Console.WriteLine("\nМатрица A:");
                A.FillRandom();
                System.Console.WriteLine(A);

                System.Console.WriteLine("Матрица B:");
                B.FillRandom();
                System.Console.WriteLine(B);

                System.Console.WriteLine("Матрица C:");
                C.FillRandom();
                System.Console.WriteLine(C);

                Matrix result = A.Transpose() + 2 * B + C.Transpose();
                System.Console.WriteLine("Результат выражения Aт + 2*В + Ст:");
                System.Console.WriteLine(result);
            }
            catch (System.FormatException)
            {
                System.Console.WriteLine("Ошибка: неверный формат ввода!");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        //задание 4
        public static void Task4()
        {
            System.Console.WriteLine("\nзадание 4");
            System.Console.WriteLine("Получить компоненты, которые делятся на m и не делятся на n");

            try
            {
                string sourceFile = "binary_data.bin";
                string resultFile = "filtered_data.bin";

                System.Console.WriteLine("\nВыберите способ заполнения исходного файла:");
                System.Console.WriteLine("1 - автоматическая генерация");
                System.Console.WriteLine("2 - ввод с клавиатуры");
                System.Console.Write("Ваш выбор: ");

                string choice = System.Console.ReadLine();

                if (choice == "2")
                {
                    FillBinaryFileFromKeyboard(sourceFile);
                }
                else
                {
                    FillBinaryFileRandom(sourceFile);
                }

                System.Console.Write("\nВведите m: ");
                int m = int.Parse(System.Console.ReadLine());
                System.Console.Write("Введите n: ");
                int n = int.Parse(System.Console.ReadLine());

                if (m == 0)
                {
                    System.Console.WriteLine("Ошибка: m не может быть равно 0!");
                    return;
                }

                var result = FilterBinaryData(sourceFile, m, n);

                WriteBinaryData(resultFile, result);

                DisplayResults(sourceFile, resultFile, result, m, n);
            }
            catch (System.FormatException)
            {
                System.Console.WriteLine("Ошибка: неверный формат ввода");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void FillBinaryFileRandom(string filename)
        {
            System.Console.Write("Введите количество чисел: ");
            int count = int.Parse(System.Console.ReadLine());

            System.Random rand = new System.Random();
            using (var writer = new System.IO.BinaryWriter(System.IO.File.Open(filename, System.IO.FileMode.Create)))
            {
                for (int i = 0; i < count; i++)
                {
                    writer.Write(rand.Next(-100, 101));
                }
            }
            System.Console.WriteLine($"Сгенерировано {count} чисел");
        }

        private static void FillBinaryFileFromKeyboard(string filename)
        {
            System.Console.WriteLine("\nВведите числа (пустая строка - завершить):");

            var numbers = new System.Collections.Generic.List<int>();

            while (true)
            {
                System.Console.Write("Число: ");
                string input = System.Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    break;

                numbers.Add(int.Parse(input));
            }

            using (var writer = new System.IO.BinaryWriter(System.IO.File.Open(filename, System.IO.FileMode.Create)))
            {
                foreach (int number in numbers)
                {
                    writer.Write(number);
                }
            }

            System.Console.WriteLine($"Введено {numbers.Count} чисел");
        }

        private static System.Collections.Generic.List<int> FilterBinaryData(string sourceFile, int m, int n)
        {
            var result = new System.Collections.Generic.List<int>();

            using (var reader = new System.IO.BinaryReader(System.IO.File.Open(sourceFile, System.IO.FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int number = reader.ReadInt32();
                    if (number % m == 0 && number % n != 0)
                    {
                        result.Add(number);
                    }
                }
            }

            return result;
        }

        private static void WriteBinaryData(string filename, System.Collections.Generic.List<int> data)
        {
            using (var writer = new System.IO.BinaryWriter(System.IO.File.Open(filename, System.IO.FileMode.Create)))
            {
                foreach (int number in data)
                {
                    writer.Write(number);
                }
            }
        }

        private static void DisplayResults(string sourceFile, string resultFile,
            System.Collections.Generic.List<int> result, int m, int n)
        {
            System.Console.WriteLine($"Условие: делятся на {m} и не делятся на {n}");
            System.Console.WriteLine($"Найдено чисел: {result.Count}");

            if (result.Count > 0)
            {
                System.Console.WriteLine("Числа:");
                foreach (int num in result)
                {
                    System.Console.Write($"{num} ");
                }
                System.Console.WriteLine();
            }
        }

        //задание 5
        public static void Task5()
        {
            System.Console.WriteLine("\nзадание 5");
            System.Console.WriteLine("Найти пассажира с одной единицей багажа массой менее m кг");

            try
            {
                string filename = "passengers.xml";

                System.Console.Write("Введите максимальную массу m: ");
                double m = double.Parse(System.Console.ReadLine());

                if (m <= 0)
                {
                    System.Console.WriteLine("Масса должна быть положительной!");
                    return;
                }

                FillPassengersFileFromKeyboard(filename);

                System.Collections.Generic.List<Passenger> passengers = ReadPassengersFromFile(filename);

                var foundPassengers = passengers.Where(p => p.Luggage.Count == 1 && p.Luggage[0].Weight < m).ToList();

                if (foundPassengers.Any())
                {
                    System.Console.WriteLine($"\nНайдено {foundPassengers.Count} пассажиров с одной единицей багажа массой менее {m} кг:");
                    foreach (var passenger in foundPassengers)
                    {
                        System.Console.WriteLine($"Пассажир: {passenger.Name}");
                        System.Console.WriteLine($"  Багаж: {passenger.Luggage[0].Item}");
                        System.Console.WriteLine($"  Масса: {passenger.Luggage[0].Weight} кг");
                        System.Console.WriteLine();
                    }
                }
                else
                {
                    System.Console.WriteLine($"Пассажиры с одной единицей багажа массой менее {m} кг не найдены.");
                }

                System.Console.WriteLine("\nИнформация о всех пассажирах:");
                foreach (var passenger in passengers)
                {
                    System.Console.WriteLine($"Пассажир: {passenger.Name}");
                    System.Console.WriteLine($"  Количество единиц багажа: {passenger.Luggage.Count}");
                    foreach (var item in passenger.Luggage)
                    {
                        System.Console.WriteLine($"    - {item.Item}: {item.Weight} кг");
                    }
                    System.Console.WriteLine();
                }

            }
            catch (System.FormatException)
            {
                System.Console.WriteLine("Ошибка: неверный формат ввода!");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void FillPassengersFileFromKeyboard(string filename)
        {
            System.Collections.Generic.List<Passenger> passengers = new System.Collections.Generic.List<Passenger>();

            System.Console.WriteLine("\nввод данных о пассажирах");

            while (true)
            {
                System.Console.Write("\nВведите имя пассажира (или 'стоп' для завершения ввода): ");
                string name = System.Console.ReadLine();

                if (name.ToLower() == "стоп" || string.IsNullOrWhiteSpace(name))
                    break;

                Passenger passenger = new Passenger { Name = name };

                System.Console.WriteLine($"Ввод багажа для пассажира {name}:");
                int itemCount = 1;

                while (true)
                {
                    System.Console.Write($"Введите название единицы багажа #{itemCount} (или 'готово' для завершения): ");
                    string itemName = System.Console.ReadLine();

                    if (itemName.ToLower() == "готово" || string.IsNullOrWhiteSpace(itemName))
                        break;

                    double weight;
                    while (true)
                    {
                        System.Console.Write($"Введите массу {itemName} (кг): ");
                        string weightInput = System.Console.ReadLine();

                        if (double.TryParse(weightInput, out weight) && weight > 0)
                            break;
                        else
                            System.Console.WriteLine("Ошибка: введите положительное число для массы!");
                    }

                    passenger.Luggage.Add(new LuggageItem { Item = itemName, Weight = weight });
                    itemCount++;

                    System.Console.WriteLine($"Добавлен: {itemName} - {weight} кг");
                }

                if (passenger.Luggage.Count > 0)
                {
                    passengers.Add(passenger);
                    System.Console.WriteLine($"Пассажир {name} добавлен с {passenger.Luggage.Count} единицами багажа.");
                }
                else
                {
                    System.Console.WriteLine("Пассажир не добавлен - нет единиц багажа.");
                }
            }

            // Если не ввели ни одного пассажира, создаем тестовые данные
            if (passengers.Count == 0)
            {
                System.Console.WriteLine("\nНе введено данных. Создаются тестовые данные...");
                passengers = CreateTestPassengers();
            }

            SavePassengersToFile(passengers, filename);
            System.Console.WriteLine($"\nДанные сохранены в файл: {filename}");
        }

        private static System.Collections.Generic.List<Passenger> CreateTestPassengers()
        {
            return new System.Collections.Generic.List<Passenger>
    {
        new Passenger
        {
            Name = "Иванов Иван",
            Luggage = new System.Collections.Generic.List<LuggageItem>
            {
                new LuggageItem { Item = "Чемодан", Weight = 25 },
                new LuggageItem { Item = "Рюкзак", Weight = 8 }
            }
        },
        new Passenger
        {
            Name = "Петрова Мария",
            Luggage = new System.Collections.Generic.List<LuggageItem>
            {
                new LuggageItem { Item = "Сумка", Weight = 5 },
                new LuggageItem { Item = "Коробка", Weight = 12 },
                new LuggageItem { Item = "Пакет", Weight = 3 }
            }
        },
        new Passenger
        {
            Name = "Сидоров Алексей",
            Luggage = new System.Collections.Generic.List<LuggageItem>
            {
                new LuggageItem { Item = "Рюкзак", Weight = 7 }
            }
        },
        new Passenger
        {
            Name = "Козлова Анна",
            Luggage = new System.Collections.Generic.List<LuggageItem>
            {
                new LuggageItem { Item = "Чемодан", Weight = 18 },
                new LuggageItem { Item = "Сумка", Weight = 5 }
            }
        }
    };
        }

        private static void SavePassengersToFile(System.Collections.Generic.List<Passenger> passengers, string filename)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(System.Collections.Generic.List<Passenger>));
            using (System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Create))
            {
                serializer.Serialize(fs, passengers);
            }
        }

        private static System.Collections.Generic.List<Passenger> ReadPassengersFromFile(string filename)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(System.Collections.Generic.List<Passenger>));
            using (System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open))
            {
                return (System.Collections.Generic.List<Passenger>)serializer.Deserialize(fs);
            }
        }

        //задание 6
        public static void Task6()
        {
            System.Console.WriteLine("\nзадание 6");
            System.Console.WriteLine("Найти разность максимального и минимального элементов");

            try
            {
                string filename = "numbers.txt";

                FillTextFileFromKeyboard(filename);

                System.Collections.Generic.List<int> numbers = ReadNumbersFromFile(filename);

                if (numbers.Count == 0)
                {
                    System.Console.WriteLine("Файл пуст!");
                    return;
                }

                int max = numbers[0];
                int min = numbers[0];

                foreach (int number in numbers)
                {
                    if (number > max) max = number;
                    if (number < min) min = number;
                }

                int difference = max - min;

                System.Console.WriteLine($"\nСодержимое файла {filename}:");
                foreach (int number in numbers)
                {
                    System.Console.Write($"{number} ");
                }

                System.Console.WriteLine($"\n\nМаксимальный элемент: {max}");
                System.Console.WriteLine($"Минимальный элемент: {min}");
                System.Console.WriteLine($"Разность: {max} - {min} = {difference}");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void FillTextFileFromKeyboard(string filename)
        {
            System.Collections.Generic.List<int> numbers = new System.Collections.Generic.List<int>();

            System.Console.WriteLine("Вводите целые числа по одному в строке");
            System.Console.WriteLine("Для завершения ввода введите пустую строку или 'стоп'");

            int count = 1;
            while (true)
            {
                System.Console.Write($"Число #{count}: ");
                string input = System.Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "стоп")
                    break;

                if (int.TryParse(input, out int number))
                {
                    numbers.Add(number);
                    System.Console.WriteLine($"Добавлено: {number}");
                    count++;
                }
                else
                {
                    System.Console.WriteLine("Ошибка: введите целое число!");
                }
            }

            if (numbers.Count == 0)
            {
                System.Console.WriteLine("\nНе введено чисел. Создаются тестовые данные...");
                numbers = CreateTestNumbers();
            }

            SaveNumbersToFile(numbers, filename);
            System.Console.WriteLine($"\nВведено {numbers.Count} чисел. Данные сохранены в файл: {filename}");
        }

        private static System.Collections.Generic.List<int> CreateTestNumbers()
        {
            System.Random rand = new System.Random();
            System.Collections.Generic.List<int> numbers = new System.Collections.Generic.List<int>();

            for (int i = 0; i < 10; i++)
            {
                numbers.Add(rand.Next(-50, 51));
            }

            return numbers;
        }

        private static void SaveNumbersToFile(System.Collections.Generic.List<int> numbers, string filename)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filename))
            {
                foreach (int number in numbers)
                {
                    writer.WriteLine(number);
                }
            }
        }

        private static System.Collections.Generic.List<int> ReadNumbersFromFile(string filename)
        {
            System.Collections.Generic.List<int> numbers = new System.Collections.Generic.List<int>();

            using (System.IO.StreamReader reader = new System.IO.StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int number))
                    {
                        numbers.Add(number);
                    }
                }
            }

            return numbers;
        }

        //задание 7
        public static void Task7()
        {
            System.Console.WriteLine("\nзадание 7");
            System.Console.WriteLine("Вычислить минимальный элемент");

            try
            {
                string filename = "multi_numbers.txt";
                FillMultiNumberFile(filename, 5, 4);

                System.Collections.Generic.List<int> numbers = new System.Collections.Generic.List<int>();
                using (System.IO.StreamReader reader = new System.IO.StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(' ');
                        foreach (string part in parts)
                        {
                            if (int.TryParse(part, out int number))
                            {
                                numbers.Add(number);
                            }
                        }
                    }
                }

                if (numbers.Count == 0)
                {
                    System.Console.WriteLine("Файл пуст!");
                    return;
                }

                int min = numbers[0];
                foreach (int number in numbers)
                {
                    if (number < min) min = number;
                }

                System.Console.WriteLine($"Содержимое файла {filename}:");
                string content = System.IO.File.ReadAllText(filename);
                System.Console.WriteLine(content);
                System.Console.WriteLine($"Минимальный элемент: {min}");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void FillMultiNumberFile(string filename, int lines, int numbersPerLine)
        {
            System.Random rand = new System.Random();
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filename))
            {
                for (int i = 0; i < lines; i++)
                {
                    for (int j = 0; j < numbersPerLine; j++)
                    {
                        writer.Write(rand.Next(-50, 51));
                        if (j < numbersPerLine - 1) writer.Write(" ");
                    }
                    writer.WriteLine();
                }
            }
        }

        //задание 8
        public static void Task8()
        {
            System.Console.WriteLine("\nзадание 8");
            System.Console.WriteLine("Переписать строки, начинающиеся с заданного символа");

            try
            {
                string sourceFile = "text.txt";
                string resultFile = "filtered_text.txt";

                System.Console.WriteLine("Выберите способ заполнения файла:");
                System.Console.WriteLine("1 - использовать тестовые данные");
                System.Console.WriteLine("2 - ввести данные с клавиатуры");

                string choice = System.Console.ReadLine();

                if (choice == "2")
                {
                    FillTextContentFileFromKeyboard(sourceFile);
                }
                else
                {
                    FillTextContentFile(sourceFile);
                }

                System.Console.Write("Введите символ для фильтрации: ");
                char filterChar = System.Console.ReadLine()[0];

                int count = 0;

                using (System.IO.StreamReader reader = new System.IO.StreamReader(sourceFile))
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(resultFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith(filterChar))
                        {
                            writer.WriteLine(line);
                            count++;
                        }
                    }
                } 

                System.Console.WriteLine($"Исходный файл: {sourceFile}");
                System.Console.WriteLine($"Результирующий файл: {resultFile}");
                System.Console.WriteLine($"Перенесено {count} строк, начинающихся с '{filterChar}'");

                if (count > 0)
                {
                    System.Console.WriteLine("Перенесенные строки:");
                    string resultContent = System.IO.File.ReadAllText(resultFile);
                    System.Console.WriteLine(resultContent);
                }
                else
                {
                    System.Console.WriteLine("Строк, начинающихся с указанного символа, не найдено.");
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void FillTextContentFileFromKeyboard(string filename)
        {
            System.Console.WriteLine("Введите содержимое файла (для завершения введите пустую строку):");

            var lines = new System.Collections.Generic.List<string>();

            while (true)
            {
                System.Console.Write("Строка: ");
                string input = System.Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    break;

                lines.Add(input);
            }

            System.IO.File.WriteAllLines(filename, lines);
            System.Console.WriteLine($"Файл {filename} успешно создан с {lines.Count} строками");
        }

        private static void FillTextContentFile(string filename)
        {
            string[] lines = {
        "4 dgd 67 09",
        "ffhfjh 56 43 = 11",
        "4 xgch 3424 76",
        "ked 5 76 43",
        "4 4 4 4",
        "8 vkjk 4 3"
    };

            System.IO.File.WriteAllLines(filename, lines);
        }

        // Класс Matrix для задания 3
        public class Matrix
        {
            private int[,] data;
            public int Rows { get; private set; }
            public int Cols { get; private set; }

            public Matrix(int rows, int cols)
            {
                Rows = rows;
                Cols = cols;
                data = new int[rows, cols];
            }

            public void FillRandom()
            {
                System.Random rand = new System.Random();
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        data[i, j] = rand.Next(-10, 11);
                    }
                }
            }

            public Matrix Transpose()
            {
                Matrix result = new Matrix(Cols, Rows);
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        result.data[j, i] = data[i, j];
                    }
                }
                return result;
            }

            public static Matrix operator +(Matrix a, Matrix b)
            {
                if (a.Rows != b.Rows || a.Cols != b.Cols)
                    throw new System.ArgumentException("Матрицы должны быть одного размера");

                Matrix result = new Matrix(a.Rows, a.Cols);
                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < a.Cols; j++)
                    {
                        result.data[i, j] = a.data[i, j] + b.data[i, j];
                    }
                }
                return result;
            }

            public static Matrix operator *(int scalar, Matrix matrix)
            {
                Matrix result = new Matrix(matrix.Rows, matrix.Cols);
                for (int i = 0; i < matrix.Rows; i++)
                {
                    for (int j = 0; j < matrix.Cols; j++)
                    {
                        result.data[i, j] = scalar * matrix.data[i, j];
                    }
                }
                return result;
            }

            public override string ToString()
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        sb.Append($"{data[i, j],6}");
                    }
                    sb.AppendLine();
                }
                return sb.ToString();
            }
        }

        // Классы для задания 5
        public class Passenger
        {
            public string Name { get; set; }
            public System.Collections.Generic.List<LuggageItem> Luggage { get; set; }

            public Passenger()
            {
                Luggage = new System.Collections.Generic.List<LuggageItem>();
            }
        }

        public class LuggageItem
        {
            public string Item { get; set; }
            public double Weight { get; set; }
        }
    }
}