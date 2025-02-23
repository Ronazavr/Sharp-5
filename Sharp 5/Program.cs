using System;

namespace С_sharp_Lab4
{
    internal class Program
    {
        private static Random _random = new Random();

        // Заполнение матрицы случайными числами
        static void FillMatrix(int size, int[,] array)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = _random.Next(-10, 10);
                }
            }
        }

        // Вывод матрицы на экран
        static void PrintMatrix(int size, int[,] array)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Функция для нахождения всех позиций минимумов в каждом столбце
        static int[,] Task(int size, ref int[,] matrix, out int resultSize)
        {
            // Массив для хранения позиций минимумов
            int[,] positions = new int[size, size]; // Максимум size позиций на каждый столбец
            int[] counts = new int[size]; // Массив для хранения количества минимумов в каждом столбце
            resultSize = 0; // Общий размер массива результата (общее количество минимумов)

            for (int col = 0; col < size; col++)
            {
                int minValue = int.MaxValue;
                counts[col] = 0; // Инициализация счетчика минимумов для текущего столбца

                // Находим минимальное значение в столбце
                for (int row = 0; row < size; row++)
                {
                    if (matrix[row, col] < minValue)
                    {
                        minValue = matrix[row, col];
                        counts[col] = 1; // Начинаем счет заново
                        positions[col, 0] = row; // Записываем первую позицию
                    }
                    else if (matrix[row, col] == minValue)
                    {
                        positions[col, counts[col]] = row; // Добавляем позицию
                        counts[col]++; // Увеличиваем счетчик
                    }
                }

                resultSize += counts[col]; // Увеличиваем общий размер массива результата
            }

            return positions; // Возвращаем массив позиций минимумов
        }

        static void Main(string[] args)
        {
            Console.Write("Введите размер n матрицы nxn: ");

            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                int[,] matrix = new int[n, n];

                FillMatrix(n, matrix);
                Console.WriteLine("\nПроизвольно заданная матрица: ");
                PrintMatrix(n, matrix);

                // Находим все позиции минимумов в каждом столбце
                int resultSize; // Общий размер массива результата (out-параметр)
                int[,] positions = Task(n, ref matrix, out resultSize);

                Console.WriteLine("\nПозиции всех минимальных значений: ");
                // Вывод результата
                for (int col = 0; col < n; col++)
                {
                    Console.Write($"Столбец {col + 1}: ");
                    for (int i = 0; i < n; i++)
                    {
                        if (i < n && positions[col, i] != 0 || i == 0) // Учитываем первую позицию
                        {
                            Console.Write($"строка {positions[col, i] + 1}, ");
                        }
                    }
                    Console.WriteLine();
                }

                Console.WriteLine($"\nОбщий размер массива результата: {resultSize}");
            }
            else
            {
                Console.WriteLine("Неправильный ввод");
            }
        }
    }
}