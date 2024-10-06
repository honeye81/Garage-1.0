using Garage_1._0;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Garage_1._0
{
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private T[] _vehicles; // Array to store vehicles
        private int _currentVehicleCount = 0; // Keeps track of how many vehicles are in the garage
        public int Capacity { get; private set; } // The capacity of the garage

        // Constructor to initialize the garage with a specific capacity
        public Garage(int capacity)
        {
            Capacity = capacity;
            _vehicles = new T[capacity];
        }

        // Adds a vehicle to the garage
        public void Add(T vehicle)
        {
            if (_currentVehicleCount < Capacity)
            {
                _vehicles[_currentVehicleCount] = vehicle;
                _currentVehicleCount++;
            }
            else
            {
                throw new InvalidOperationException("Garage is full");
            }
        }

        // Removes a vehicle from the garage
        public void Remove(T vehicle)
        {
            int index = Array.IndexOf(_vehicles, vehicle);
            if (index >= 0)
            {
                // Shift all elements after the removed vehicle to fill the gap
                for (int i = index; i < _currentVehicleCount - 1; i++)
                {
                    _vehicles[i] = _vehicles[i + 1];
                }
                _vehicles[_currentVehicleCount - 1] = default(T); // Set the last slot to default
                _currentVehicleCount--;
            }
            else
            {
                throw new InvalidOperationException("Vehicle not found");
            }
        }

        // Checks if the garage is full
        public bool IsFull()
        {
            return _currentVehicleCount >= Capacity;
        }

        // Returns the number of vehicles currently in the garage
        public int Count
        {
            get { return _currentVehicleCount; }
        }

        // 
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _currentVehicleCount; i++)
            {
                yield return _vehicles[i];
            }
        }

        // 
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
