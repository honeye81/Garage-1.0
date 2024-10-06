using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    public class ConsoleUI : IUI
    {
        public void ShowMenu()
        {
            Console.WriteLine("\nGarage Menu:");
            Console.WriteLine("1. List all vehicles");
            Console.WriteLine("2. List vehicle types and count");
            Console.WriteLine("3. Add a vehicle");
            Console.WriteLine("4. Remove a vehicle");
            Console.WriteLine("5. Search vehicles");
            Console.WriteLine("6. Create a new garage");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayVehicles(IEnumerable<IVehicle> vehicles)
        {
            if (vehicles == null || !vehicles.Any())
            {
                Console.WriteLine("No vehicles to display.");
                return;
            }

            foreach (var vehicle in vehicles)
            {
                
                vehicle.DisplayInfo();
            }
        }

        public string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public Vehicle GetVehicleDetails()
        {
            Console.Write("Enter vehicle type (Airplane, Motorcycle, Car, Bus, Boat): ");
            string type = Console.ReadLine();
            Console.Write("Enter registration number: ");
            string regNumber = Console.ReadLine();
            Console.Write("Enter color: ");
            string color = Console.ReadLine();
            Console.Write("Enter number of wheels: ");
            //int wheels = int.Parse(Console.ReadLine());

           
            switch (type.ToLower())
            {
                case "airplane":
                    Console.Write("Enter number of engines: ");
                    int engines = int.Parse(Console.ReadLine());
                    return new Airplane(regNumber, color, engines);

                case "motorcycle":
                    Console.Write("Enter cylinder volume: ");
                    int cylinderVolume = int.Parse(Console.ReadLine());
                    return new Motorcycle(regNumber, color, cylinderVolume);

                case "car":
                    Console.Write("Enter fuel type (Gasoline/Diesel): ");
                    string fuelType = Console.ReadLine();
                    return new Car(regNumber, color, fuelType);

                case "bus":
                    Console.Write("Enter number of seats: ");
                    int seats = int.Parse(Console.ReadLine());
                    return new Bus(regNumber, color, seats);

                case "boat":
                    Console.Write("Enter length: ");
                    double length = double.Parse(Console.ReadLine());
                    return new Boat(regNumber, color, length);

                default:
                    throw new ArgumentException("Invalid vehicle type.");
            }
        }

        public string GetRegistrationNumber()
        {
            Console.Write("Enter registration number: ");
            return Console.ReadLine();
        }

        public Vehicle SearchCriteria()
        {
            Console.Write("Enter vehicle type (Car, Bus, Motorcycle, Airplane, Boat): ");
            string vehicleType = Console.ReadLine();

            Console.Write("Enter vehicle color: ");
            string color = Console.ReadLine();

            // 
            int wheels = 0;
            int seats = 0;
            int engines = 0;
            double engineDisp = 0;
            double length = 0;

            // specific criteria based on vehicle type
            switch (vehicleType.ToLower())
            {
                case "car":
                    Console.Write("Enter fuel type (Gasoline/Diesel): ");
                    string fuelType = Console.ReadLine();
                    return new Car("", color, fuelType); // Return Car object with specified properties

                case "bus":
                    Console.Write("Enter number of seats: ");
                    seats = int.Parse(Console.ReadLine());
                    return new Bus("", color, seats); // Return Bus object with specified properties

                case "motorcycle":
                    Console.Write("Enter engineDisplacement: ");
                    engineDisp = double.Parse(Console.ReadLine());
                    return new Motorcycle("", color, engineDisp); // Return Motorcycle object with specified properties

                case "airplane":
                    Console.Write("Enter Engines: ");
                    engines = int.Parse(Console.ReadLine());
                    return new Airplane("", color, engines); // Return Airplane object with specified properties

                case "boat":
                    Console.Write("Enter length: ");
                    length = double.Parse(Console.ReadLine());
                    return new Boat("", color, length); // Return Boat object with specified properties

                default:
                    throw new ArgumentException("Unknown vehicle type");
            }
        }

        public int GetGarageCapacity()
        {
            Console.Write("Enter garage capacity: ");
            return int.Parse(Console.ReadLine());
        }
    }
}
