using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    public class Motorcycle : Vehicle
    {
        public double EngineDisplacement { get; private set; }

        public Motorcycle(string registrationNumber, string color, double engineDisplacement)
            : base(registrationNumber, color, 2) 
        {
            EngineDisplacement = engineDisplacement;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Motorcycle: {RegistrationNumber}, Color: {Color}, Wheels: {Wheels}, Engine Displacement: {EngineDisplacement} cc");
        }
    }
}
