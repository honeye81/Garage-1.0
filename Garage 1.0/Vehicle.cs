using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    public abstract class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; private set; }
        public string Color { get; private set; }
        public int Wheels { get; set; }

        protected Vehicle(string registrationNumber, string color, int wheels)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            Wheels = wheels;
        }

        public abstract void DisplayInfo();

        //Track Time Parked or Costs
        public DateTime ParkedTime { get; set; }

        public void ParkVehicle()
        {
            ParkedTime = DateTime.Now;
        }

        public double CalculateParkingCost(double hourlyRate)
        {
            TimeSpan timeParked = DateTime.Now - ParkedTime;
            return timeParked.TotalHours * hourlyRate;
        }
    }
}
