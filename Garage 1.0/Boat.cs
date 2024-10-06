using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    public class Boat : Vehicle
    {
        public double Length { get; private set; }

        public Boat(string registrationNumber, string color, double length)
            : base(registrationNumber, color, 0) 
        {
            Length = length;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Boat: {RegistrationNumber}, Color: {Color}, Length: {Length} m");
        }
    }
}
