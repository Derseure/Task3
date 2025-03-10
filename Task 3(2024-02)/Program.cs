﻿using System;

class Program
{
    static void Main(string[] args)
    {
        // Ввод количества тестов
        int t = int.Parse(Console.ReadLine());
        string[] testCases = new string[t];
        string[] results = new string[t];

        // Чтение всех тестовых случаев
        for (int i = 0; i < t; i++)
        {
            testCases[i] = Console.ReadLine();
        }

        // Обработка каждого тестового случая
        for (int i = 0; i < t; i++)
        {
            results[i] = IsValidTaskProcess(testCases[i]) ? "YES" : "NO";
        }

        // Форматированный вывод: входные данные, результат
        Console.WriteLine($"Input Data ({t} cases):");
        for (int i = 0; i < t; i++)
        {
            Console.WriteLine($"{i + 1}) {testCases[i]} -> {results[i]}");
        }
    }

    static bool IsValidTaskProcess(string process)
    {
        bool isStarted = false;
        bool isEnded = false;

        foreach (char action in process)
        {
            switch (action)
            {
                case 'M': // Запуск задачи
                    if (isStarted && !isEnded) return false; // Повторный запуск без завершения
                    isStarted = true;
                    isEnded = false;
                    break;

                case 'R': // Перезапуск задачи
                    if (!isStarted || isEnded) return false; // Нельзя перезапускать несуществующую или завершённую задачу
                    isStarted = true; // Перезапуск "возвращает" задачу к запущенному состоянию
                    break;

                case 'C': // Отмена задачи
                    if (!isStarted || isEnded) return false; // Нельзя отменить несуществующую или завершённую задачу
                    isStarted = false; // Отмена задачи переводит её в несуществующее состояние
                    break;

                case 'D': // Завершение задачи
                    if (!isStarted || isEnded) return false; // Нельзя завершить несуществующую или уже завершённую задачу
                    isEnded = true; // Задача завершена
                    isStarted = false;
                    break;

                default:
                    return false; // Неизвестное действие
            }
        }

        // По завершении процесса задача должна быть завершена
        return isEnded;
    }
}
