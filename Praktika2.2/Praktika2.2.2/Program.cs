﻿using System;

class Train
{
    public string Destination { get; set; }
    public int Number { get; set; }
    public DateTime DepartureTime { get; set; }

    public Train(string destination, int number, DateTime departureTime)
    {
        Destination = destination;
        Number = number;
        DepartureTime = departureTime;
    }

    public void DisplayInfo(int trainNumber)
    {
        if (trainNumber == Number)
        {
            Console.WriteLine($"Информация о поезде");
            
            Console.WriteLine($"Назначение поезда >> {Destination}");
            
            Console.WriteLine($"Номер поезда >> {Number}");
            
            Console.WriteLine($"Время отправления >> {DepartureTime}");
        }
    }
}

class Program
{
    static void Main()
    {
        Train train1 = new Train("Москва", 133, new DateTime(2024, 4, 20, 14, 30, 0));
        Train train2 = new Train("Томск", 12, new DateTime(2024, 5, 1, 15, 15, 0));

        Console.WriteLine("Напишите номер поезда");

        int trainNumber = int.Parse(Console.ReadLine());

        bool trainFound = false;

        if (trainNumber == train1.Number)
        {
            train1.DisplayInfo(trainNumber);
            trainFound = true;
        }

        if (trainNumber == train2.Number)
        {
            train2.DisplayInfo(trainNumber);
            trainFound = true;
        }

        if (!trainFound)
        {
            Console.WriteLine($"Поезд с номером {trainNumber} не найден");
        }
    }
}