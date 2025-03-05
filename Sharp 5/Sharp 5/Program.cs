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

        // Вывод матрицы на экран с форматированием
        static void PrintMatrix(int size, int[,] array)
        {
            Console.WriteLine("Матрица:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{array[i, j],4} "); // Фиксированная ширина для каждого элемента
                }
                Console.WriteLine(); // Переход на новую строку после каждой строки матрицы
            }
            Console.WriteLine(); // Пустая строка для разделения
        }

        // Функция для нахождения всех позиций минимумов в каждом столбце
        static int[] Task(int size, ref int[,] matrix, out int resultSize)
        {
            // Максимально возможное количество минимумов: size * size
            int[] positions = new int[size * size]; // Массив для хранения позиций минимумов
            resultSize = 0; // Размер массива результатов (out-параметр)

            for (int col = 0; col < size; col++)
            {
                int minValue = int.MaxValue;

                // Находим минимальное значение в текущем столбце
                for (int row = 0; row < size; row++)
                {
                    if (matrix[row, col] < minValue)
                    {
                        minValue = matrix[row, col];
                    }
                }

                // Находим все позиции с минимальным значением в текущем столбце
                for (int row = 0; row < size; row++)
                {
                    if (matrix[row, col] == minValue)
                    {
                        // Кодируем позицию (столбец и строку) в одно число
                        positions[resultSize] = col * size + row; // col * size + row
                        resultSize++;
                    }
                }
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
                PrintMatrix(n, matrix); // Вывод матрицы с форматированием

                int resultSize; // Размер массива результатов (out-параметр)
                int[] positions = Task(n, ref matrix, out resultSize); // Вызов функции Task

                Console.WriteLine("Позиции минимумов:");
                // Вывод результата
                for (int i = 0; i < resultSize; i++)
                {
                    int col = positions[i] / n; // Декодируем столбец
                    int row = positions[i] % n; // Декодируем строку
                    Console.WriteLine($"Столбец {col + 1}: строка {row + 1}");
                }

                Console.WriteLine($"\nРазмер массива результатов: {resultSize}");
            }
            else
            {
                Console.WriteLine("Неправильный ввод");
            }
        }
    }
}