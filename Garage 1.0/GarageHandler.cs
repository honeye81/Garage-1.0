using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System.Text.Json;

namespace Garage_1._0
{

    public class GarageHandler : IHandler
    {
        private Garage<Vehicle> _garage; // A garage to hold vehicles

        public GarageHandler(int capacity)
        {
            CreateGarage(capacity);
        }

        // Creates a new garage with the specified capacity
        public void CreateGarage(int capacity)
        {
            _garage = new Garage<Vehicle>(capacity);
            Console.WriteLine($"Garage created with a capacity of {capacity} vehicles.");
        }

        // Adds a vehicle to the garage
        public bool AddVehicle(Vehicle vehicle)
        {
            if (_garage == null)
            {
                Console.WriteLine("Garage has not been created yet.");
                return false;
            }

            if (_garage.IsFull())
            {
                Console.WriteLine("Garage is full! Cannot add more vehicles.");
                return false;
            }

            _garage.Add(vehicle);
            Console.WriteLine($"Vehicle {vehicle.RegistrationNumber} added to the garage.");
            return true;
        }



        // Removes a vehicle from the garage by registration number
        public bool RemoveVehicle(string registrationNumber)
        {
            if (_garage == null)
            {
                Console.WriteLine("Garage has not been created yet.");
                return false;
            }

            Vehicle vehicle = _garage.FirstOrDefault(v => v.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase));

            if (vehicle != null)
            {
                _garage.Remove(vehicle);
                Console.WriteLine($"Vehicle {registrationNumber} removed from the garage.");
                return true;
            }

            Console.WriteLine($"No vehicle found with registration number {registrationNumber}.");
            return false;
        }

        // Lists all vehicles currently in the garage
        public IEnumerable<Vehicle> ListAllVehicles()
        {
            if (_garage == null)
            {
                Console.WriteLine("Garage has not been created yet.");
                return Enumerable.Empty<Vehicle>();
            }

            return _garage;
        }

        // Lists the types of vehicles and their count in the garage
        public Dictionary<string, int> ListVehicleTypes()
        {
            if (_garage == null)
            {
                Console.WriteLine("Garage has not been created yet.");
                return new Dictionary<string, int>();
            }

         
            return _garage.GroupBy(v => v.GetType().Name)
                          .ToDictionary(g => g.Key, g => g.Count());
        }

        // Searches for vehicles in the garage based on certain criteria
        public IEnumerable<Vehicle> SearchVehicles(Vehicle searchCriteria)
        {
            if (_garage == null)
            {
                Console.WriteLine("Garage has not been created yet.");
                return Enumerable.Empty<Vehicle>();
            }

            // Filtering based on the search criteria 
            return _garage.Where(v =>
                (string.IsNullOrEmpty(searchCriteria.Color) || v.Color.Equals(searchCriteria.Color, StringComparison.OrdinalIgnoreCase)) &&
                (searchCriteria.Wheels == 0 || v.Wheels == searchCriteria.Wheels) &&
                (string.IsNullOrEmpty(searchCriteria.RegistrationNumber) || v.RegistrationNumber.Equals(searchCriteria.RegistrationNumber, StringComparison.OrdinalIgnoreCase))
            );
        }

        // Checks if the garage is full
        public bool IsGarageFull()
        {
            if (_garage == null)
            {
                Console.WriteLine("Garage has not been created yet.");
                return false;
            }

            return _garage.IsFull();
        }


        //Save and Load Garage from File System

        public void SaveGarage(string filePath)
        {
            var json = JsonSerializer.Serialize(_garage); 
            File.WriteAllText(filePath, json);
            Console.WriteLine("Garage saved successfully.");
        }

        public void LoadGarage(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                _garage = JsonSerializer.Deserialize<Garage<Vehicle>>(json);
                Console.WriteLine("Garage loaded successfully.");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }


        //Search by Vehicle-Specific Properties
        public IEnumerable<Vehicle> SearchBySpecificProperty()
        {
            Console.WriteLine("Enter vehicle type to search (Car, Bus):");
            string type = Console.ReadLine();

            switch (type.ToLower())
            {
                case "car":
                    Console.Write("Enter fuel type (Gasoline/Diesel): ");
                    string fuelType = Console.ReadLine();
                    return _garage.Where(v => v is Car && ((Car)v).FuelType == fuelType);

                case "bus":
                    Console.Write("Enter number of seats: ");
                    int seats = int.Parse(Console.ReadLine());
                    return _garage.Where(v => v is Bus && ((Bus)v).NumberOfSeats == seats);

                   
            }

            return Enumerable.Empty<Vehicle>();
        }


        //Load Garage Size from Configuration File
        public void LoadGarageSizeFromConfig()
        {
            var config = JsonSerializer.Deserialize<Dictionary<string, int>>(File.ReadAllText("appsettings.json"));
            int capacity = config["GarageCapacity"];
            CreateGarage(capacity); 
            Console.WriteLine($"Garage size loaded from config: {capacity}.");
        }



    }
}
