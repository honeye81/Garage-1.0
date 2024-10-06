namespace Garage_1._0
{
    public interface IHandler
    {
        bool AddVehicle(Vehicle vehicle); // Adds a vehicle to the garage
        bool RemoveVehicle(string registrationNumber); // Removes a vehicle by its registration number
        IEnumerable<Vehicle> ListAllVehicles(); // Returns a list of all vehicles in the garage
        Dictionary<string, int> ListVehicleTypes(); // Returns a dictionary of vehicle types and their count
        IEnumerable<Vehicle> SearchVehicles(Vehicle searchCriteria); // Searches for vehicles based on criteria
        void CreateGarage(int capacity); // Creates a new garage with a specified capacity
        bool IsGarageFull(); // Checks if the garage is full

        
    }
}