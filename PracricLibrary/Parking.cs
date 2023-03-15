﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracricLibrary
{
    public class Parking
    {
        private Dictionary<int, Car> parkingCars;

        public Parking()
        {
            this.parkingCars = new();
        }

        public Parking(Dictionary<int, Car> cars)
        {
            this.parkingCars = cars;

            /*foreach (var car in parkingCars)
            {
                CheckStateNumber(car.Value);
            }*/
        }

        public void AddCar(int numberPlace, Car car)
        {
            CheckStateNumber(car);
            CheckNumberPlace(numberPlace);

            parkingCars.Add(numberPlace, car);
        }

        private void CheckStateNumber(Car car)
        {
            if (parkingCars.ContainsValue(car)) throw new Exception("This car is exist!");

            /*foreach (var car in parkingCars)
            {
                if (car.Value.stateNumber == stateNumber) throw new Exception("This car is exist!");
            }*/
        }

        private void CheckNumberPlace(int numberPlace)
        {
            if (parkingCars.ContainsKey(numberPlace)) throw new Exception("This place is occupied!");

            /*foreach (var car in parkingCars)
            {
                if (car.Key == numberPlace) throw new Exception("This place is occupied!");
            }*/
        }

        public Dictionary<int, Car> SearchCarFromColor(string color)
        {
            var resultCars = new Dictionary<int, Car>();

            foreach (var car in parkingCars)
            {
                if (car.Value.color == color) resultCars.Add(car.Key, car.Value);
            }

            return resultCars;
        }

        public KeyValuePair<int, Car>? SearchCarFromStateNumber(string stateNumber)
        {
            foreach (var car in parkingCars)
            {
                if (car.Value.stateNumber == stateNumber) return new KeyValuePair<int, Car>(car.Key, car.Value);
            }

            return null;
        }

        public Dictionary<int, Car> SearchCarFromOwnerSurname(string surname)
        {
            var resultCars = new Dictionary<int, Car>();

            foreach (var car in parkingCars)
            {
                if (car.Value.ownerSurname == surname) resultCars.Add(car.Key, car.Value);
            }

            return resultCars;
        }

        public Dictionary<int, Car> GetInParkingCars()
        {
            var resultCars = new Dictionary<int, Car>();

            foreach (var car in parkingCars)
            {
                if (car.Value.inParkingLot) resultCars.Add(car.Key, car.Value);
            }

            return resultCars;
        }

        public Dictionary<int, Car> GetNotParkingCars()
        {
            var resultCars = new Dictionary<int, Car>();

            foreach (var car in parkingCars)
            {
                if (!car.Value.inParkingLot) resultCars.Add(car.Key, car.Value);
            }

            return resultCars;
        }
    }
}