namespace Garage_1._0
{
    public interface IVehicle
    {
        string RegistrationNumber { get; }
        string Color { get; }
        int Wheels { get; }
        void DisplayInfo();
    }
}