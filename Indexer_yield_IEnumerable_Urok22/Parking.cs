using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Indexer_yield_IEnumerable_Urok22
{
    class Parking : IEnumerable
    {
        private List<Car> _cars = new List<Car>();
        private const int MAX_CARS = 100;

        public Car this[string number] // public тип this[тип индекс] (СОЗДАЕМ ИНДЕКСАТОР)
        {
            get
            {
                var car = _cars.FirstOrDefault(c => c.Number == number); // Из всей коллекции автомобилей. мы ищем авто соответствующий и возвращаем его.
                return car;
            }
        }

        // Перегрузка индексатора ==================================================
        public Car this[int position]   // Из набора стоящих машин на паркинге, берем определенную машину и на ее место ставим другую.
        {
            get
            {
                if (position < _cars.Count)
                {
                    return _cars[position];
                }
                return null;
            }
            set
            {
                if (position < _cars.Count)
                {
                    _cars[position] = value;
                }
            }
        }
        //==========================================================================

        public int Count => _cars.Count; // Быстрое свойство, только для чтения. Позволяет объявить публичное свойство, которое доступ к полю класса только для чтения

        public string Name { get; set; }

        public int Add(Car car) // Добавление автомобилей на парковку.
        {
            if (car == null)
            {
                throw new ArgumentException(nameof(car), "Car is null");
            }

            if (_cars.Count < MAX_CARS)
            {
                _cars.Add(car);
                return _cars.Count - 1;
            }
            
            return - 1;
        }

        public void GoOut(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException(nameof(number), "Number is null or empty.");
            }

            var car = _cars.FirstOrDefault(c => c.Name == number); // Проверяем есть ли такой автомобиль
            if (car != null) // Если есть (проверка на null из предыдущей строки) 
            {
                _cars.Remove(car); // То удаляем автомобиль с парковки
            }


        }
        #region Простой целочисленный пример (для работы нужно за комментировать №1) - получаются числа Фибоначчи.
        //public IEnumerator GetEnumerator()
        //{
        //    var current = 0;
        //    for (int i = 0; i < 10; i++)
        //    {
        //        current += i;
        //        yield return current;
        //    }
        //}
        #endregion

        #region Пример на наших автомобилях (для работы нужно за комментировать №1)
        public IEnumerator GetEnumerator()
        {
            foreach (var car in _cars)
            {
                yield return car;
            }
        }

        public IEnumerable GetNames()
        {
            foreach (var car in _cars)
            {
                yield return car.Name;
            }
        }
        #endregion

        #region №1
        //public IEnumerator<Car> GetEnumerator()  // Спец. класс (спец. объект) позволяет перебирать элементы коллекции. <Car> добавлен специально, чтобы возвращаемый тип был типизирован, а не object (не определенный)
        //{
        //    return _cars.GetEnumerator(); // Так как уже есть коллекция автомобилей
        //}
        #endregion

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cars.GetEnumerator();
        }
    }

    public class ParkingEnumerato : IEnumerator  // Здесь уже и есть три метода который позволяют работать с перечислениями
    {   // Если бы не было списка. пришлось бы реализовать весь этот код.
        public object Current => throw new NotImplementedException(); // Указатель на текущий элемент коллекции

        public bool MoveNext()
        {
            throw new NotImplementedException(); // 
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
