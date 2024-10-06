using Garage_1._0;

class Program
{
    static void Main(string[] args)
    {
        IUI ui = new ConsoleUI();
        IHandler handler = new GarageHandler(10); // Default capacity for the initial garage

        bool running = true;
        while (running)
        {
            ui.ShowMenu();
            string option = ui.GetInput("");

            switch (option)
            {
                case "1":
                    ListAllVehicles(ui, handler);
                    break;

                case "2":
                    ListVehicleTypesAndCount(ui, handler);
                    break;

                case "3":
                    AddVehicle(ui, handler);
                    break;

                case "4":
                    RemoveVehicle(ui, handler);
                    break;

                case "5":
                    SearchVehicles(ui, handler);
                    break;

                case "6":
                    CreateNewGarage(ui, ref handler);
                    break;

                case "7":
                    running = false;
                    ui.DisplayMessage("Exiting...");
                    break;

                default:
                    ui.DisplayMessage("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void ListAllVehicles(IUI ui, IHandler handler)
    {
        var vehicles = handler.ListAllVehicles();
        ui.DisplayVehicles(vehicles);
    }

    static void ListVehicleTypesAndCount(IUI ui, IHandler handler)
    {
        var vehicleCounts = handler.ListVehicleTypes();
        foreach (var count in vehicleCounts)
        {
            ui.DisplayMessage($"{count.Key}: {count.Value}");
        }
    }

    static void AddVehicle(IUI ui, IHandler handler)
    {
        Vehicle vehicle = ui.GetVehicleDetails();
        bool success = handler.AddVehicle(vehicle);
        if (success)
            ui.DisplayMessage("Vehicle added successfully.");
        else
            ui.DisplayMessage("Garage is full, cannot add more vehicles.");
    }

    static void RemoveVehicle(IUI ui, IHandler handler)
    {
        string regNumber = ui.GetRegistrationNumber();
        bool success = handler.RemoveVehicle(regNumber);
        if (success)
            ui.DisplayMessage("Vehicle removed successfully.");
        else
            ui.DisplayMessage("Vehicle not found.");
    }

    static void SearchVehicles(IUI ui, IHandler handler)
    {
        Vehicle criteria = ui.SearchCriteria();
        var vehicles = handler.SearchVehicles(criteria);
        ui.DisplayVehicles(vehicles);
    }

    static void CreateNewGarage(IUI ui, ref IHandler handler)
    {
        int capacity = ui.GetGarageCapacity();
        handler = new GarageHandler(capacity);
        ui.DisplayMessage($"New garage created with capacity {capacity}.");
    }
}
