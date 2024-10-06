using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    public class Car : Vehicle
    {
        public string FuelType { get; private set; }

        public Car(string registrationNumber, string color, string fuelType)
            : base(registrationNumber, color, 4) 
        {
            FuelType = fuelType;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Car: {RegistrationNumber}, Color: {Color}, Wheels: {Wheels}, Fuel Type: {FuelType}");
        }
    }
}
