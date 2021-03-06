﻿using System;
using System.Collections.Generic;

namespace Indexer_yield_IEnumerable_Urok22
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>()  // создаем автомобили
            {
                new Car() {Name = "Ford", Number = "A001AA01"},
                new Car() {Name = "Lada", Number = "B727ET77"}
            };

            var parking = new Parking(); // Создаем парковку

            foreach (var car in cars)
            {
                parking.Add(car);
            }

            foreach (var car in parking)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();

            #region Простой целочисленный пример
            //foreach (var item in parking)
            //{
            //    Console.WriteLine(item + " ");
            //}
            #endregion

            #region Пример на наших автомобилях
            foreach (var name in parking.GetNames())
            {
                Console.WriteLine("Имя: " + name);
            }
            #endregion

            Console.WriteLine();

            Console.WriteLine(parking["A001AA01"]?.Name);  // Проверка автомобиля по номеру. ? - так как получаем null
            Console.WriteLine(parking["A001AA02"]?.Name);  // Не существующий автомобиль - для примера. ? - так как получаем null

            Console.WriteLine("Введите номер нового автомобиля:");
            var num = Console.ReadLine();

            parking[1] = new Car() { Name = "BMW", Number = num };
            Console.WriteLine(parking[1]);

            Console.ReadLine();
        }
    }
}
