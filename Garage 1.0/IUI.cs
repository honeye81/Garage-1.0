namespace Garage_1._0
{
    public interface IUI
    {
        void ShowMenu(); // To display the menu to the user
        void DisplayMessage(string message); // To show messages to the user
        void DisplayVehicles(IEnumerable<IVehicle> vehicles); // To display a list of vehicles
        string GetInput(string prompt); // To get input from the user
        Vehicle GetVehicleDetails(); // To get vehicle details for adding a new vehicle
        string GetRegistrationNumber(); // To get the registration number for removing or searching for a vehicle
        Vehicle SearchCriteria(); // To get search criteria from the user for searching vehicles
        int GetGarageCapacity(); // To get the capacity of the garage when creating a new garage

     
    }
}