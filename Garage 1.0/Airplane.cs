using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    public class Airplane : Vehicle
    {
        public int NumberOfEngines { get; private set; }

        public Airplane(string registrationNumber, string color, int numberOfEngines)
            : base(registrationNumber, color, 4)
        {
            NumberOfEngines = numberOfEngines;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Airplane: {RegistrationNumber}, Color: {Color}, Wheels: {Wheels}, Engines: {NumberOfEngines}");
        }
    }
}
