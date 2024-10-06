using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    public class Bus : Vehicle
    {
        // Unique property for Bus
        public int NumberOfSeats { get; set; }


        public Bus(string registrationNumber, string color, int numberOfSeats)
            : base(registrationNumber, color, 6) 
        {
            NumberOfSeats = numberOfSeats;
        }

        // Override the ToString() 
        public override string ToString()
        {
            return $"Bus: {RegistrationNumber}, Color: {Color}, Wheels: {Wheels}, Seats: {NumberOfSeats}";
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Bus - Registration Number: {RegistrationNumber}, Color: {Color}, Wheel Count: {Wheels}, Passenger Capacity: {NumberOfSeats}");
        }
    }
}
